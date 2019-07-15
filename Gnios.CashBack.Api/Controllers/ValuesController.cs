using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gnios.CashBack.Api.Spotify;
using Microsoft.AspNetCore.Mvc;

namespace Gnios.CashBack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ClientRest Client { get; set; }
        public ValuesController(ClientRest clientRest)
        {
            Client = clientRest;
        }
        /// <summary>
        /// Teste Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            Client.GetAlbums();
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
