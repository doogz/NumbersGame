namespace ScottLogic.NumbersGame
{
    /// <summary>
    /// ISolutionProvider defines a protocol for interacting with a Countdown Numbers Game-solving algorithm.
    /// Game solvers are required to support several different goals as follows:
    /// 1. Finding a working solution and report it as quickly as possible.
    /// 2. Find the shortest solution possible.
    /// 3. Find a solution that uses up every number.
    /// To get us started, let's just focus on the GetFirstSolution() method, and then get into some WPF.
    /// 
    /// Kudos (but no extra points) for using up every one of the numbers - GetExhaustiveSolution if you're a nerd!
    /// </summary>
    public interface ISolutionProvider
    {
        /// <summary>
        /// Provides a solution to the caller via the out-parameter, the idea being, as quickly as possible.
        /// This is the main competition's sole means of judging algorithms.
        /// Note that unnecessary moves are not permitted in valid solutions, in terms of the competition rules.
        /// Returns false if no solution to be found, and true otherwise.
        /// </summary>
        /// <param name="inputNumbers">An unsorted array of numbers representing the starting numbers</param>
        /// <param name="target">The target of this numbers gamePlayer</param>
        /// <param name="solution">Receives solution</param>
        /// <returns>Returns true if a solution was found, false otherwise</returns>
        bool GetSolution(int[] inputNumbers, int target, out ISolution solution);

        
        /// <summary>
        /// Writes the shortest (in terms of moves) solution discovered into 'solution' out-parameter. Returns false if no solution to be found.
        /// </summary>
        /// <param name="inputNumbers"></param>
        /// <param name="target"></param>
        /// <param name="solution"></param>
        /// <returns>Returns true if a solution was found, false otherwise</returns>
        bool GetShortestSolution(int[] inputNumbers, int target, out ISolution solution);

        /// <summary>
        /// Gets all possible solutions to the puzzle. Returns false if no solution can be found.
        /// </summary>
        /// <param name="inputNumbers">The starting numbers</param>
        /// <param name="target">The target to reach</param>
        /// <param name="solutions">An output array of ISolution interface references</param>
        /// <returns></returns>
        bool GetAllSolutions(int[] inputNumbers, int target, out ISolution[] solutions);

    }
}
