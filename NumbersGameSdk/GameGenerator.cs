using System;
using System.Collections.Generic;

namespace ScottLogic.NumbersGame
{
    
    public static class GameGenerator
    {
        private static Random Generator = new Random();

        public static bool GenerateCountdownGame(int bigNumbers, out int[] initialNumbers , out int target)
        {
            target = Generator.Next(101,1000);
            initialNumbers = new int[6];

            if (bigNumbers < 0 || bigNumbers > 4)
                return false;

            var bags = new Bags.CountdownNumberBags();

            for (int n = 0; n < bigNumbers; ++n)
                initialNumbers[n] = bags.Bag(0).TakeNumber();
            for (int n = bigNumbers; n < 6; ++n)
                initialNumbers[n] = bags.Bag(1).TakeNumber();

            return true;
        }

        public static bool GenerateCountdownPlusGame(int bigNumbers, out int[] initialNumbers, out int target)
        {
            const int numbers = 7;
            target = Generator.Next(1001, 100000); 
            initialNumbers = new int[numbers];
            if (bigNumbers < 0 || bigNumbers > 4)
                return false;

            var bags = new Bags.CountdownPlusNumberBags();

            for (int n = 0; n < bigNumbers; ++n)
                initialNumbers[n] = bags.Bag(0).TakeNumber();

            for (int n = bigNumbers; n < numbers; ++n)
                initialNumbers[n] = bags.Bag(1).TakeNumber();

            return true;
        }

    }
}
