namespace Morabaraba
{
    /// <inheritdoc />
    /// <summary>
    /// An implementation of the Morabaraba Game interface
    /// </summary>
    public class Game : IGame
    {
        public IBoard Board { get; }

        public IPlayer DarkPlayer { get; }

        public IPlayer LightPlayer { get; }

        public Move? LastPlayed { get; set; }

        /// <summary>
        /// Creates a new Morabaraba Game object
        /// </summary>
        /// <param name="board">The board to be used by the game</param>
        /// <param name="darkPlayer">The dark player for the game</param>
        /// <param name="lightPlayer">The light player for the game</param>
        /// <param name="lastPlayed">The last move played</param>
        public Game(IBoard board, IPlayer darkPlayer, IPlayer lightPlayer, Move? lastPlayed)
        {
            Board = board;
            DarkPlayer = darkPlayer;
            LightPlayer = lightPlayer;
            LastPlayed = lastPlayed;
        }

        public IPlayer Player(Colour colour)
        {
            return
                colour == Colour.Dark
                    ? DarkPlayer
                    : LightPlayer;
        }
    }
}