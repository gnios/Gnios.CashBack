﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnios.CashBack.Api.GenericControllers.Filters
{
    public static class GenericComparer
    {
        private static Dictionary<Type, IComparison> dictComparision = new Dictionary<Type, IComparison>()
                {
                    { typeof(DateTime), new DateComparison() },
                    { typeof(int), new IntegerComparison() },
                    { typeof(string), new StringComparison() }
                };


        public static bool GenericComparison(object currentData, string rightData, string @operator, Type type)
        {
            if (currentData == null)
            {
                return false;
            }

            string leftData = currentData.ToString();
            if (@operator == ">=")
            {
                return dictComparision[type].GreaterThan(leftData, rightData);
            }

            if (@operator == "<=")
            {
                return dictComparision[type].LessThan(leftData, rightData);
            }

            return dictComparision[type].Equals(leftData, rightData);

        }

    }
}
