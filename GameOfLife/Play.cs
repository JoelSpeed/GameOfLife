using System;

namespace GameOfLife
{
    class Play
    {
        static void Main(string[] args)
        {
            int BoardSize = 20;
            int Generations = 20;

            // process cmd line arguments
            if (args.Length == 2)
            {
                Int32.TryParse(args[0], out BoardSize);
                Int32.TryParse(args[1], out Generations);
            }

            Random random = new Random(Guid.NewGuid().GetHashCode());

            Board oldBoard = Board.CreateRandom(BoardSize, random);

            Console.WriteLine("Generation 1");
            oldBoard.Print();

            for (int i = 2; i <= Generations; i++)
            {
                Console.WriteLine("Generation {0}", i);
                var board = Board.CreateFromPrevious(oldBoard);
                oldBoard = board;
                board.Print();
            }

            // Wait for a key press before exiting
            Console.Read();
        }
    }
}
