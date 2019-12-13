using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Codes.day3
{
    public class CrossedWires
    {
        public static bool IsInPoints(List<Point> points, Point point)
        {
            foreach (var p in points)
                if (p.X == point.X && p.Y == point.Y)
                    return true;

            return false;
        }

        public static int GetDistanceFromOrigin(Point point, List<Line> lines, Line latestLine = null)
        {
            Line remainingLine;
            var distance = 0;
            foreach (var line in lines)
            {
                if (latestLine != null && line == latestLine)
                {
                    remainingLine = new Line(latestLine.P1, point);
                    distance += remainingLine.Length();
                    return distance;
                }

                distance += line.Length();
            }

            var lastLine = lines.Last();
            remainingLine = new Line(lastLine.P2, point);
            distance += remainingLine.Length();
            return distance;
        }

        public static Point Move(Point start, string command)
        {
            var m = new Regex("(R|D|U|L)(\\d+)").Match(command);
            var direction = m.Groups[1].Value;
            var value = int.Parse(m.Groups[2].Value);
            if (direction.Equals("U")) return new Point(start.X, start.Y + value);
            if (direction.Equals("D")) return new Point(start.X, start.Y - value);
            if (direction.Equals("L")) return new Point(start.X - value, start.Y);
            if (direction.Equals("R")) return new Point(start.X + value, start.Y);

            throw new Exception("Unknown command");
        }
    }
}