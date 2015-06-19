using System.Collections.Generic;
using System.Web.Http;
using ScottLogic.NumbersGame;

namespace NumbersGameWebAPI.Controllers
{
    [RoutePrefix("api/games")]
    public class GamesController : ApiController
    {
        private readonly PuzzleRepository _puzzleRespository = new PuzzleRepository();
        // GET: api/Games
        [Route("")]
        public IEnumerable<IPuzzle> GetAllGames()
        {
            return _puzzleRespository.GetAllPuzzles();
        }

        // GET: api/Games/{id}
        [Route("{id:int}")]
        public IPuzzle GetGame(int id)
        {
            var game = _puzzleRespository.GetPuzzle(id);
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
