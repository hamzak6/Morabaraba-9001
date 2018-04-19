using System;

namespace Morabaraba
{
    /// <summary>
    /// A Morabaraba Player interface
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Called every time a player's cow is placed
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method is called after the 12th time</exception>
        void Placed();
        
        /// <summary>
        /// Called every time a player's cow is shot
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method is called after 2 cows remain</exception>
        void Shot();
        
        /// <summary>
        /// Gets or sets the mills to not be used on the next move
        /// </summary>
        Coordinate[][] ForbiddenMills { get; set; }
        
        /// <summary>
        /// Gets the phase the player is in
        /// </summary>
        Phase Phase { get; }
        
        /// <summary>
        /// Get the cows left available to play
        /// </summary>
        int CowsLeft { get; }
    }
}