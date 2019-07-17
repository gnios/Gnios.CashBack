using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.Persistence;
using Gnios.CashBack.Api.Spotify;
using Microsoft.AspNetCore.Mvc;

namespace Gnios.CashBack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ClientRest Client { get; set; }
        public IRepository<AlbumEntity> Repo { get; }

        public ValuesController(ClientRest clientRest, IRepository<AlbumEntity> repo)
        {
            Client = clientRest;
            Repo = repo;
        }
        /// <summary>
        /// Teste Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var teste = new AlbumEntity();
            teste.Name = "teste";
            teste.Price = 1.1M;

            Repo.Add(teste);
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
