using System;
using System.Collections.Generic;
using System.Linq;
using Codes.day9;

namespace Codes.day11
{
    public class SpacePolice
    {
        public IntCodeComputer Computer;
        public List<Node> Nodes;
        public Robot Robot;

        public SpacePolice(IntCodeComputer computer)
        {
            Computer = computer;
            Nodes = new List<Node>();
            Robot = new Robot();
        }

        public int Run()
        {
            Core();
            return Nodes.Count;
        }

        public int[,] DisplayNode()
        {
            var maxX = Nodes.Max(n => n.X);
            var maxY = Nodes.Max(n => n.Y);
            var minX = Nodes.Min(n => n.X);
            var minY = Nodes.Min(n => n.Y);

            var arr = new int[maxY - minY + 1, maxX - minX + 1];
            foreach (var node in Nodes) arr[-node.Y, node.X + minX] = node.IsWhite ? 1 : 0;

            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++) Console.Out.Write(arr[i, j] == 1 ? "#" : ".");
                Console.Out.Write("\n");
            }

            return arr;
        }

        public void Core()
        {
            while (!Computer.IsHalted)
            {
                var tmpNode = new Node(Robot.X, Robot.Y);
                var node = FindNode(Nodes, tmpNode);
                if (node is null)
                {
                    Nodes.Add(tmpNode);
                    node = tmpNode;
                }

                Computer.AddInput(node.IsWhite ? 1 : 0);
                Computer.Continue();

                var colorToPaint = (int) Computer.GetOutput();
                node.IsWhite = colorToPaint == 1;

                var directionToTurn = (int) Computer.GetOutput();
                Robot.Move(directionToTurn);

                node.Visited = true;
            }
        }

        public static Node FindNode(List<Node> nodes, Node node)
        {
            return nodes.Find(n => n.X == node.X && n.Y == node.Y);
        }
    }
}