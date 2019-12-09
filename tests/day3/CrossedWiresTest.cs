using Codes.day3;
using NUnit.Framework;

namespace Tests.day3
{
    public class CrossedWiresTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new[]{1, 1, 4, 1, 2, 2, 2, 0}, true)]
        [TestCase(new[]{1, 1, 4, 1, 5, 2, 5, 0}, false)]
        [TestCase(new[]{1, 1, 4, 1, 4, 2, 4, 1}, true)]
        public void TestIsIntersect(int[] points, bool expected)
        {
            var p1 = new Point(points[0], points[1]);
            var p2 = new Point(points[2], points[3]);
            var p3 = new Point(points[4], points[5]);
            var p4 = new Point(points[6], points[7]);

            var isIntersect = CrossedWires.IsIntersect(p1, p2, p3, p4);
            
            Assert.AreEqual(expected, isIntersect);
        }

        [TestCase(new[] {"R8","U5","L5","D3"}, new[] {"U7","R6","D4","L4"}, 6)]
        [TestCase(
            new[] {"R75","D30","R83","U83","L12","D49","R71","U7","L72"}, 
            new[] {"U62","R66","U55","R34","D71","R55","D58","R83"}, 
            159)]
        [TestCase(
            new[] {"R98","U47","R26","D63","R33","U87","L62","D20","R33","U53","R5"}, 
            new[] {"U98","R91","D20","R16","D67","R40","U7","R15","U6","R7"}, 
            135)]
        public void TestRun(string[] wire1,string[] wire2, int expected)
        {
            var distance = CrossedWires.Run(wire1, wire2);

            Assert.AreEqual(expected, distance);
        }
        
        [Ignore("Last time ran with 7 minutes LUL")]
        [Test]
        public void TestPart1()
        {
            var output = CrossedWires.SolvePart1();

            Assert.AreEqual(5319, output);
        }
        
        [Test]
        public void TestPart2()
        {
            var output = CrossedWires.SolvePart2();

            Assert.AreEqual(122514, output);
        }
    }
}