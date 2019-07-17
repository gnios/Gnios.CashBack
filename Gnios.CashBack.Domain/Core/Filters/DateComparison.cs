using Gnios.CashBack.ApplicationCore.Core;
using System;

namespace Gnios.CashBack.Api.GenericControllers.Filters
{
    public class DateComparison : IComparison
    {
        public bool GreaterThan(string leftDate, string rightDate)
        {
            DateTime left, right;
            ConvertDates(leftDate, rightDate, out left, out right);
            return (left >= right);
        }


        public bool LessThan(string leftDate, string rightDate)
        {
            DateTime left, right;
            ConvertDates(leftDate, rightDate, out left, out right);
            return (left <= right);
        }

        public bool Equals(string leftDate, string rightDate)
        {
            DateTime left, right;
            ConvertDates(leftDate, rightDate, out left, out right);
            return (left == right);
        }

        private static void ConvertDates(string leftDate, string rightDate, out DateTime left, out DateTime right)
        {
            if (DateTime.TryParse(leftDate, out left))
            {
                left = DateTime.Parse(leftDate);
            }
            else
            {
                throw new BadRequestException($"A data informada {leftDate} é inválida.");
            }
            if (DateTime.TryParse(rightDate, out right))
            {
                right = DateTime.Parse(rightDate);
            }
            else
            {
                throw new BadRequestException($"A data informada {rightDate} é inválida.");
            }
        }
    }
}
