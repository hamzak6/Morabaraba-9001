namespace Morabaraba
{
    /// <summary>
    /// A Morabaraba Board
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// Are two coordinates adjacent to each other?
        /// </summary>
        /// <param name="a">First coordinate</param>
        /// <param name="b">Second coordinate</param>
        /// <returns>Whether the two are adjacent to each other</returns>
        bool Adjacent(Coordinate a, Coordinate b);
        
        /// <summary>
        /// Place a cow onto a coordinate
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="cow">The colour of the cow being placed onto the coordinate</param>
        /// <exception cref="InvalidOperationException">Thrown when the coordinate is occupied</exception>
        void Place(Coordinate coordinate, Colour cow);

        /// <summary>
        /// Displace a cow from a coordinate
        /// </summary>
        /// <param name="coordinate"></param>
        /// <exception cref="InvalidOperationException">Thrown when the coordinate is unoccupied</exception>
        void Displace(Coordinate coordinate);

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
        /// Are the cows of the player capable of moving?
        /// </summary>
        /// <param name="player">The colour of the player</param>
        /// <returns>Whether any of the cows can move</returns>
        bool CanMove(Colour player);

        /// <summary>
        /// Is the coordinate ooccupied?
        /// </summary>
        /// <param name="coordinate">The coordinate to be checked</param>
        /// <returns>Whether or not the coordinate is occupied</returns>
        bool IsOccupied(Coordinate coordinate);

        /// <summary>
        /// Who is occupying the coordinate?
        /// </summary>
        /// <param name="coordinate">The occupied coordinate</param>
        /// <returns>The colour of the cow occupying the coordinate</returns>
        /// <exception cref="InvalidOperationException">Thrown when the coordinate is unoccupied</exception>
        Colour Occupant(Coordinate coordinate);

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