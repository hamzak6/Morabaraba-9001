using System;
using System.Linq;

namespace Morabaraba
{
    /// <summary>
    /// Implementation of Morabaraba scanner
    /// </summary>
    public class Scanner : IScanner
    {
        private readonly IPrinter _printer;

        public Coordinate[] Scan()
        {
            while (true)
            {
                _printer.Print();
                const string error = "Unrecognised input. Try again!";
                var input = Console.ReadLine().Trim().Split(' ');
                if (input
                    .Select(value => int.TryParse(value, out int _))
                    .Contains(true))
                {
                    _printer.Error = error; // Do not accept integers
                    continue;
                }
                if (input
                    .Select(value => Enum.TryParse(value, out Coordinate _))
                    .Contains(true))
                    return
                        input.Select(Enum.Parse<Coordinate>)
                        .ToArray();
                _printer.Error = error;
            }
        }

        public Scanner(IPrinter printer)
        {
            _printer = printer;
        }
    }
}