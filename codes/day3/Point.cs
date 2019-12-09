namespace Codes.day3
{
    public partial class Point
    {
        public int x { get; set; }
        public int y { get; set; }

        public Point(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public int GetDistanceFromOrigin()
        {
            return x + y;
        }
    }
}