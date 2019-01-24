﻿using System;
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
        private IGamesContainer _gameContainer;

        public LudoController(IGamesContainer games)
        {
            _gameContainer = games;
        }

        // GET: api/Ludo
        /// <summary>
        /// Lista av fia spel
        /// </summary>
        /// <returns>Lista av gameId</returns>
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return _gameContainer.GetAllGames();
        }

        // POST: api/Ludo
        /// <summary>
        /// Skapa ett nytt spel
        /// Retunera inget
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public int Post()
        {
            // find a gameid som genererar nytt numer hela tiden?
            int GameID = 0;

            //Kollar getorCreateGame om det redan finns ett sånt spelID?
            _gameContainer.GetOrCreateGame(GameID);       
            return GameID;
        }     
    }
}
