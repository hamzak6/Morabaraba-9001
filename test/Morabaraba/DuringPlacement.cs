using System;
using NSubstitute;
using NUnit.Framework;
using Morabaraba;

namespace Tests
{
    public class DuringPlacement
    {
        [SetUp]
        public void Setup()
        {
            
        }

        /// <summary> Test for a maximum of 12 placements </summary>
        [Test]
        public void Maximum12Placements()
        {
            IPlayer player = new Player();
            for (int i = 0; i < 12; i++)
                player.Placed();
            Assert.Throws<InvalidOperationException>(() => player.Placed());
        }

        /// <summary> Dark player plays first </summary>
        [Test]
        public void DarkPlayerPlaysFirst()
        {
            var shootDeterminer = Substitute.For<IShootDeterminer>();
            shootDeterminer.CanShoot(Colour.Dark).Returns(false);
            ITurnDeterminer turnDeterminer = new TurnDeterminer(shootDeterminer);
            var darkPlaysFirst = turnDeterminer.Turn == Colour.Dark;
            Assert.IsTrue(darkPlaysFirst);
        }
    }
}