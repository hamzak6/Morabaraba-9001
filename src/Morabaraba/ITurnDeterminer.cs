namespace Morabaraba
{
    /// <summary>
    /// The turn determining interface
    /// </summary>
    public interface ITurnDeterminer
    {
        /// <summary>
        /// Gets whose turn it is
        /// </summary>
        Colour Turn { get; }

        /// <summary>
        /// Call this when a move has actually been played
        /// </summary>
        void Played();
    }
}