using FluentValidation;
using Gnios.CashBack.Api.ModelTest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Gnios.CashBack.Api.GenericControllers
{
    public class CrudController<T> : BaseControllerBase where T : Entidade
    {
        public CrudController(IHttpContextAccessor contexto) : base(contexto)
        {
        }

        [HttpGet]
        public virtual IQueryable<T> Get()
        {
            var request = Request;

            return null;
        }

        [HttpGet("{id}")]
        public virtual T Get(long id)
        {
            return null;
        }

        [HttpPut("{id}")]
        public virtual T Put([FromQuery]int id, [FromBody]T recurso)
        {
            return recurso;
        }

        [HttpPost]
        public virtual T Post([FromBody]T recurso)
        {
            return recurso;
        }

        [Route("{id:int}")]
        [HttpDelete]
        public virtual OkResult Delete([FromQuery]int id)
        {
            return Ok();
        }

        [AcceptVerbs("OPTIONS")]
        [HttpOptions]
        public virtual OkResult Options()
        {
            var resp = new OkResult();
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "POST,PUT,GET,DELETE");

            return resp;
        }
    }
}
