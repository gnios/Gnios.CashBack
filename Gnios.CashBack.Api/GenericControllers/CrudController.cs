using FluentValidation;
using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.ModelTest;
using Gnios.CashBack.Api.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnios.CashBack.Api.GenericControllers
{
    [Route("api/[controller]")]
    [GenericControllerName]
    public class CrudController<T> : BaseControllerBase where T : IEntity
    {
        public IRepository<T> Repository { get; }

        public CrudController(IHttpContextAccessor contexto, IRepository<T> repository) : base(contexto)
        {
            Repository = repository;
        }

        [HttpGet]
        public virtual IEnumerable<T> Get([FromQuery] OptionsFilter options = null)
        {
            var queryParams = HttpContext.Request.Query;
            var lista = Repository.GetAll(options);
            return lista.ToList();
        }

        [HttpGet("{id}")]
        public virtual T Get(int id)
        {
            return Repository.Get(id);
        }

        [HttpPut]
        public virtual T Put([FromBody]T recurso)
        {
            return Repository.Update(recurso);
        }

        [HttpPost]
        public virtual T Post([FromBody]T recurso)
        {
            return Repository.Add(recurso); ;
        }

        [HttpDelete]
        public virtual OkResult Delete([FromQuery]int id)
        {
            Repository.Remove(id);
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
