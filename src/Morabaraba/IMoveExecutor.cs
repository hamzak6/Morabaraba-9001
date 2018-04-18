using System;

namespace Morabaraba
{
    /// <summary>
    /// Move executor interface
    /// </summary>
    public interface IMoveExecutor
    {
        /// <summary>
        /// Executes the move
        /// </summary>
        /// <param name="move">The move to be executed</param>
        /// <param name="coordinates">The coordinates to be used for the execution</param>
        /// <returns>Potential error</returns>
        /// <exception cref="ArgumentException">Thrown when the move passed is and end of game move</exception>
        string Execute(Move move, Coordinate[] coordinates);
    }
}