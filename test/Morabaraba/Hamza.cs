using NUnit.Framework;
using Morabaraba;
using NSubstitute;

namespace Tests
{
    public class HamzaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckForAdjecent() //Check if coordinates are next to each other which is used to check if a move is valid
        {
            var board = Substitute.For<IBoard>();

            
            //bool result = board.Adjacent(Coordinate.A1,Coordinate.A4);
            //Assert.That(board.Adjacent(Coordinate.A1,Coordinate.A4), Is.EqualTo(false));

            //board.Adjacent(Coordinate.A1,Coordinate.D1).Returns(true);
            //Assert.That(board.Adjacent(Coordinate.A1,Coordinate.D1), Is.EqualTo(true));

            //board.Adjacent(Coordinate.A1,Coordinate.B2).Returns(true);
            //Assert.That(board.Adjacent(Coordinate.G1,Coordinate.D1), Is.EqualTo(true));

            //board.Adjacent(Coordinate.A1,Coordinate.A1).Returns(false);
            Assert.That(board.Adjacent(Coordinate.A1,Coordinate.A1), Is.EqualTo(false));

            //board.Adjacent(Coordinate.A1,Coordinate.A7).Returns(false);
            Assert.That(board.Adjacent(Coordinate.A1,Coordinate.A7), Is.EqualTo(false));

            //board.Adjacent(Coordinate.A1,Coordinate.B4).Returns(false);
            Assert.That(board.Adjacent(Coordinate.A1,Coordinate.B4), Is.EqualTo(false));

            //board.Adjacent(Coordinate.A1,Coordinate.G1).Returns(false);
            Assert.That(board.Adjacent(Coordinate.A1,Coordinate.G1), Is.EqualTo(false));
        }

        [Test]
         public void CheckOccupied ()
        {
          var board = Substitute.For<IBoard>();

          //board.IsOccupied(Coordinate.B6).Returns(true);
          Assert.That(board.IsOccupied(Coordinate.B6), Is.EqualTo(false));

          //board.IsOccupied(Coordinate.G7).Returns(false);
          Assert.That(board.IsOccupied(Coordinate.G7), Is.EqualTo(false));
        }

    }
}