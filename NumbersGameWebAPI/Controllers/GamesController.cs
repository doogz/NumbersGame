using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NumbersGameWebAPI.Models;

namespace NumbersGameWebAPI.Controllers
{
    [RoutePrefix("api/games")]
    public class GamesController : ApiController
    {
        // GET: api/Games
        [Route("")]
        public IEnumerable<Game> GetAllGames()
        {
            return Game.Repository;
        }

        // GET: api/Games/{id}
        [Route("{id:int}")]
        public Game GetGame(int id)
        {
            var game = Game.Repository.Find(g => g.GameId == id);
            return game;
        }

        
        // CHECK api/games/{id}/{solution}
        [AcceptVerbs("CHECK")]
        [Route("{id:int}/{solution}")]
        public bool CheckGame(int id, string solution)
        {
            return true;
        }
        


    }
}
