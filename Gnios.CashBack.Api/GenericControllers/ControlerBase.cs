using Gnios.CashBack.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

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

    }
}
