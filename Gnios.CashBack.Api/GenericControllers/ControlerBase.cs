using Gnios.CashBack.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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

        protected IQueryable<T> Filtro<T>(IQueryable<T> retorno) where T : Entity<Guid>
        {
            var request = Request;
            var querystrings = request.Query.ToDictionary(q => q.Key, q => q.Value);

            foreach (var query in querystrings)
            {
                if (query.Key.Contains("id_like"))
                {
                    //if (query.Value.Any(x => x.Contains("|")))
                    //{
                    //    var ids = query.Value.First().Split('|').Select(x => int.Parse(x)).ToArray();
                    //    retorno = retorno.Where(x => ids.Contains(x.Id));
                    //}
                    //else
                    //{
                    //    var queryValue = query.Value[0];
                    //    retorno = retorno.Where(x => x.Id == int.Parse(queryValue));
                    //}
                }
                retorno = retorno.OrderBy(x => x.Id);

                if (query.Key.Contains("_limit"))
                {
                    retorno = retorno.Take(int.Parse(query.Value));
                }

                if (query.Key.Contains("_order"))
                {
                }

                if (query.Key.Contains("_sort"))
                {
                }

                if (query.Key.Contains("_start"))
                {
                    retorno = retorno.Skip(int.Parse(query.Value));
                }

                if (query.Key.Contains("_end"))
                {
                    retorno = retorno.Take(int.Parse(query.Value));
                }
            }


            // Return the response
            return retorno;
        }
    }
}
