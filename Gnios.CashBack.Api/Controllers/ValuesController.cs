using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.Persistence.Repositorys;
using Gnios.CashBack.Api.Spotify;
using Microsoft.AspNetCore.Mvc;

namespace Gnios.CashBack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ClientRest Client { get; set; }
        public IAlbumsRepository Repository { get; }

        public ValuesController(ClientRest clientRest, IAlbumsRepository repository)
        {
            Client = clientRest;
            Repository = repository;
        }
        /// <summary>
        /// Teste Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var teste = new Album();
            teste.Name = "teste";
            teste.Price = 1.1M;

            Repository.Add(teste);
            var lista = Repository.GetAll();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
