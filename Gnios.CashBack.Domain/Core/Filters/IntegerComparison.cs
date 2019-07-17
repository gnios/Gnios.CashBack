namespace Gnios.CashBack.Api.GenericControllers.Filters
{
    public class IntegerComparison : IComparison
    {

        public bool GreaterThan(string leftDate, string rightDate)
        {
            var left = int.Parse(leftDate);
            var right = int.Parse(rightDate);
            return (left >= right);
        }

        public bool LessThan(string leftDate, string rightDate)
        {
            var left = int.Parse(leftDate);
            var right = int.Parse(rightDate);
            return (left <= right);
        }

        public bool Equals(string leftDate, string rightDate)
        {
            var left = int.Parse(leftDate);
            var right = int.Parse(rightDate);
            return (left == right);
        }
    }
}
