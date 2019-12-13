using System;

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
            return Math.Abs(point.X == 0 ? point.Y : point.X);
        }

        public bool IsVertical()
        {
            return P1.X == P2.X;
        }

        public bool IsHorizontal()
        {
            return P1.Y == P2.Y;
        }

        public Point IntersectWith(Line line)
        {
            if (IsHorizontal())
            {
                if (line.IsHorizontal() || line.P1.X > Math.Max(P1.X, P2.X) || line.P1.X < Math.Min(P1.X, P2.X)
                    || P1.Y > Math.Max(line.P1.Y, line.P2.Y) || P1.Y < Math.Min(line.P1.Y, line.P2.Y))
                    throw new Exception("Not intersect");
                return new Point(line.P1.X, P1.Y);
            }

            if (line.IsVertical() || line.P1.Y > Math.Max(P1.Y, P2.Y) || line.P1.Y < Math.Min(P1.Y, P2.Y)
                || P1.X > Math.Max(line.P1.X, line.P2.X) || P1.X < Math.Min(line.P1.X, line.P2.X))
                throw new Exception("Not intersect");
            return new Point(P1.X, line.P1.Y);
        }
    }
}