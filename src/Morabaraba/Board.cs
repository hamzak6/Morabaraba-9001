using System;
using System.Collections.Generic;
using System.Linq;

namespace Morabaraba
{
    /// <inheritdoc />
    /// <summary>
    /// A Morabaraba Board
    /// </summary>
    public class Board : IBoard
    {
        private enum Line
        {
            Row,
            Column,
            Diagonal
        }
        
        private readonly IDictionary<Coordinate, Colour> _occupations;
        private readonly IDictionary<Coordinate, Dictionary<Coordinate, Line>> _coordinates;

        public Board()
        {
            _occupations = new Dictionary<Coordinate, Colour>();
            _coordinates = new Dictionary<Coordinate, Dictionary<Coordinate, Line>>
            {
                { Coordinate.A1, new Dictionary<Coordinate, Line> { { Coordinate.A4, Line.Row }, { Coordinate.B2, Line.Diagonal }, { Coordinate.D1, Line.Column } } },
                { Coordinate.A4, new Dictionary<Coordinate, Line> { { Coordinate.A1, Line.Row }, { Coordinate.A7, Line.Row }, { Coordinate.B4, Line.Column } } },
                { Coordinate.A7, new Dictionary<Coordinate, Line> { { Coordinate.A4, Line.Row }, { Coordinate.B6, Line.Diagonal }, { Coordinate.D7, Line.Column } } },
                { Coordinate.B2, new Dictionary<Coordinate, Line> { { Coordinate.A1, Line.Diagonal }, { Coordinate.B4, Line.Row }, { Coordinate.C3, Line.Diagonal }, { Coordinate.D2, Line.Column } } },
                { Coordinate.B4, new Dictionary<Coordinate, Line> { { Coordinate.A4, Line.Column }, { Coordinate.B2, Line.Row }, { Coordinate.B6, Line.Row }, { Coordinate.C4, Line.Column } } },
                { Coordinate.B6, new Dictionary<Coordinate, Line> { { Coordinate.A7, Line.Diagonal }, { Coordinate.B4, Line.Row }, { Coordinate.C5, Line.Diagonal }, { Coordinate.D6, Line.Column } } },
                { Coordinate.C3, new Dictionary<Coordinate, Line> { { Coordinate.B2, Line.Diagonal }, { Coordinate.C4, Line.Row }, { Coordinate.D3, Line.Column } } },
                { Coordinate.C4, new Dictionary<Coordinate, Line> { { Coordinate.B4, Line.Column }, { Coordinate.C3, Line.Row }, { Coordinate.C5, Line.Row } } },
                { Coordinate.C5, new Dictionary<Coordinate, Line> { { Coordinate.B6, Line.Diagonal }, { Coordinate.C4, Line.Row }, { Coordinate.D5, Line.Column } } },
                { Coordinate.D1, new Dictionary<Coordinate, Line> { { Coordinate.A1, Line.Column }, { Coordinate.D2, Line.Row }, { Coordinate.G1, Line.Column } } },
                { Coordinate.D2, new Dictionary<Coordinate, Line> { { Coordinate.B2, Line.Column }, { Coordinate.D1, Line.Row }, { Coordinate.D3, Line.Row }, { Coordinate.F2, Line.Column } } },
                { Coordinate.D3, new Dictionary<Coordinate, Line> { { Coordinate.C3, Line.Column }, { Coordinate.D2, Line.Row }, { Coordinate.E3, Line.Column } } },
                { Coordinate.D5, new Dictionary<Coordinate, Line> { { Coordinate.C5, Line.Column }, { Coordinate.D6, Line.Row }, { Coordinate.E5, Line.Column } } },
                { Coordinate.D6, new Dictionary<Coordinate, Line> { { Coordinate.B6, Line.Column }, { Coordinate.D5, Line.Row }, { Coordinate.D7, Line.Row }, { Coordinate.F6, Line.Column } } },
                { Coordinate.D7, new Dictionary<Coordinate, Line> { { Coordinate.A7, Line.Column }, { Coordinate.D6, Line.Row }, { Coordinate.G7, Line.Column } } },
                { Coordinate.E3, new Dictionary<Coordinate, Line> { { Coordinate.D3, Line.Column }, { Coordinate.E4, Line.Row }, { Coordinate.F2, Line.Diagonal } } },
                { Coordinate.E4, new Dictionary<Coordinate, Line> { { Coordinate.E3, Line.Row }, { Coordinate.E5, Line.Row }, { Coordinate.F4, Line.Column } } },
                { Coordinate.E5, new Dictionary<Coordinate, Line> { { Coordinate.D5, Line.Column }, { Coordinate.E4, Line.Row }, { Coordinate.F6, Line.Diagonal } } },
                { Coordinate.F2, new Dictionary<Coordinate, Line> { { Coordinate.D2, Line.Column }, { Coordinate.E3, Line.Diagonal }, { Coordinate.F4, Line.Row }, { Coordinate.G1, Line.Diagonal } } },
                { Coordinate.F4, new Dictionary<Coordinate, Line> { { Coordinate.E4, Line.Column }, { Coordinate.F2, Line.Row }, { Coordinate.F6, Line.Row }, { Coordinate.G4, Line.Column } } },
                { Coordinate.F6, new Dictionary<Coordinate, Line> { { Coordinate.D6, Line.Column }, { Coordinate.E5, Line.Diagonal }, { Coordinate.F4, Line.Row }, { Coordinate.G7, Line.Diagonal } } },
                { Coordinate.G1, new Dictionary<Coordinate, Line> { { Coordinate.D1, Line.Column }, { Coordinate.F2, Line.Diagonal }, { Coordinate.G4, Line.Row } } },
                { Coordinate.G4, new Dictionary<Coordinate, Line> { { Coordinate.F4, Line.Column }, { Coordinate.G1, Line.Row }, { Coordinate.G7, Line.Row } } },
                { Coordinate.G7, new Dictionary<Coordinate, Line> { { Coordinate.D7, Line.Column }, { Coordinate.F6, Line.Diagonal }, { Coordinate.G4, Line.Row } } }
            };
        }        
        private bool Adjacent(Coordinate a, Coordinate b, out Line line)
        {
            if (_coordinates[a].ContainsKey(b))
            {
                line = _coordinates[a][b];
                return true;
            }
            line = Line.Row;
            return false;
        }
        
