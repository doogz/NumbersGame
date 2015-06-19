using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScottLogic.NumbersGame.Game;

namespace ScottLogic.NumbersGame.Competition
{
    /// <summary>
    /// Each challenge takes place within the context of a unique competition. 
    /// </summary>
    public interface IChallenge
    {
        int CompetitionNumber { get; }
        int ChallengeNumber { get; }
        int NumberGames { get; }
        INumbersGamePlayer GetGame(int index);
    }
}
