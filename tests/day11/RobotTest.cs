using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Codes.day10;
using Codes.day11;
using NUnit.Framework;

namespace Tests.day11
{
    public class RobotTest
    {
        [Test]
        public void TestRobotShouldMove()
        {
            var robot = new Robot();
        }
        
        [Test]
        public void TestNodeEquality()
        {
            var node1 = new Node(1,2);
            var node2 = new Node(1,2);
            
            Assert.AreEqual(true, node1.Equals(node2));
        }
        
        [TestCase(2, 3, (int) Directions.North, 3, 3, (int) Directions.East)]
        [TestCase(2, 3, (int) Directions.West, 2, 4, (int) Directions.North)]
        [TestCase(2, 3, (int) Directions.South, 1, 3, (int) Directions.West)]
        [TestCase(2, 3, (int) Directions.East, 2, 2, (int) Directions.South)]
        public void TestRobotMoveRight(int x1, int y1, int direction1, int x2, int y2, int direction2)
        {
            var robot = new Robot(x1, y1, direction1);

            robot.Move(1);
            
            Assert.AreEqual(x2, robot.X, "Position X");
            Assert.AreEqual(y2, robot.Y, "Position Y");
            Assert.AreEqual(direction2, robot.Direction, "Direction");
        }
        
        [TestCase(2, 3, (int) Directions.North, 1, 3, (int) Directions.West)]
        [TestCase(2, 3, (int) Directions.West, 2, 2, (int) Directions.South)]
        [TestCase(2, 3, (int) Directions.South, 3, 3, (int) Directions.East)]
        [TestCase(2, 3, (int) Directions.East, 2, 4, (int) Directions.North)]
        public void TestRobotMoveLeft(int x1, int y1, int direction1, int x2, int y2, int direction2)
        {
            var robot = new Robot(x1, y1, direction1);

            robot.Move(0);
            
            Assert.AreEqual(x2, robot.X, "Position X");
            Assert.AreEqual(y2, robot.Y, "Position Y");
            Assert.AreEqual(direction2, robot.Direction, "Direction");
        }

        [Test]
        public void TestListGet()
        {
            var nodes = new List<Node>();
            var node1 = new Node(1,2);
            nodes.Add(node1);
            var node2 = new Node(1,2);
            
            var output = SpacePolice.FindNode(nodes, node2);
            
            Assert.AreEqual(node1, output);
        }
    }
}