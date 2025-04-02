using System.Diagnostics.CodeAnalysis;

namespace Querying.Distinct.Objects
{
    public class SalesPersonComparer : IEqualityComparer<SalesPerson>
    {
        public bool Equals(SalesPerson? x, SalesPerson? y)
        {
            return x?.ID == y?.ID;
        }

        public int GetHashCode([DisallowNull] SalesPerson obj)
        {
            //return obj == null ? 0 : obj.GetHashCode();
            return obj == null ? 0 : obj.ID.GetHashCode();
        }
    }
}
