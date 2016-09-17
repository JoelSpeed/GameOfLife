using System;

namespace GameOfLife
{
    class Play
    {
        static void Main()
        {
            int Generations = 10;
            Random random = new Random(Guid.NewGuid().GetHashCode());

            Board oldBoard = new Board(10, random);

            Console.WriteLine("Generation 1");
            oldBoard.Print();

            for (int i = 2; i <= Generations; i++)
            {
                Console.WriteLine("Generation {0}", i);
                var board = new Board(oldBoard);
                oldBoard = board;
                board.Print();
            }

            // Wait for a key press before exiting
            Console.Read();
        }
    }
}
