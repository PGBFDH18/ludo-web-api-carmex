using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudoGameEngine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LudoWebAPI.Controllers
{
    [Route("api/ludo")]
    [ApiController]
    public class LudoController : ControllerBase
    {
        private IGamesContainer _games;

        public LudoController(IGamesContainer games)
        {
            _games = games;
        }

        // GET: api/Ludo
        /// <summary>
        /// Lista av fia spel
        /// </summary>
        /// <returns>Lista av gameId</returns>
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return _games.GetAllGames();
        }

        // POST: api/Ludo
        /// <summary>
        /// Skapa ett nytt spel
        /// Retunera inget
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] int value)
        {
            _games.GetOrCreateGame(value);
        }

     
    }
}
