using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudoGameEngine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LudoWebAPI.Controllers
{   // Kolla så routern är rätt här?
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
            // anv. träningen för att uppdater en spleares position
            //hämta objektet piece från ludogame och döp den till 
            //piece lokalt här för att kunna mova piece. 
            var game = _games.GetOrCreateGame(id);
            int playerIndex = 0; // <---- FIX
            var player = game.GetPlayers()[playerIndex];
            int pieceIndex = 0; // <--- FIX
            var piece = player.Pieces[pieceIndex];

            int moveDistance = 0; // <--- FIX
            game.MovePiece(player, piece.PieceId, moveDistance);
        }

        // DELETE: api/ludo/{gameid]}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _games.DeleteGame(id);
        }
    }
}
