using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudoGameEngine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LudoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersPlayerIDController : ControllerBase
    {
        private IGamesContainer _games;

        public PlayersPlayerIDController(IGamesContainer games)
        {
            _games = games;
        }

        // GET: api/PlayersPlayerID/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            var game = _games.GetOrCreateGame(id);
           var currentPlayerId = game.GetCurrentPlayer().PlayerId;

            game.GetPlayers();

           

            return "";
        }
               

        // PUT: api/PlayersPlayerID/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
