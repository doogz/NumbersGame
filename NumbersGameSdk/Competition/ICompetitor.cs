using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScottLogic.NumbersGame.Competition
{
    public interface ICompetitor
    {
        /// <summary>
        /// Name property uniquely identifies a competitor within the context of all competitions.
        /// Any name is permitted, as long as it is unique - they are allocated on a first-come basis and then associated with
        /// the client IP address. Multiple submissions from the same IP address
        /// </summary>
        string Name { get; set; }

        IPAddress LocalAddress { get; }

        int HighestScore { get; }
        int CurrentRank { get; }
    }

}
