using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottLogic.NumbersGame.Competition
{
    public class ChallengeSolution : IChallengeSolution
    {
        public int CompetitionNumber
        {
            get;set;
        }

        public int ChallengeNumber
        {
            get;set;
        }

        public int NumberOfGames
        {
            get { return _gameSolutions.Count; }
        }

        public ISolution GetSolution(int idx)
        {
            if (idx<0 || idx>=NumberOfGames)
                throw new IndexOutOfRangeException("Solution index requested is out of bounds");
            
            return _gameSolutions[idx];
        }
        
        //

        private List<ISolution> _gameSolutions = new List<ISolution>();
    }
}
