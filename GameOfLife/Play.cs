using System;

namespace GameOfLife
{
    class Play
    {
        static void Main()
        {
            int Generations = 10;

            for (int i = 1; i <= Generations; i++)
            {
                Console.WriteLine("Generation {0}", i);
            }

            // Wait for a key press before exiting
            Console.Read();
        }
    }
}
