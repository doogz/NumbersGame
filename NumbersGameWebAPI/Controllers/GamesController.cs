using System.Collections.Generic;
using System.Web.Http;
using ScottLogic.NumbersGame;

namespace NumbersGameWebAPI.Controllers
{
    [RoutePrefix("api/games")]
    public class GamesController : ApiController
    {
        private readonly IPuzzleRepository _repo;
        
        /// <summary>
        /// Constructor requiring repository - supplied via DI
        /// </summary>
        /// <param name="repo"></param>
        public GamesController(IPuzzleRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Games
        [Route("")]
        public IEnumerable<Puzzle> GetAllGames()
        {
            return _repo.GetAllPuzzles();
        }

        // GET: api/Games/{id}
        [Route("{id:int}")]
        public Puzzle GetGame(int id)
        {
            var game = _repo.GetPuzzle(id);
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
