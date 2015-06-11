using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using AspWebAppSample.Models;

namespace AspWebAppSample.Controllers
{
    public class GamesController : ApiController
    {
        private Game[] games = new Game[]
        {
            new Game(1),
            new Game(2), 
            new Game(3)
        };
        public IHttpActionResult GetGame(int id)
        {
            var game = new Game(id);
            return Ok(game);
        }

        public IEnumerable<Game> GetAllGames()
        {
            return games;
        }

    }
}
