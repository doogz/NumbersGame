using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NumbersGameWebAPI;

namespace ScottLogic.NumbersGame.GameServer.Controllers
{
    [RoutePrefix("api/games")]
    public class GamesController : ApiController
    {
        private readonly IPuzzleRepository _repo;

        /// <summary>
        /// Constructor requiring repository - supplied via DI using Unity. See WebApiConfig.cs for details.
        /// </summary>
        /// <param name="repo"></param>
        public GamesController(IPuzzleRepository repo)
        {
            _repo = repo;
        }


        // GET: api/Games

        /// <summary>
        /// Gets the complete set of game puzzles on the server - this could be rather a lot!!
        /// </summary>
        /// <returns>An enumerable collection of puzzles</returns>
        [Route("")]
        public IEnumerable<Puzzle> GetAllGames()
        {
            return _repo.GetAllPuzzles();
        }

        // GET: api/Games/{id}
        /// <summary>
        /// Gets the game puzzle from the server by specific id - TODO: Change the meaning of the ID to be 'Complexity'
        /// </summary>
        /// <returns>A puzzle instance</returns>

        [Route("{id:int}")]
        public Puzzle GetGame(int id)
        {

            var game = _repo.GetPuzzle(id);
            return game;
        }
        
        
        // SUBMIT api/games/{id}/{solution}
        
        /// <summary>
        /// Submit a solution to solve the given game
        /// </summary>
        /// <returns>Boolea indicating whether submitted solution actually solved puzzle</returns>
        [AcceptVerbs("SUBMIT")]
        [Route("{id:int}/{solution:ISolution}")]
        public Puzzle SubmitSolution(int id, ISolution solution)
        {
            var game = _repo.GetPuzzle(id);
            return game;
        }
        


        // REVEAL: api/games/{id}

        /// <summary>
        /// Gets a solution for the specified game from the server. This is for when a user "gives up" and wants to see how it's done.
        /// </summary>
        /// <returns>An object supporting the ISolution interface, describing a valid solution</returns>


        [AcceptVerbs("REVEAL")]
        [Route("{id:int}")]
        public ISolution RevealGame(int id)
        {
            var puzzle = GetGame(id);
            var solver = SolverFactory.CreateSolver(); // the default
            ISolution sol;
            if (solver.GetSolution(puzzle.StartingValues.ToArray(), puzzle.TargetValue, out sol))
            {
                return sol;
            }
            return null;
        }
    }
}
