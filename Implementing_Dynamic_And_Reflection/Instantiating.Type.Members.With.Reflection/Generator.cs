using System.Reflection;
using System.Text;

namespace Instantiating.Type.Members.With.Reflection
{
    public abstract class GeneratorBase<TData>
    {
        public string Generate(List<TData> items)
        {
            StringBuilder report = GetTitle();
            Dictionary<string, ColumnDetail> columnDetails =
            GetColumnDetails(items);
            report.Append(GetHeaders(columnDetails));
            report.Append(GetRows(items, columnDetails));
            return report.ToString();
        }

        protected abstract StringBuilder GetTitle();

        protected abstract StringBuilder GetHeaders(Dictionary<string, ColumnDetail> details);

        protected abstract StringBuilder GetRows(List<TData> items, Dictionary<string, ColumnDetail> details);

        Dictionary<string, ColumnDetail> GetColumnDetails(List<TData> items)
        {
            TData itemInstance = items.First();
            System.Type itemType = itemInstance.GetType();
            PropertyInfo[] itemProperties = itemType.GetProperties();
            return
            (from prop in itemProperties
             let attribute = prop.GetCustomAttribute<ColumnAttribute>()
             where attribute != null
             select new ColumnDetail
             {
                 Name = prop.Name,
                 Attribute = attribute,
                 PropertyInfo = prop
             })
            .ToDictionary(
            key => key.Name,
            val => val);
        }

        protected List<string> GetColumns(IEnumerable<ColumnDetail> details, TData item)
        {
            var columns = new List<string>();
            foreach (var detail in details)
            {
                PropertyInfo member = detail.PropertyInfo;
                string format =
                string.IsNullOrWhiteSpace(
                detail.Attribute.Format) ?
                "{0}" :
                detail.Attribute.Format;
                (object result, System.Type columnType) =
                GetReflectedResult(item, member);
                switch (columnType.Name)
                {
                    case "Decimal":
                        columns.Add(
                        string.Format(format, (decimal)result));
                        break;
                    case "Int32":
                        columns.Add(
                        string.Format(format, (int)result));
                        break;
                    case "String":
                        columns.Add(
                        string.Format(format, (string)result));
                        break;
                    default:
                        break;
                }
            }
            return columns;
        }

        private (object, System.Type) GetReflectedResult(TData item, PropertyInfo property)
        {
            object result = property.GetValue(item);
            System.Type type = property.PropertyType;
            return (result, type);
        }
    }

    public class MarkdownGenerator<TData> : GeneratorBase<TData>
    {
        const string ColumnSeparator = " | ";

        protected override StringBuilder GetTitle()
        {
            return new StringBuilder("# Report\n\n");
        }

        protected override StringBuilder GetHeaders(
            Dictionary<string, ColumnDetail> details)
        {
            var header = new StringBuilder();
            header.AppendJoin(
                ColumnSeparator,
                from detail in details.Values
                select detail.Attribute.Name);
            header.Append("\n");
            header.AppendJoin(
                ColumnSeparator,
                from detail in details.Values
                let length = detail.Attribute.Name.Length
                select "".PadLeft(length, '-'));
            header.Append("\n");
            return header;
        }

        protected override StringBuilder GetRows(
            List<TData> items,
            Dictionary<string, ColumnDetail> details)
        {
            var rows = new StringBuilder();
            foreach (var item in items)
            {
                List<string> columns =
                GetColumns(details.Values, item);
                rows.AppendJoin(ColumnSeparator, columns);
                rows.Append("\n");
            }
            return rows;
        }
    }

    public class HtmlGenerator<TData> : GeneratorBase<TData>
    {
        protected override StringBuilder GetTitle()
        {
            return new StringBuilder("<h1>Report</h1>\n");
        }
        protected override StringBuilder GetHeaders(
            Dictionary<string, ColumnDetail> details)
        {
            var header = new StringBuilder("<tr>\n");
            header.AppendJoin(
                "\n",
                from detail in details.Values
                let columnName = detail.Attribute.Name
                select $" <th>{columnName}</th>");
            header.Append("\n</tr>\n");
            return header;
        }

        protected override StringBuilder GetRows(
            List<TData> items,
            Dictionary<string, ColumnDetail> details)
        {
            StringBuilder rows = new StringBuilder();
            System.Type itemType = items.First().GetType();
            foreach (var item in items)
            {
                rows.Append("<tr>\n");
                List<string> columns =
                    GetColumns(details.Values, item);
                rows.AppendJoin(
                    "\n",
                    from columnValue in columns
                    select $" <td>{columnValue}</td>");
                rows.Append("\n</tr>\n");
            }
            return rows;
        }
    }    
}
