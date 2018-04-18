namespace Morabaraba
{
    /// <summary>
    /// Shoot determiner interface
    /// </summary>
    public interface IShootDeterminer
    {
        /// <summary>
        /// Gets whether the player shoot?
        /// </summary>
        bool CanShoot(Colour player);
    }
}