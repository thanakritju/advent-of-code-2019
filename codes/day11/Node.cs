using System;

namespace Codes.day11
{
    public class Node : IEquatable<Node>
    {
        public bool IsWhite;
        public bool Visited;
        public int X;
        public int Y;

        public Node(int x, int y)
        {
            X = x;
            Y = y;
            IsWhite = false;
            Visited = false;
        }

        public bool Equals(Node node)
        {
            return node != null && X == node.X && Y == node.Y;
        }
    }
}