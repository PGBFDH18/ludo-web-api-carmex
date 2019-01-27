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
        //List med alla spelera i spelet
        // GET: api/ludo/{gameid}/players
        [HttpGet("{gameid}/players")]
        public JsonResult Get(int gameId)
        {
            // Ta gameId för att leta reda på vilket spel det är
            // Gör en getorcreateGame på det spelID
            LudoGame game = _games.GetOrCreateGame(gameId);            

            // komma åt spelarna via getPlayers 
            var players = game.GetPlayers();

           //returnerar alla objekt
            return new JsonResult(players);
        }

        // POST: api/ludo/{gameid}/players
        [HttpPost("{gameid}/players/")]
        public JsonResult Post(int gameid, string name, int color)
        {

            // hämtar spelet där spelaren skall skapas
            LudoGame game = _games.GetOrCreateGame(gameid);

            // lägg till en ny spelare till spelet
            Player player = game.AddPlayer(name, (PlayerColor) color);

            // retunera den nya spelaren
            return new JsonResult(player);
        }       
    }
}
