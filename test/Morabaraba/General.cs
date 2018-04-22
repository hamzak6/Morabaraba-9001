using NUnit.Framework;
using Morabaraba;
using NSubstitute;

namespace Tests
{
    public class General
    {
        [Test]
        public void SameColourMill()
        {
            var board = new Board();
            board.Place(Coordinate.A1, Colour.Dark);
            board.Place(Coordinate.A4, Colour.Dark);
            board.Place(Coordinate.A7, Colour.Dark);
            Assert.IsTrue(board.InAMill(Colour.Dark));
        }
    }
}