        public bool Adjacent(Coordinate a, Coordinate b)
        {
            return Adjacent(a, b, out Line _);
        }

        public bool AllCoordinatesOccupied => _occupations.Count == _coordinates.Count;

        public void Place(Coordinate coordinate, Colour cow)
        {
            if (IsOccupied(coordinate))
                throw new InvalidOperationException();
            _occupations[coordinate] = cow;
        }

        public void Displace(Coordinate coordinate)
        {
            if (!IsOccupied(coordinate))
                throw new InvalidOperationException();
            _occupations.Remove(coordinate);
        }

        private List<Coordinate> Neighbours(Coordinate coordinate)
        {
            return _coordinates[coordinate]
                .Select(i => i.Key)
                .ToList();
        }

        private List<List<Coordinate>> Lines(Coordinate coordinate)
        {
            var neighbours = Neighbours(coordinate);
            var neighboursNeighbours =
                neighbours
                    .Select(Neighbours)
                    .Select(xs => 
                        xs
                            .Where(x => x != coordinate)
                            .ToList())
                    .ToList();
            var lines = new List<List<Coordinate>>();
            for (var i = 0; i < neighbours.Count; i++)
            {
                var neighbour = neighbours[i];
                for (var j = 0; j < neighboursNeighbours[i].Count; j++)
                {
                    var neighboursNeighbour = neighboursNeighbours[i][j];
                    var line1 = _coordinates[coordinate][neighbour];
                    var line2 = _coordinates[neighbour][neighboursNeighbour];
                    if (line1 == line2)
                        lines.Add(new List<Coordinate>() { coordinate, neighbour, neighboursNeighbour });
                }
            }
            return lines;
        }
        
        public bool InAMill(Coordinate coordinate)
        {
            var mills = Mills(coordinate);
            var inAMill = mills != null && mills.Length >= 1;
            return inAMill;
        }

        public bool InAMill(Colour player)
        {
            return _occupations.
                Any(occupation => 
                    occupation.Value == player && 
                    InAMill(occupation.Key));
        }

        public bool AllInAMill(Colour player)
        {
            var cows =
                _occupations
                    .Where(x => x.Value == player)
                    .Select(x => x.Key)
                    .ToArray();
            var inAMill =
                    cows
                        .Where(InAMill)
                        .ToArray();
            return inAMill.Length == cows.Length;
        }

        public bool CanMove(Colour player)
        {
            return
                _occupations
                    .Where(occupant => occupant.Value == player)
                    .Select(occupant => occupant.Key)
                    .Select(Neighbours)
                    .SelectMany(i => i)
                    .Where(IsOccupied)
                    .Any();
        }

