namespace Morabaraba
{
    /// <inheritdoc />
    /// <summary>
    /// Shoot determiner implementation
    /// </summary>
    public class ShootDeterminer : IShootDeterminer
    {
        private readonly IGame _game;
        
        public bool CanShoot(Colour player)
        {
            var inAMill =
                _game.Board.InAMill(player) && 
                (_game.Player(player).ForbiddenMills == null || // for the first time are mill is received
                _game.Board.AreMillsDifferent(_game.Player(player).ForbiddenMills, _game.Board.Mills(player)));
            return inAMill;
        }

        public ShootDeterminer(IGame game)
        {
            _game = game;
        }
    }
}