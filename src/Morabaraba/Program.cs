using System;

namespace Morabaraba
{
    class Program
    {
        static void Main()
        {
            IBoard board = new Board();
            IPlayer darkPlayer = new Player();
            IPlayer lightPlayer = new Player();
            IGame game = new Game(board, darkPlayer, lightPlayer, null);
            IShootDeterminer shootDeterminer = new ShootDeterminer(game);
            ITurnDeterminer turnDeterminer = new TurnDeterminer(shootDeterminer);
            IMoveDeterminer moveDeterminer = new MoveDeterminer(turnDeterminer, shootDeterminer, game);
            IMoveExecutor moveExecutor = new MoveExecutor(game);
            IPrinter printer = new Printer(game);
            IScanner scanner = new Scanner(printer);
            IMoveAcceptor moveAcceptor = new MoveAcceptor(scanner, printer, moveDeterminer, moveExecutor,
                turnDeterminer);
            moveAcceptor.Accept();
            Console.ReadKey();
        }
    }
}