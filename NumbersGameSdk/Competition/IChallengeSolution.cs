using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottLogic.NumbersGame.Competition
{
    public interface IChallengeSolution
    {
        int CompetitionNumber { get; }
        int ChallengeNumber { get; }
        int NumberOfGames { get; }
        ISolution GetSolution(int idx);
    }
}
