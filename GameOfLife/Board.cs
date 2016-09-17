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
            this.Grid = new Cell[this.Dimension, this.Dimension];
            InitialiseGrid();
        }

        public Board(int Dimension, Random random)
        {
            this.Dimension = Dimension;
            this.Grid = new Cell[this.Dimension, this.Dimension];
            InitialiseGrid();
            PopulateGrid(random);
        }

        public Board(Board previousBoard)
        {
            this.Dimension = previousBoard.Dimension;
            this.Grid = new Cell[this.Dimension, this.Dimension];
            InitialiseGrid();
            PopulateGrid(previousBoard);
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
            int numAliveCells = random.Next(Dimension, Dimension*Dimension);

            for (int i = 0; i < numAliveCells; i++)
            {
                int row = random.Next(0, Dimension);
                int column = random.Next(0, Dimension);

                Grid[row, column].IsAlive = true;
            }
        }

        private void PopulateGrid(Board previousBoard)
        {
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    int aliveNeighbourCount = CountCellAliveNeighbours(previousBoard, i, j);
                    Cell cell = this.Grid[i, j];

                    var rule = CalculateMatchingRule(cell, aliveNeighbourCount);

                    UpdateCell(rule, cell);

                }
            }
        }

        private static void UpdateCell(int rule, Cell cell)
        {
            switch (rule)
            {
                case 1:
                    cell.IsAlive = false;
                    break;
                case 2:
                    cell.IsAlive = true;
                    break;
                case 3:
                    cell.IsAlive = false;
                    break;
                case 4:
                    cell.IsAlive = true;
                    break;
                default:
                    break;
            }
        }

        private static int CalculateMatchingRule(Cell cell, int aliveNeighbourCount)
        {
                    /*
                     * Rules of the game:
                     * 1. Any live cell with fewer than two live neighbours dies, as if caused by under-population.
                     * 2. Any live cell with two or three live neighbours lives on to the next generation.
                     * 3. Any live cell with more than three live neighbours dies, as if by over - population.
                     * 4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                     */

            int rule = 0;
            if (cell.IsAlive)
            {
                if (aliveNeighbourCount < 2)
                    rule = 1;
                if (aliveNeighbourCount == 2 || aliveNeighbourCount == 3)
                    rule = 2;
                if (aliveNeighbourCount > 3)
                    rule = 3;
            }
            else
            {
                if (aliveNeighbourCount == 3)
                    rule = 4;
            }
            return rule;
        }

        private int CountCellAliveNeighbours(Board previousBoard, int row, int column)
        {
            int count = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    bool neighbourIsAlive = false;

                    try
                    {
                        // dont count cell as a neighbour of itself
                        if (!(i == 0 && j == 0))
                        {
                            neighbourIsAlive = previousBoard.Grid[row + i, column + j].IsAlive;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        neighbourIsAlive = false;
                    }
                    finally
                    {
                        if(neighbourIsAlive)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
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
