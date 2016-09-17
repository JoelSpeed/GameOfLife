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
        }
    }
}
