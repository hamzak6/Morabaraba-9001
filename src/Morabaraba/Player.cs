using System;

namespace Morabaraba
{
    /// <inheritdoc />
    /// <summary>
    /// Implementation of a Morabaraba Player
    /// </summary>
    public class Player : IPlayer
    {
        private int _placed;
        private int _shot;
        
        public void Placed()
        {
            if (_placed == 12)
                throw new InvalidOperationException();
            _placed++;
        }

        public void Shot()
        {
            if (CowsLeft == 2)
                throw new InvalidOperationException();
            _shot++;
        }

        public Coordinate[][] ForbiddenMills { get; set; }
        
        
        public Phase Phase
        {
            get
            {
                if (CowsLeft == 3 || CowsLeft == 2)
                    return Phase.Flying;
                if (_placed < 12)
                    return Phase.Placing;
                if (_placed == 12)
                    return Phase.Moving;
                throw new InvalidOperationException();
            }
        }


        public int CowsLeft
        {
            get
            {
                const int playable = 12;
                return playable - _shot;
            }
        }

        public Player()
        {
            _placed = 0;
            _shot = 0;
        }
    }
}