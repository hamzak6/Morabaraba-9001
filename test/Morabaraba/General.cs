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

        [Test]
        public void DifferentColoursNotInAMill() 
        {
            var board = new Board();
            board.Place(Coordinate.A1, Colour.Dark);
            board.Place(Coordinate.A4, Colour.Light);
            board.Place(Coordinate.A7, Colour.Dark);
            Assert.IsFalse(board.InAMill(Coordinate.A1) && board.InAMill(Coordinate.A7) && board.InAMill(Coordinate.A4));
        }

        [Test]
        public void ConnectedSpacesNotInALineDoNotFormALine()
        {
            var board = new Board();
            board.Place(Coordinate.A1, Colour.Dark);
            board.Place(Coordinate.A4, Colour.Dark);
            board.Place(Coordinate.D1, Colour.Dark);
            Assert.IsFalse(board.InAMill(Coordinate.A4));
        }
    }
}