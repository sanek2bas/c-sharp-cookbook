using System.Reflection;

namespace Creating.An.Inherently.Dynamic.Type
{
    public class ColumnDetail
    {
        public string Name { get; set; }

        public ColumnAttribute Attribute { get; set; }

        public PropertyInfo PropertyInfo { get; set; }
    }
}
