using System;

namespace GameOfLife
{
    public class Board
    {
        public int Dimension { get; set; }
        public Cell[,] Grid { get; }

        public Board(int Dimension)
        {
            this.Dimension = Dimension;
            this.Grid = new Cell[this.Dimension,this.Dimension];
            InitialiseGrid();
        }

        public Board(int Dimension, Random random)
        {
            this.Dimension = Dimension;
            this.Grid = new Cell[this.Dimension, this.Dimension];
            InitialiseGrid();
            PopulateGrid(random);
        }

        private void InitialiseGrid()
        {
            // fill the grid with new cells
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    Grid[i, j] = new Cell();
                }
            }
        }

        private void PopulateGrid(Random random)
        {
            int numAliveCells = random.Next(0, Dimension*Dimension);

            for(int i = 0; i < numAliveCells; i++)
            {
                int row = random.Next(0, Dimension);
                int column = random.Next(0, Dimension);

                Grid[row, column].IsAlive = true;
            }
        }

        public void Print()
        {
            var horizontalBorder = CreateHorizontalBorder();

            // print top border
            Console.WriteLine(horizontalBorder);

            // print each row in turn
            for (int i = 0; i < Dimension; i++)
            {
                var row = ConstructRowString(i);
                Console.WriteLine(row);
            }

            // print bottom border
            Console.WriteLine(horizontalBorder);
        }

        private string ConstructRowString(int rowNumber)
        {
            string row = "|";

            for (int i = 0; i < Dimension; i++)
            {
                if (Grid[rowNumber, i].IsAlive)
                {
                    row += "O";
                }
                else
                {
                    row += " ";
                }
            }

            row += "|";
            return row;
        }

        private string CreateHorizontalBorder()
        {
            // construct horizontal border
            string horizontalBorder = " ";
            for (int i = 0; i < Dimension; i++)
            {
                horizontalBorder += "-";
            }
            return horizontalBorder;
        }
    }
}
