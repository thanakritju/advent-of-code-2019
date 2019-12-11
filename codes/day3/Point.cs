using System;

namespace Codes.day3
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public static Point operator- (Point p1, Point p2)
        {
            var point = new Point {X = p2.X - p1.X, Y = p2.Y - p1.Y};
            return point;
        }
        
        public static Point operator+ (Point p1, Point p2)
        {
            var point = new Point {X = p2.X + p1.X, Y = p2.Y + p2.Y};
            return point;
        }

        public int GetDistanceFromOrigin()
        {
            return Math.Abs(X) + Math.Abs(Y);
        }
    }
}