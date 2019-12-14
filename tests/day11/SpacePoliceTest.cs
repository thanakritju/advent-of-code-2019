using System;
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
        public void TestSimpleRun()
        {
            _computer.AddInput(0);
            _computer.AddInput(1);
            _computer.Continue();
            
            Assert.AreEqual(1, _computer.OutputData);
        }
    }
}