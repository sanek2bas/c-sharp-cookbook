﻿using System.Reflection;
using System.Text;

namespace Calling.C.Sharp.Code.From.Python
{
    public class Report
    {
        const string ColumnSeparator = " | ";

        public string GenerateDynamic(dynamic[] items)
        {
            List<object> inventory =
                (from item in items
                 select new InventoryItem
                 (
                     item.PartNumber,
                     item.Description,
                     item.Count,
                     item.ItemPrice
                 ))
                .ToList<object>();

            return Generate(inventory);
        }

        public string Generate(List<object> items)
        {
            var report = new StringBuilder("# Report\n\n");

            Dictionary<string, ColumnDetail> columnDetails =
                GetColumnDetails(items);
            report.Append(GetHeaders(columnDetails));
            report.Append(GetRows(items, columnDetails));

            return report.ToString();
        }

        Dictionary<string, ColumnDetail> GetColumnDetails(
            List<object> items)
        {
            object itemInstance = items.First();
            Type itemType = itemInstance.GetType();
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

        StringBuilder GetHeaders(
            Dictionary<string, ColumnDetail> details)
        {
            var header = new StringBuilder();

            header.Append(
                string.Join(
                    ColumnSeparator,
                    from detail in details.Values
                    select detail.Attribute.Name));

            header.Append("\n");

            header.Append(
                string.Join(
                ColumnSeparator,
                    from detail in details.Values
                    let length = detail.Attribute.Name.Length
                    select "".PadLeft(length, '-')));

            header.Append("\n");

            return header;
        }

        StringBuilder GetRows(
            List<object> items,
            Dictionary<string, ColumnDetail> details)
        {
            var rows = new StringBuilder();

            foreach (var item in items)
            {
                List<string> columns =
                    GetColumns(details.Values, item);

                rows.Append(string.Join(ColumnSeparator, columns));

                rows.Append("\n");
            }

            return rows;
        }

        List<string> GetColumns(
            IEnumerable<ColumnDetail> details,
            object item)
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

                (object result, Type columnType) =
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
                    case "Single":
                        columns.Add(
                            string.Format(format, (float)result));
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

        private (object, Type) GetReflectedResult(
            object item, PropertyInfo property)
        {
            object result = property.GetValue(item);
            Type type = property.PropertyType;

            return (result, type);
        }
    }
}
