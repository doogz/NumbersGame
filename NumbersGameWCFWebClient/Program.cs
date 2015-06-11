using System;
using ScottLogic.NumbersGame.Client.NumbersGameServiceReference;

namespace ScottLogic.NumbersGame.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Numbers Game Web Client - synchronous mode");
            Console.WriteLine("How many big numbers (0-4):");
            var input = Console.ReadLine();
            int numBigOnes = 1;
            if (!String.IsNullOrEmpty(input))
            {
                Int32.TryParse(input, out numBigOnes);
            }

            using (var proxy = new NumbersGameServiceClient())
            {
                proxy.Open();

                int[] values;
                int target;
                if (proxy.GetStandardGame(out values, out target, numBigOnes))
                {
                    Console.WriteLine("Web Service returned the following:");
                    Console.Write("{");
                    for (int i = 0; i < values.Length; ++i)
                    {
                        Console.Write("{0}", values[i]);
                        if (i < values.Length - 1) Console.Write(", ");
                    }
                    Console.WriteLine("}");
                    Console.WriteLine("The target is {0}", target);
                }

            }
            Console.ReadLine();
        }
    }
}
