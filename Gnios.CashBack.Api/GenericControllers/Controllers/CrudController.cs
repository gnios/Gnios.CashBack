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
    public class CrudController<TEntity, TDto> : BaseControllerBase
        where TEntity : IEntity
        where TDto : IDto
    {
        public IBusiness<TEntity, TDto> Business { get; }

        public CrudController(IHttpContextAccessor contexto, IBusiness<TEntity,TDto> business) : base(contexto)
        {
            Business = business;
        }

        [HttpGet]
        public virtual IEnumerable<TDto> Get([FromQuery] OptionsFilter options = null)
        {
            var queryParams = HttpContext.Request.Query;
            var lista = Business.GetAll(options);
            return lista.ToList();
        }

        [HttpGet("{id}")]
        public virtual TDto Get(int id) => Business.Get(id);

        [HttpPut]
        public virtual TDto Put([FromBody]TDto recurso) => Business.Update(recurso);

        [HttpPost]
        public virtual TDto Post([FromBody]TDto recurso) => Business.Add(recurso);

        [HttpDelete]
        public virtual OkResult Delete([FromQuery]int id)
        {
            Business.Remove(id);
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
