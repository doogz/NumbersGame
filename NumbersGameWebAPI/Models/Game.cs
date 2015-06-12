using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumbersGameWebAPI.Models
{
    public class Game
    {
        /// <summary>
        /// Static repository generated during start-up
        /// </summary>
        public static List<Game> Repository = new List<Game>();


        public int GameId { get; set; }
        public int BigNumbers { get; set; }
        public int TotalNumbers { get; set; }
        public int[] StartingValues { get; set; }
        public int Target { get; set; }
    }
}

