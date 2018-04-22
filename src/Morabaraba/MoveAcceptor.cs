using System;

namespace Morabaraba
{
    /// <inheritdoc />
    /// <summary>
    /// Implementation of Move Acceptor
    /// </summary>
    public class MoveAcceptor : IMoveAcceptor
    {
        private readonly IScanner _scanner;
        private readonly IPrinter _printer;
        private readonly IMoveDeterminer _moveDeterminer;
        private readonly IMoveExecutor _moveExecutor;
        private readonly ITurnDeterminer _turnDeterminer;

        /// <summary>
        /// Initialises the Move Acceptor
        /// </summary>
        /// <param name="scanner">The scanner that will be used for accepting input</param>
        /// <param name="printer">The printer that will be used by the move acceptor</param>
        /// <param name="moveDeterminer">The move determiner used by the acceptor</param>
        /// <param name="moveExecutor">The move executor used by the acceptor</param>
        /// <param name="turnDeterminer">The turn determiner to be used by the acceptor</param>
        public MoveAcceptor(IScanner scanner, IPrinter printer, IMoveDeterminer moveDeterminer,
            IMoveExecutor moveExecutor, ITurnDeterminer turnDeterminer)
        {
            _scanner = scanner;
            _printer = printer;
            _moveDeterminer = moveDeterminer;
            _moveExecutor = moveExecutor;
            _turnDeterminer = turnDeterminer;
        }

        private bool IsGameOver(Move move)
        {
            switch (move)
            {
                case Move.Draw:
                    _printer.Request = "It's a draw!";
                    return true;
                case Move.DarkWins:
                    _printer.Request = "Dark player has won!";
                    return true;
                case Move.LightWins:
                    _printer.Request = "Light player has won!";
                    return true;
                default:
                    return false;
            }
        }

        private bool InputCountMatches(Move move, int count)
        {
            switch (move)
            {
                case Move.DarkPlace: case Move.LightPlace: case Move.DarkShoot: case Move.LightShoot:
                    return count == 1;
                default:
                    return count == 2;
            }
        }

        private void RequestForCurrentMove(Move move)
        {
            const string dark = "Dark player's ";
            const string light = "Light player's ";
            const string placing = "placing target: ";
            const string moving = "space separated moving targets ie <coordinate> <source>: ";
            const string flying = "space separated flying targets ie <coordinate> <source>: ";
            const string shooting = "shooting target: ";
            switch (move)
            {
                case Move.DarkPlace:
                    _printer.Request = dark + placing;
                    break;
                case Move.DarkMove:
                    _printer.Request = dark + moving;
                    break;
                case Move.DarkFly:
                    _printer.Request = dark + flying;
                    break;
                case Move.DarkShoot:
                    _printer.Request = dark + shooting;
                    break;
                case Move.LightPlace:
                    _printer.Request = light + placing;
                    break;
                case Move.LightMove:
                    _printer.Request = light + moving;
                    break;
                case Move.LightFly:
                    _printer.Request = light + flying;
                    break;
                case Move.LightShoot:
                    _printer.Request = light + shooting;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        public void Accept()
        {
            while (true)
            {
                if (IsGameOver(_moveDeterminer.CurrentMove))
                {
                    _printer.Request = "Press any key to exit!";
                    _printer.Print();
                    return;
                }
                RequestForCurrentMove(_moveDeterminer.CurrentMove);
                var coordinates = _scanner.Scan();
                if (!InputCountMatches(_moveDeterminer.CurrentMove, coordinates.Length))
                {
                    _printer.Error = "Mismatch between expected and actual coordinates. Try again!";
                    continue;
                }
                var error = _moveExecutor.Execute(_moveDeterminer.CurrentMove, coordinates);
                if (error != null)
                    _printer.Error = error;
                else
                {
                    _turnDeterminer.Played();
                    _printer.Error = "";
                }
            }
        }
    }
}