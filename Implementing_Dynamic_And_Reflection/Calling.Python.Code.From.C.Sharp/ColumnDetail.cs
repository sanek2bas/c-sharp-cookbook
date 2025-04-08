using System.Reflection;

namespace Calling.Python.Code.From.C.Sharp
{
    public class ColumnDetail
    {
        public string Name { get; set; }

        public ColumnAttribute Attribute { get; set; }

        public PropertyInfo PropertyInfo { get; set; }
    }
}
