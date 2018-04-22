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
    }
}