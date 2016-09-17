using System;
using System.IO;
using ApprovalTests;
using ApprovalTests.Reporters;
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
            // check height
            if (board.Grid.GetLength(1) != 10)
            {
                Assert.Fail();
            }
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CheckBlankBoardPrintsCorrectly()
        {
            var board = new Board(10);

            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            board.Print();

            Approvals.Verify(stringWriter.ToString());
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CheckRandomBoardPrintsCorrectly()
        {
            int seed = 845584026;
            Random random = new Random(seed);
            var board = new Board(10, random);

            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            board.Print();

            Approvals.Verify(stringWriter.ToString());
        }
    }
}
