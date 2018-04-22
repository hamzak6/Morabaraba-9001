namespace Morabaraba
{
    /// <inheritdoc />
    /// <summary>
    /// An implementation of the turn determiner
    /// </summary>
    public class TurnDeterminer : ITurnDeterminer
    {
        private readonly IShootDeterminer _shootDeterminer;

        public Colour Turn { get; private set; }

        private Colour Other => 
            Turn == Colour.Dark
                ? Colour.Light
                : Colour.Dark;

        public void Played()
        {
            if (!_shootDeterminer.CanShoot(Turn))
                Turn = Other;
        }

        public TurnDeterminer(IShootDeterminer shootDeterminer)
        {
            _shootDeterminer = shootDeterminer;
            Turn = Colour.Dark;
        }
    }
}