using Gnios.CashBack.Api.GenericControllers.Filters;
using Gnios.CashBack.Api.Persistence;
using Gnios.CashBack.ApplicationCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Gnios.CashBack.Api.GenericControllers
{
    public static class Filter
    {
        public static IList<Expression<Func<T, bool>>> ByQueryParams<T>(OptionsFilter queryParams) where T : IEntity
        {
            IList<Expression<Func<T, bool>>> predicate = new List<Expression<Func<T, bool>>>();
            var classType = typeof(T);
            var propList = classType.GetProperties();

            var props = new Dictionary<string, PropertyInfo>(propList.Select(x => new KeyValuePair<string, PropertyInfo>(x.Name, x)), StringComparer.OrdinalIgnoreCase);

            var filters = new List<QueryFilter>();

            foreach (var param in queryParams._filter)
            {
                if (string.IsNullOrEmpty(param))
                {
                    return predicate;
                }

                if (param.Contains("=="))
                {
                    filters.Add(PrepareFilter(param, "=="));
                }

                if (param.Contains(">="))
                {
                    filters.Add(PrepareFilter(param, ">="));
                }

                if (param.Contains("<="))
                {
                    filters.Add(PrepareFilter(param, "<="));
                }
            }

            if (queryParams._filter.Count > 0 && filters.Count == 0)
            {
                throw new BadRequestException($"Todos os filtros devem conter um dos operadores ('>=','<=','==')");
            }

            foreach (var param in filters)
            {
                if (props.ContainsKey(param.PropertyName))
                {
                    var prop = props[param.PropertyName.ToLower()];
                    if (prop.PropertyType == typeof(int)
                        || prop.PropertyType == typeof(DateTime)
                        || prop.PropertyType == typeof(string))
                    {
                        predicate.Add(x => GenericComparer.GenericComparison(prop.GetValue(x, null), param.Value, param.Operator, prop.PropertyType));
                    }
                }
                else
                {
                    throw new BadRequestException($"A propriedade {param.PropertyName} não exite neste objeto.");
                }
            }

            return predicate;
        }

        private static QueryFilter PrepareFilter(string param, string @operator)
        {
            return param.Contains(@operator) ? new QueryFilter(param.Split(@operator)[0], param.Split(@operator)[1], @operator) : null;
        }

        public static IEnumerable<T> Sort<T>(OptionsFilter options, IList<T> list)
        {
            var classType = typeof(T);
            var propList = classType.GetProperties();

            var props = new Dictionary<string, PropertyInfo>(propList.Select(x => new KeyValuePair<string, PropertyInfo>(x.Name, x)), StringComparer.OrdinalIgnoreCase);
            IOrderedEnumerable<T> listOrdered = list.OrderBy(x => props["id"].GetValue(x, null));

            if (string.IsNullOrEmpty(options._sort))
            {
                return listOrdered.ToList();
            }

            var sort = options._sort.Split(',');

            for (int i = 0; i < sort.Length; i++)
            {
                string param = sort[i];

                if (!props.ContainsKey(param.Replace("_desc", "")))
                {
                    throw new BadRequestException($"A propriedade {param} não exite neste objeto.");
                }

                var prop = props[param.Replace("_desc", "")];
                if (param.Contains("_desc"))
                {
                    if (i == 0)
                    {
                        listOrdered = list.OrderByDescending(x => prop.GetValue(x, null));
                    }
                    else
                    {
                        listOrdered = listOrdered.ThenByDescending(x => prop.GetValue(x, null));
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        listOrdered = list.OrderBy(x => prop.GetValue(x, null));
                    }
                    else
                    {
                        listOrdered = listOrdered.ThenBy(x => prop.GetValue(x, null));
                    }
                }

            }
            return listOrdered.ToList();
        }
    }
}
