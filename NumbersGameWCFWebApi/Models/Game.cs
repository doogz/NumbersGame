using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScottLogic.NumbersGame;

namespace AspWebAppSample.Models
{
    public class Game
    {
        
        public Game(int bigNumbers)
        {
            int target;
            int[] numbers;
            GameGenerator.GenerateCountdownGame(bigNumbers, out numbers, out target);
            StartingValues = numbers;
            Target = target;
        }

        public int[] StartingValues { get; set; }
        

        public int Target { get; set; }
        public int BigNumbers { get; set; }
    }
}