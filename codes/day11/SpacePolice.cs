using System;
using System.Collections.Generic;
using Codes.day9;
using Runner = Codes.day10.Runner;

namespace Codes.day11
{
    public class SpacePolice
    {
        public List<Node> Nodes;
        public Robot Robot;
        public IntCodeComputer Computer;
        
        public SpacePolice(IntCodeComputer computer)
        {
            Computer = computer;
            Nodes = new List<Node>();
            Robot = new Robot();
        }

        public int Run()
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

            return Nodes.Count;
        }

        public static Node FindNode(List<Node> nodes, Node node)
        {
            return nodes.Find(n => n.X == node.X && n.Y == node.Y);
        }
    }
}