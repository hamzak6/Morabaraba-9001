using System;

namespace Morabaraba
{
    /// <inheritdoc />
    /// <summary>
    /// Implementation of Morabaraba printer
    /// </summary>
    public class Printer : IPrinter
    {
        private readonly IGame _game;
        
        public void Print()
        {
            Console.Clear();
            // Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "Morabaraba";
            const string title = @"                                                  _                                                       _                                                 
                 )))           xxx           ((_           ___           ,,,           ___           ((_           ___           ,,,           ___      
                (o o)         (o o)         (o o)         (o o)         (o o)         (o o)         (o o)         (o o)         (o o)         (o o)     
            ooO--(_)--Ooo-ooO--(_)--Ooo-ooO--(_)--Ooo-ooO--(_)--Ooo-ooO--(_)--Ooo-ooO--(_)--Ooo-ooO--(_)--Ooo-ooO--(_)--Ooo-ooO--(_)--Ooo-ooO--(_)--Ooo-
            ";
            var board = _game.Board.ToString();
            var error = 
                $@"                                                    {Error}
            ";
            var request = $@"                                                    {Request}";
            var display = title + board + error + request;
            Console.Write(display);
        }

        public string Error { get; set; }
        
        public string Request { get; set; }
        
        public Printer (IGame game)
        {
            _game = game;
        }
    }
}