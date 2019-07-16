using System;

namespace Gnios.CashBack.Api.GenericControllers.Filters
{
    public class DateComparison : IComparison
    {

        public bool GreaterThan(string leftDate, string rightDate)
        {
            DateTime left = DateTime.Parse(leftDate);
            DateTime right = DateTime.Parse(rightDate);
            return (left >= right);
        }

        public bool LessThan(string leftDate, string rightDate)
        {
            DateTime left = DateTime.Parse(leftDate);
            DateTime right = DateTime.Parse(rightDate);
            return (left <= right);
        }

        public bool Equals(string leftDate, string rightDate)
        {
            DateTime left = DateTime.Parse(leftDate);
            DateTime right = DateTime.Parse(rightDate);
            return (left == right);
        }
    }
}
