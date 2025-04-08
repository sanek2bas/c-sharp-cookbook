using System.Reflection;

namespace Replacing.Reflection.With.Dynamic.Code
{
    public class ColumnDetail
    {
        public string Name { get; set; }

        public ColumnAttribute Attribute { get; set; }

        public MemberInfo MemberInfo { get; set; }
    }
}
