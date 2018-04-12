namespace Morabaraba
{
    public interface IOccupiable
    {
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
    }
}