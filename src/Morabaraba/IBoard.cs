namespace Morabaraba
{
    /// <summary>
    /// A Morabaraba Board
    /// </summary>
    public interface IBoard : IPlaceable, IMillable, IOccupiable
    {
        /// <summary>
        /// Are two coordinates adjacent to each other?
        /// </summary>
        /// <param name="a">First coordinate</param>
        /// <param name="b">Second coordinate</param>
        /// <returns>Whether the two are adjacent to each other</returns>
        bool Adjacent(Coordinate a, Coordinate b);

        /// <summary>
        /// Are the cows of the player capable of moving?
        /// </summary>
        /// <param name="player">The colour of the player</param>
        /// <returns>Whether any of the cows can move</returns>
        bool CanMove(Colour player);
    }
}