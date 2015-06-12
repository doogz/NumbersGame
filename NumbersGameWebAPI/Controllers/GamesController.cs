using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NumbersGameWebAPI.Models;
using ScottLogic.NumbersGame.Game;

namespace NumbersGameWebAPI.Controllers
{
    [RoutePrefix("api/games")]
    public class GamesController : ApiController
    {
        // GET: api/Games
        [Route("")]
        public IEnumerable<Definition> GetAllGames()
        {
            return GameDefinition.Repository;
        }

        // GET: api/Games/{id}
        [Route("{id:int}")]
        public Definition GetGame(int id)
        {
            var game = GameDefinition.Repository.Find(g => g.GameId == id);
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
