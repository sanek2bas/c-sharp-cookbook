using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Performing.Interop.With.Office.Apps
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

    public class ExcelTypedGenerator<TData> : GeneratorBase<TData>
    {
        ApplicationClass excelApp;
        Workbook wkBook;
        Worksheet wkSheet;
        public ExcelTypedGenerator()
        {
            excelApp = new ApplicationClass();
            excelApp.Visible = true;
            wkBook = excelApp.Workbooks.Add(Missing.Value);
            wkSheet = (Worksheet)wkBook.ActiveSheet;
        }
        protected override StringBuilder GetTitle()
        {
            wkSheet.Cells[1, 1] = "Report";
            return new StringBuilder("Added Title...\n");
        }
        protected override StringBuilder GetHeaders(
        Dictionary<string, ColumnDetail> details)
        {
            ColumnDetail[] values = details.Values.ToArray();
            for (int i = 0; i < values.Length; i++)
            {
                ColumnDetail detail = values[i];
                wkSheet.Cells[3, i + 1] = detail.Attribute.Name;
            }
            return new StringBuilder("Added Header...\n");
        }
        protected override StringBuilder GetRows(
        List<TData> items,
        Dictionary<string, ColumnDetail> details)
        {
            const int DataStartRow = 4;
            int rows = items.Count;
            int cols = details.Count;
            var data = new string[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                List<string> columns =
                GetColumns(details.Values, items[i]);
                for (int j = 0; j < cols; j++)
                {
                    data[i, j] = columns[j];
                }
            }
            int FirstCol = 'A';
            int LastExcelCol = FirstCol + cols - 1;
            int LastExcelRow = DataStartRow + rows - 1;
            string EndRangeCol = ((char)LastExcelCol).ToString();
            string EndRangeRow = LastExcelRow.ToString();
            string EndRange = EndRangeCol + EndRangeRow;
            string BeginRange = "A" + DataStartRow.ToString();
            var dataRange = wkSheet.get_Range(BeginRange, EndRange);
            dataRange.Value2 = data;
            wkBook.SaveAs(
            "Report.xlsx", Missing.Value, Missing.Value,
            Missing.Value, Missing.Value, Missing.Value,
            XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value, Missing.Value);
            return new StringBuilder(
            "Added Data...\n" +
            "Excel file created at Report.xlsx");
        }
}
        public class ExcelDynamicGenerator<TData> : GeneratorBase<TData>
        {
            ApplicationClass excelApp;
            dynamic wkBook;
            Worksheet wkSheet;
            public ExcelDynamicGenerator()
            {
                excelApp = new ApplicationClass();
                excelApp.Visible = true;
                wkBook = excelApp.Workbooks.Add();
                wkSheet = wkBook.ActiveSheet;
            }
            protected override StringBuilder GetTitle()
            {
                wkSheet.Cells[1, 1] = "Report";
                return new StringBuilder("Added Title...\n");
            }
            protected override StringBuilder GetHeaders(
            Dictionary<string, ColumnDetail> details)
            {
                ColumnDetail[] values = details.Values.ToArray();
                for (int i = 0; i < values.Length; i++)
                {
                    ColumnDetail detail = values[i];
                    wkSheet.Cells[3, i + 1] = detail.Attribute.Name;
                }
                return new StringBuilder("Added Header...\n");
            }
            protected override StringBuilder GetRows(
            List<TData> items,
            Dictionary<string, ColumnDetail> details)
            {
                const int DataStartRow = 4;
                int rows = items.Count;
                int cols = details.Count;
                var data = new string[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    List<string> columns =
                    GetColumns(details.Values, items[i]);
                    for (int j = 0; j < cols; j++)
                    {
                        data[i, j] = columns[j];
                    }
                }
                int FirstCol = 'A';
                int LastExcelCol = FirstCol + cols - 1;
                int LastExcelRow = DataStartRow + rows - 1;
                string EndRangeCol = ((char)LastExcelCol).ToString();
                string EndRangeRow = LastExcelRow.ToString();
                string EndRange = EndRangeCol + EndRangeRow;
                string BeginRange = "A" + DataStartRow.ToString();
                var dataRange = wkSheet.get_Range(BeginRange, EndRange);
                dataRange.Value2 = data;
                wkBook.SaveAs(
                "Report.xlsx",
                XlSaveAsAccessMode.xlShared);
                return new StringBuilder(
                "Added Data...\n" +
                "Excel file created at Report.xlsx");
            }
    }
}
