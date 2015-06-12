using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottLogic.NumbersGame.Competition
{
    /// <summary>
    /// A competition is identified by its unique Number property.
    /// </summary>
    interface ICompetition
    {
        int Number { get; }
        TimeSpan Duration { get; }

        bool EnterCompetition(ICompetitor competitor);

        IChallenge GetNextChallenge();
        void SubmitSolution(ICompetitor competitor, IChallengeSolution solution);

    }
}
