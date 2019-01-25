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
    public class LudoGameIDController : ControllerBase
    {
        private IGamesContainer _games;

        public LudoGameIDController(IGamesContainer games)
        {
            _games = games;
        }

        // GET: api/ludo/{gameid]}
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var game = _games.GetOrCreateGame(id);

            return new JsonResult(new {
                id,
                currentPlayerId = game.GetCurrentPlayer().PlayerId,
                players = game.GetPlayers(),
                pieces = game.GetAllPiecesInGame()
            });
        }

        // PUT: api/ludo/{gameid]}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //Ändra placering på en pjäs
            //Ändra placering på en pjäs
            //Ändra placering på en pjäs

        }

        // DELETE: api/ludo/{gameid]}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _games.DeleteGame(id);
        }
    }
}
