using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ScottLogic.NumbersGame.Competition
{
    public class Competition : ICompetition
    {

        public Competition()
        {
            Number = GetNextCompetitionId();
            Duration = TimeSpan.FromSeconds(60);
            GamesPerChallenge = 5;
        }

        public int Number { get;set; }

        public TimeSpan Duration { get; set; }
        public bool EnterCompetition(ICompetitor competitor)
        {
            // Each competitor must have a unique name. Multiple connections are permitted though.
            // If we have any with the same name and a different address, refuse "entry"
            var sameName = _competitors.Where(c => c.Name == competitor.Name && !c.LocalAddress.Equals(competitor.LocalAddress));
            if (sameName.Any())
            {
                return false;
            }

            _competitors.Add(competitor);
            return true;
        }

        public IChallenge GetNextChallenge()
        {
            throw new NotImplementedException();
        }

        public void SubmitSolution(ICompetitor competitor, IChallengeSolution solution)
        {
            throw new NotImplementedException();
        }

        public int GamesPerChallenge { get; set; }

        /// <summary>
        /// Implementation details
        /// </summary>
        private static int _competitionId = 0;

        private int GetNextCompetitionId()
        {
            //TODO: Not thread safe, not using db or EF
            ++_competitionId;
            return _competitionId;
        }
        List<ICompetitor> _competitors = new List<ICompetitor>();


    }
}
