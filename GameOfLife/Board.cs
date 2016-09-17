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
    }
}
