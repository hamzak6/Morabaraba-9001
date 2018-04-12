namespace Morabaraba
{
    public interface IPlaceable
    {
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
    }
}