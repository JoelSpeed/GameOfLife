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
    }
}
