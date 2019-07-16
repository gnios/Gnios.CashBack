using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Gnios.CashBack.Api.GenericControllers
{
    [Route("api/[controller]")]
    public abstract class BaseControllerBase : Controller
    {
        protected IHttpContextAccessor contexto;

        public BaseControllerBase(IHttpContextAccessor contexto)
        {
            this.contexto = contexto;
        }

        protected void AddXTotalCount(int count)
        {
            Response.Headers.Add("X-Total-Count", count.ToString());
        }

        public Expression<Func<T, bool>> FilterByQueryParams<T>(IQueryCollection queryParams) where T : IEntity
        {
            Expression<Func<T, bool>> predicate = null;
            var classType = typeof(T);
            var propList = classType.GetProperties();

            var props = new Dictionary<string, PropertyInfo>(propList.Select(x => new KeyValuePair<string, PropertyInfo>(Char.ToLowerInvariant(x.Name[0]) + x.Name.Substring(1), x)));

            foreach (var param in queryParams)
            {
                if (props.ContainsKey(param.Key))
                {
                    var prop = props[param.Key];
                    if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string))
                    {
                        if (param.Value.Count == 1)
                        {
                            predicate = (x => prop.GetValue(x, null).ToString() == param.Value.First());
                        }
                        else
                        {
                            predicate = x => param.Value.Contains(prop.GetValue(x, null).ToString());
                        }
                    }
                }
            }

            return predicate;
        }
    }
}
