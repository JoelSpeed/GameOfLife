using ApprovalTests;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class GameOfLifeTests
    {
        [Test]
        public void CheckNewCellNotAlive()
        {
            var cell = new Cell();
            if (cell.IsAlive)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void CheckBoardDimensionGetsSet()
        {
            var board = new Board(10);
            if (board.Dimension != 10)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void CheckBoardGridIsCorrectSize()
        {
            var board = new Board(10);
            // check height
            if (board.Grid.GetLength(0) != 10)
            {
                Assert.Fail();
            }
            // check width
            if (board.Grid.GetLength(1) != 10)
            {
                Assert.Fail();
            }
        }
    }
}
