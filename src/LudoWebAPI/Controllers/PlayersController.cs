using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        // GET: api/ludo/{id}/players
        [HttpGet("{id}/players")]
        public JsonResult Get(int id)
        {
            // hämtar spelet där spelaren skall skapas
            LudoGame game = _games.GetOrCreateGame(id);

            // hämta alla spelare i spelet
            Player[] players = game.GetPlayers();

            // retunera all spelare i JSON format
            return new JsonResult(players);
        }

        //här skpas en ny spelare
        // POST: api/ludo/{id}/players
        [HttpPost("{id}/players")]
        public ActionResult Post(int id, string name, int color)
        {
            // hämtar spelet där spelaren skall skapas
            LudoGame game = _games.GetOrCreateGame(id);

            //kontroller så att alla spelare har unika färger
            if (game.GetPlayers().Where(p => (int)p.PlayerColor == color).Count() > 0)
            {
                //BadRequest = en felaktig för frågan. BadRequest är en http standard fel.
                return BadRequest($"Unable to add player because color is already used");
            }

            // lägg till en ny spelare till spelet
            Player player = game.AddPlayer(name, (PlayerColor) color);

            // retunera den nya spelaren
            return new JsonResult(player);
        }       
    }
}
