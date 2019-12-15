using Codes.day11;
using Codes.day9;
using NUnit.Framework;

namespace Tests.day11
{
    public class SpacePoliceTest
    {
        private IntCodeComputer _computer;

        [SetUp]
        public void Setup()
        {
            _computer = new IntCodeComputer();
            var brain = Runner.GetIntCodes(@"../../../../codes/day11/brain.txt");
            _computer.Run(brain);
        }

        [Test]
        public void TestDay11Part1()
        {
            var spacePolice = new SpacePolice(_computer);

            var output = spacePolice.Run();

            Assert.AreEqual(1709, output);
        }

        [Test]
        public void TestDay11Part2()
        {
            var spacePolice = new SpacePolice(_computer);
            var node = new Node(0, 0) {IsWhite = true};
            spacePolice.Nodes.Add(node);

            spacePolice.Core();

            spacePolice.DisplayNode();
        }
    }
}