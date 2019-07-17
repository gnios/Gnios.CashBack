using System;

namespace Gnios.CashBack.Api.GenericControllers.Filters
{
    public class StringComparison : IComparison
    {

        public bool GreaterThan(string left, string right)
        {
            return (string.Compare(left, right, true) > 0);
        }

        public bool LessThan(string left, string right)
        {
            return (string.Compare(left,right, true) < 0);
        }

        public bool Equals(string left, string right)
        {
            return (left.ToLower().Equals(right.ToLower()));
        }
    }
}
