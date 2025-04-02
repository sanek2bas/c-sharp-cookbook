using System.Linq.Expressions;

namespace Building.Query.Filter.With.Expression
{
    public static class CookbookExtensions
    {
        public static IEnumerable<TParameter> WhereOr<TParameter>(
            this IEnumerable<TParameter> query, 
            Dictionary<string, string> criteria)
        {
            const string ParamName = "person";

            ParameterExpression paramExpr =
                System.Linq.Expressions.Expression.Parameter(typeof(TParameter), ParamName);

            System.Linq.Expressions.Expression accumulatorExpr = null;

            foreach (var criterion in criteria)
            {
                MemberExpression paramMbr =
                    LambdaExpression.PropertyOrField(paramExpr, criterion.Key);

                MemberExpression leftExpr =
                    System.Linq.Expressions.Expression.Property(paramExpr, typeof(TParameter).GetProperty(criterion.Key));

                System.Linq.Expressions.Expression rightExpr =
                    System.Linq.Expressions.Expression.Constant(criterion.Value, typeof(string));

                System.Linq.Expressions.Expression equalExpr =
                    System.Linq.Expressions.Expression.Equal(leftExpr, rightExpr);

                accumulatorExpr = accumulatorExpr == null 
                    ? equalExpr 
                    : System.Linq.Expressions.Expression.Or(accumulatorExpr, equalExpr);
            }

            Expression<Func<TParameter, bool>> allClauses =
                System.Linq.Expressions.Expression.Lambda<Func<TParameter, bool>>(accumulatorExpr, paramExpr);

            Func<TParameter, bool> compiledClause = allClauses.Compile();

            return query.Where(compiledClause);
        }
    }
}
