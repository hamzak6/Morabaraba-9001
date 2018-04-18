namespace Morabaraba
{
    /// <summary>
    /// Determines Morabaraba moves
    /// </summary>
    public interface IMoveDeterminer
    {
        /// <summary>
        /// Gets the current move
        /// </summary>
        Move CurrentMove { get; }
    }
}