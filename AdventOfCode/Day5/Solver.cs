﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day5
{
    class Solver
    {
        internal int Solve()
        {
            var parser = new InputParser();
            var input = parser.Parse();
            var seatIds = new List<int>();

            foreach (var item in input)
            {
                var rowChars = item.Substring(0, 7);
                var seatRow = ComputeSeatRow(rowChars);

                var columnChars = item.Substring(7);
                var seatColumn = ComputeSeatColumn(columnChars);

                var seatId = ComputeSeatId(seatRow, seatColumn);
                seatIds.Add(seatId);
            }

            return seatIds.Max();
        }

        internal int Solve2()
        {
            var parser = new InputParser();
            var input = parser.Parse();

            return 0;
        }

        internal int ComputeSeatRow(string rowChars)
        {
            var max = 128;
            var min = 0;

            foreach (var character in rowChars)
            {
                var increment = (max - min) / 2;

                if (character.Equals('F'))
                    max -= increment;
               
                if (character.Equals('B'))
                    min += increment;
            }

            return min;
        }

        internal int ComputeSeatColumn(string columnChars)
        {
            var max = 8;
            var min = 0;

            foreach (var character in columnChars)
            {
                var increment = (max - min) / 2;

                if (character.Equals('L'))
                    max -= increment;

                if (character.Equals('R'))
                    min += increment;
            }

            return min;
        }

        internal int ComputeSeatId(int row, int column)
        {
            return row * 8 + column;
        }
    }
}
