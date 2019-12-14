using System;
using System.Linq;
using Codes.day9;
using NUnit.Framework;

namespace Tests.day9
{
    public class SensorBoostTest
    {
        private IntCodeComputer _computer;

        [SetUp]
        public void Setup()
        {
            _computer = new IntCodeComputer();
        }

        [TestCase(new long[] {109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99}, 99)]
        [TestCase(new long[] {1102, 34915192, 34915192, 7, 4, 7, 99, 0}, 1219070632396864)]
        [TestCase(new[] {104, 1125899906842624, 99}, 1125899906842624)]
        public void TestRun(long[] program, long expected)
        {
            _computer.Run(program);

            Assert.AreEqual(expected, _computer.OutputData.Last());
        }

        [Test]
        public void TestDay9Part1()
        {
            var output = Runner.SolveDay9Part1(1);
            
            Assert.AreEqual(0, output);
        }
    }
}