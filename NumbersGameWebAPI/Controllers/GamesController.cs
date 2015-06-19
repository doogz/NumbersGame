using System.Collections.Generic;
using System.Web.Http;
using ScottLogic.NumbersGame;
using ScottLogic.NumbersGame.Game;

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
        public bool CheckGame(int id, ISolution solution)
        {
            var puzzle = GetGame(id);

            var player = new NumbersGamePlayer(puzzle.StartingValues, puzzle.TargetValue);
            for (int n=0; n<solution.NumberOfOperations; ++n)
            {
                player.DoOperation(solution[n]);
            }

            return player.IsSolved;
        }
        


    }
}
