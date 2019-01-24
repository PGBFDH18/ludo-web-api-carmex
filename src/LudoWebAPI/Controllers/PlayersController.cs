using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LudoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private IGamesContainer _games;

        public PlayersController(IGamesContainer games)
        {
            _games = games;
        }
        // GET: api/Players
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }      

        // POST: api/Players
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }       
    }
}
