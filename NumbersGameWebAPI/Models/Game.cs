using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScottLogic.NumbersGame.Game;

namespace NumbersGameWebAPI.Models
{
    public class GameDefinition : Definition
    {
        /// <summary>
        /// Static repository generated during start-up
        /// </summary>
        public static List<Definition> Repository = new List<Definition>();

    }
}

