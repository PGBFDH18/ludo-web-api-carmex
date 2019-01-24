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
    public class PlayersController : ControllerBase
    {
        private IGamesContainer _games;

        public PlayersController(IGamesContainer games)
        {
            _games = games;
        }
        // GET: api/ludo/{gameid}/players
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/ludo/{gameid}/players
        [HttpPost("{gameid}/players")]
        public JsonResult Post(int id, string name, int color)
        {
            // hämtar spelet där spelaren skall skapas
            LudoGame game = _games.GetOrCreateGame(id);

            // lägg till en ny spelare till spelet
            Player player = game.AddPlayer(name, (PlayerColor) color);

            // retunera den nya spelaren
            return new JsonResult(player);
        }       
    }
}
