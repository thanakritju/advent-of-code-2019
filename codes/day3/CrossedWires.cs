using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Codes.day3
{
    public class CrossedWires
    {
        public static int Run(string[] wire1, string[] wire2)
        {
            Point start = new Point();
            var lines = new List<Line>();
            foreach (var command in wire1)
            {
                var end = _Move(start, command);
                lines.Add(new Line(start, end));
                start = end;
            }
            
            start = new Point();
            var distances = new List<int>();
            foreach (var command in wire2)
            {
                var end = _Move(start, command);
                var line = new Line(start, end);
                foreach (var firstLine in lines)
                {
                    try
                    {
                        var intersect = GetIntersect(line.P1, line.P2, firstLine.P1, firstLine.P2);
                        distances.Add(intersect.GetDistanceFromOrigin());
                    }
                    catch (Exception)
                    {
                        // Ignore
                    }
                }
                start = end;
            }

            distances.Remove(0);

            return distances.Min();
        }

        private static Point _Move(Point start, string command)
        {
            var m = new Regex("(R|D|U|L)(\\d+)").Match(command);
            string direction = m.Groups[1].Value;
            int value = int.Parse(m.Groups[2].Value);
            if (direction.Equals("U"))
            {
                return new Point(start.X, start.Y + value);
            }
            if (direction.Equals("D"))
            {
                return new Point(start.X, start.Y - value);
            }
            if (direction.Equals("L"))
            {
                return new Point(start.X - value, start.Y);
            }
            if (direction.Equals("R"))
            {
                return new Point(start.X + value, start.Y);
            }

            throw new Exception("Unknown command");
        }
        
        public static bool IsIntersect(Point p1, Point p2, Point p3, Point p4)
        {
            try
            {
                GetIntersect(p1, p2, p3, p4);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Point GetIntersect(Point p1, Point p2, Point p3, Point p4)
        {
            var line1 = new Line(p1, p2);
            var line2 = new Line(p3, p4);
            var set1 = line1.GetAllPoints();
            var set2 = line2.GetAllPoints();

            foreach (var pi in set1)
            {
                foreach (var pj in set2)
                {
                    if (pi.X == pj.X && pi.Y == pj.Y)
                    {
                        return new Point(pi.X, pi.Y);
                    }
                }
            }
            throw new Exception("Not intersect");
        }

        public static int SolvePart1()
        {
            var wires = _GetWires();
            
            return Run(wires.Item1, wires.Item2);
        }

        public static double SolvePart2()
        {
            throw new System.NotImplementedException();
        }

        private static Tuple<string[], string[]> _GetWires()
        {
            var fileContent = File.ReadAllText(@"../../../../codes/day3/wires.txt");

            var wires = fileContent.Split(new[] { ' ', '\t', '\r', '\n' }, 
                StringSplitOptions.RemoveEmptyEntries);

            var firstWire = wires[0].Split(",", StringSplitOptions.RemoveEmptyEntries);
            var secondWire = wires[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

            return Tuple.Create(firstWire, secondWire);
        }
    }
}