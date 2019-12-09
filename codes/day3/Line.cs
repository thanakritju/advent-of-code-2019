using System;
using System.Collections.Generic;

namespace Codes.day3
{
    public class Line
    {
        public readonly Point P1;
        public readonly Point P2;

        public Line(Point p1, Point p2)
        {
            P1 = p1;
            P2 = p2;
        }

        public int Length()
        {
            var point = P1 - P2;
            return (int) Math.Sqrt(point.X * point.X + point.Y + point.Y);
        }

        private bool IsVertical()
        {
            return P1.X == P2.X;
        }

        private bool IsHorizontal()
        {
            return P1.Y == P2.Y;
        }

        public IEnumerable<Point> GetAllPoints()
        {
            var points = new HashSet<Point>();
            if (IsVertical())
            {
                for (var i = 0; i <= Math.Abs(P1.Y - P2.Y); i++)
                {
                    points.Add(new Point(P1.X, Math.Min(P1.Y, P2.Y) + i));
                }
            }else if (IsHorizontal())
            {
                for (var i = 0; i <= Math.Abs(P1.X - P2.X); i++)
                {
                    points.Add(new Point(Math.Min(P1.X, P2.X) + i, P1.Y));
                }
            }
            return points;
        }
    }
}