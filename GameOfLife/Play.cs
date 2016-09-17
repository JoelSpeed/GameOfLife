using System;

namespace GameOfLife
{
    class Play
    {
        static void Main()
        {
            int Generations = 10;
            Random random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 1; i <= Generations; i++)
            {
                Console.WriteLine("Generation {0}", i);
                var board = new Board(10, random);
                board.Print();
            }

            // Wait for a key press before exiting
            Console.Read();
        }
    }
}
