using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Codes.day3;

namespace Codes.day3
{
    public class Runner
    {
        public static int RunPart1(string[] wire1, string[] wire2)
        {
            Point start = new Point();
            var lines = new List<Line>();
            foreach (var command in wire1)
            {
                var end = CrossedWires.Move(start, command);
                lines.Add(new Line(start, end));
                start = end;
            }

            start = new Point();
            var distances = new List<int>();
            foreach (var command in wire2)
            {
                var end = CrossedWires.Move(start, command);
                var tmpLine = new Line(start, end);
                foreach (var line in lines)
                {
                    try
                    {
                        var point = line.IntersectWith(tmpLine);

                        distances.Add(point.GetDistanceFromOrigin());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }

                start = end;
            }

            distances.Remove(0);

            return distances.Min();
        }

        public static int RunPart2(string[] wire1, string[] wire2)
        {
            Point start = new Point();
            var lines1 = new List<Line>();
            foreach (var command in wire1)
            {
                var end = CrossedWires.Move(start, command);
                lines1.Add(new Line(start, end));
                start = end;
            }

            start = new Point();
            var lines2 = new List<Line>();
            var distances = new List<int>();
            var points = new List<Point>();
            foreach (var command in wire2)
            {
                var end = CrossedWires.Move(start, command);
                var line2 = new Line(start, end);
                foreach (var line1 in lines1)
                {
                    try
                    {
                        var point = line1.IntersectWith(line2);
                        if (CrossedWires.IsInPoints(points, point))
                        {
                            continue;
                        }

                        points.Add(point);
                        distances.Add(
                            CrossedWires.GetDistanceFromOrigin(point, lines2) +
                            CrossedWires.GetDistanceFromOrigin(point, lines1, line1)
                        );
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }

                lines2.Add(line2);
                start = end;
            }

            distances.Remove(0);
            return distances.Min();
        }

        public static int SolvePart1()
        {
            var wires = _GetWires();

            return RunPart1(wires.Item1, wires.Item2);
        }

        public static double SolvePart2()
        {
            var wires = _GetWires();

            return RunPart2(wires.Item1, wires.Item2);
        }

        private static Tuple<string[], string[]> _GetWires()
        {
            var fileContent = File.ReadAllText(@"../../../../codes/day3/wires.txt");

            var wires = fileContent.Split(new[] {' ', '\t', '\r', '\n'},
                StringSplitOptions.RemoveEmptyEntries);

            var firstWire = wires[0].Split(",", StringSplitOptions.RemoveEmptyEntries);
            var secondWire = wires[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

            return Tuple.Create(firstWire, secondWire);
        }
    }
}