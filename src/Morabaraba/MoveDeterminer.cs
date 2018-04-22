namespace Morabaraba
{
    /// <inheritdoc />
    /// <summary>
    /// Implementation of Move Determiner
    /// </summary>
    public class MoveDeterminer : IMoveDeterminer
    {
        private readonly IGame _game;
        private readonly ITurnDeterminer _turnDeterminer;
        private readonly IShootDeterminer _shootDeterminer;
        private int _flightsWithoutShots;

        private bool Win(ref Move result)
        {
            const int limitForLoss = 2;
            if (_game.DarkPlayer.CowsLeft == limitForLoss ||
                !_game.Board.CanMove(Colour.Dark) && _game.Player(Colour.Dark).Phase == Phase.Moving &&
                (_game.Board.CanMove(Colour.Light) || _game.Player(Colour.Light).Phase != Phase.Moving))
            {
                result = Move.LightWins;
                return true;
            }
            if (_game.LightPlayer.CowsLeft == limitForLoss ||
                !_game.Board.CanMove(Colour.Light) && _game.Player(Colour.Light).Phase == Phase.Moving &&
                (_game.Board.CanMove(Colour.Dark) || _game.Player(Colour.Dark).Phase != Phase.Moving))
            {
                result = Move.DarkWins;
                return true;
            }
            return false;
        }

        private bool Draw(ref Move result)
        {
            const int turnLimitForDraw = 10;
            if (turnLimitForDraw == _flightsWithoutShots ||
                _game.Board.AllCoordinatesOccupied &&
                 Phase.Moving == _game.Player(Colour.Dark).Phase &&
                 Phase.Moving == _game.Player(Colour.Light).Phase)
            {
                result = Move.Draw;
                return true;
            }
            return false;
        }

        private void FlyWithoutShooting()
        {
            if ((_game.DarkPlayer.Phase == Phase.Flying || 
                 _game.LightPlayer.Phase == Phase.Flying) &&
                !_shootDeterminer.CanShoot(_turnDeterminer.Turn))
                _flightsWithoutShots++;
            if (_shootDeterminer.CanShoot(_turnDeterminer.Turn))
                _flightsWithoutShots = 0;
        }

        private Move DetermineMove()
        {
            if (_turnDeterminer.Turn == Colour.Dark)
            {
                if (_shootDeterminer.CanShoot(_turnDeterminer.Turn))
                    return Move.DarkShoot;
                switch (_game.DarkPlayer.Phase)
                {
                    case Phase.Placing:
                        return Move.DarkPlace;
                    case Phase.Moving:
                        return Move.DarkMove;
                    case Phase.Flying:
                        return Move.DarkFly;
                }
            }
            else
            {
                if (_shootDeterminer.CanShoot(_turnDeterminer.Turn))
                    return Move.LightShoot;
                switch (_game.LightPlayer.Phase)
                {
                    case Phase.Placing:
                        return Move.LightPlace;
                    case Phase.Moving:
                        return Move.LightMove;
                    case Phase.Flying:
                        return Move.LightFly;
                }
            }
            return Move.DarkPlace;
        }
        
        public Move CurrentMove
        {
            get
            { 
                FlyWithoutShooting();
                var currentMove = Move.DarkMove;
                if (Draw(ref currentMove) || Win(ref currentMove))
                    return currentMove;
                return DetermineMove();
            }
        }

        public MoveDeterminer(ITurnDeterminer turnDeterminer, IShootDeterminer shootDeterminer, IGame game)
        {
            _turnDeterminer = turnDeterminer;
            _shootDeterminer = shootDeterminer;
            _game = game;
            _flightsWithoutShots = 0;
        }
    }
}