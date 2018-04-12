namespace Morabaraba
{
    interface IMillable
    {
        /// <summary>
        /// Does the coordinate contain a cow in a mill?
        /// </summary>
        /// <param name="coordinate">The coordinate containing the cow</param>
        /// <returns>Whether the cow is in a mill</returns>
        /// <exception cref="InvalidOperationException">Thrown when the coordinate is empty</exception>
        bool InAMill(Coordinate coordinate);

        /// <summary>
        /// Is the player in a mill?
        /// </summary>
        /// <param name="player">The colour of the player</param>
        /// <returns>Whether the player is in a mill</returns>
        bool InAMill(Colour player);

        /// <summary>
        /// Are all of the player's cows in a mill?
        /// </summary>
        /// <param name="player">The colour of the player</param>
        /// <returns>Whether all the player's cows are in a mill</returns>
        bool AllInAMill(Colour player);


        /// <summary>
        /// Collects all the mills a player has
        /// </summary>
        /// <param name="player">The colour of the player</param>
        /// <returns>The collected mills</returns>
        Coordinate[][] Mills(Colour player);

        /// <summary>
        /// Is there a difference between the mill collections
        /// </summary>
        /// <param name="mills1">First mill collection</param>
        /// <param name="mills2">Second mill collection</param>
        /// <returns>Whether there is a difference</returns>
        bool AreMillsDifferent(Coordinate[][] mills1, Coordinate[][] mills2);
    }
}