using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScottLogic.NumbersGame.Competition
{
    public class Competitor : ICompetitor
    {
        public Competitor(string name)
        {
            Name = name;
            LocalAddress = GetLocalIPAddress();
        }

        public string Name { get; set; }

        public IPAddress LocalAddress { get; set; }

        public int HighestScore
        {
            get; private set;
        }

        public int CurrentRank
        {
            get; private set;
        }


        private static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                // IPV4 anyway
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    return ip;
                }
            }
            return IPAddress.None;
        }


    }
}