        public bool IsOccupied(Coordinate coordinate)
        {
            return _occupations.ContainsKey(coordinate);
        }

        public Colour Occupant(Coordinate coordinate)
        {
            return _occupations[coordinate];
        }
        
        // There is duplication in this method. The duplication is used in other methods.
        public Coordinate[][] Mills(Coordinate coordinate)
        {
            if (!IsOccupied(coordinate))
                throw new InvalidOperationException();
            var occupant = Occupant(coordinate);
            var mills =
                Lines(coordinate)
                    .Where(line =>
                        IsOccupied(line[0]) && occupant == Occupant(line[0]) &&
                        IsOccupied(line[1]) && occupant == Occupant(line[1]) &&
                        IsOccupied(line[2]) && occupant == Occupant(line[2]))
                    .Select(line => line.ToArray())
                    .ToArray();
            return mills;
        }

        // WITHOUT DUPLICATES
        public Coordinate[][] Mills(Colour player)
        {
            var millList = _occupations
                .Where(occupation => occupation.Value == player)
                .Where(occupation => InAMill(occupation.Key))
                .Select(occupation => 
                    Mills(occupation.Key))
                .ToList();
            var x = millList
                .SelectMany(i => i)
                .ToArray();
            return x;
        }

        private class MillEquality : IEqualityComparer<Coordinate[]>
        {
            public bool Equals(Coordinate[] mill1, Coordinate[] mill2)
            {
                var m1 = mill1.ToList();
                var m2 = mill2.ToList();
                m1.Sort();
                m2.Sort();
                mill1 = m1.ToArray();
                mill2 = m2.ToArray();
                if (mill1.Length != mill2.Length)
                    throw new InvalidOperationException();
                for (var i = 0; i < 3; i++)
                    if (mill1[i] != mill2[i])
                        return false;
                return true;
            }

            public int GetHashCode(Coordinate[] obj)
            {
                return base.GetHashCode();
            }
        }

        public bool AreMillsDifferent(Coordinate[][] mills1, Coordinate[][] mills2)
        {
            if (mills1 == null && mills2 == null)
                return false;
            if (mills1 == null || mills2 == null)
                return true;
            var equality = new MillEquality();
            var intersection = mills1.
                Intersect(mills2, equality).
                Distinct(equality).
                ToArray();
            var union = mills1.
                Union(mills2, equality).
                Distinct(equality).
                ToArray();
            return union.Length != intersection.Length;
        }

        private char OccupantChar(Coordinate coordinate)
        {
            if (!_occupations.ContainsKey(coordinate))
                return 'o';
            switch (_occupations[coordinate])
            {
                case Colour.Dark:
                    return 'D';
                default:
                    return 'L';
            }
        }

        public override string ToString()
        {
            return
            $@"
                                                                    1   2   3   4   5   6   7
                                                                A   {OccupantChar(Coordinate.A1)}-----------{OccupantChar(Coordinate.A4)}-----------{OccupantChar(Coordinate.A7)}
                                                                    | \         |         / |
                                                                B   |   {OccupantChar(Coordinate.B2)}-------{OccupantChar(Coordinate.B4)}-------{OccupantChar(Coordinate.B6)}   |
                                                                    |   | \     |     / |   |
                                                                C   |   |   {OccupantChar(Coordinate.C3)}---{OccupantChar(Coordinate.C4)}---{OccupantChar(Coordinate.C5)}   |   |
                                                                    |   |   |       |   |   |
                                                                D   {OccupantChar(Coordinate.D1)}---{OccupantChar(Coordinate.D2)}---{OccupantChar(Coordinate.D3)}       {OccupantChar(Coordinate.D5)}---{OccupantChar(Coordinate.D6)}---{OccupantChar(Coordinate.D7)}
                                                                    |   |   |       |   |   |
                                                                E   |   |   {OccupantChar(Coordinate.E3)}---{OccupantChar(Coordinate.E4)}---{OccupantChar(Coordinate.E5)}   |   |
                                                                    |   | /     |     \ |   |
                                                                F   |   {OccupantChar(Coordinate.F2)}-------{OccupantChar(Coordinate.F4)}-------{OccupantChar(Coordinate.F6)}   |
                                                                    | /         |         \ |
                                                                G   {OccupantChar(Coordinate.G1)}-----------{OccupantChar(Coordinate.G4)}-----------{OccupantChar(Coordinate.G7)}
            ";
}
    }
}