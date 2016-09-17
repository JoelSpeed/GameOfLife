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
            var board = Board.CreateBlank(10);
            if (board.Dimension != 10)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void CheckBoardGridIsCorrectSize()
        {
            var board = Board.CreateBlank(10);
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
            var board = Board.CreateBlank(10);

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
            var board = Board.CreateRandom(10, random);

            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            board.Print();

            Approvals.Verify(stringWriter.ToString());
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CheckRule1PrintsCorrectly()
        {
            var board = Board.CreateBlank(3);

            // this cell has no live neighbours, should die.
            board.Grid[0, 0].IsAlive = true;
            // remaining cells all have no live neighbours so should stay dead

            var secondGenBoard = Board.CreateFromPrevious(board);

            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            secondGenBoard.Print();

            Approvals.Verify(stringWriter.ToString());
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CheckRule2And4PrintsCorrectly()
        {
            var board = Board.CreateBlank(3);

            // cell [0,1] has 2 live neighbours, should survive #2
            // other live cells should die
            // cell [1, 1] has 3 live cells as neighbours, should become alive #4
            board.Grid[0, 0].IsAlive = true;
            board.Grid[0, 1].IsAlive = true;
            board.Grid[0, 2].IsAlive = true;


            var secondGenBoard = Board.CreateFromPrevious(board);

            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            secondGenBoard.Print();

            Approvals.Verify(stringWriter.ToString());
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CheckRule3PrintsCorrectly()
        {
            var board = Board.CreateBlank(3);

            // These four should live as per #2
            board.Grid[0, 1].IsAlive = true;
            board.Grid[1, 0].IsAlive = true;
            board.Grid[1, 2].IsAlive = true;
            board.Grid[2, 1].IsAlive = true;

            // This one should die as per #3
            board.Grid[1, 1].IsAlive = true;

            // remaining dead cells should become alive, #4

            var secondGenBoard = Board.CreateFromPrevious(board);

            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            secondGenBoard.Print();

            Approvals.Verify(stringWriter.ToString());
        }
    }
}
