using Codes.day5;
using Codes.day2;
using NUnit.Framework;

namespace Tests.day5
{
    public class ProgramAlarmTests
    {
        private IntCodeComputer _computer;

        [SetUp]
        public void Setup()
        {;
            _computer = new IntCodeComputer();
        }

        [TestCase(new[] {1, 0, 0, 0, 99}, new[] {2, 0, 0, 0, 99})]
        [TestCase(new[] {2, 3, 0, 3, 99}, new[] {2, 3, 0, 6, 99})]
        [TestCase(new[] {2, 4, 4, 5, 99, 0}, new[] {2, 4, 4, 5, 99, 9801})]
        [TestCase(new[] {1, 1, 1, 4, 99, 5, 6, 0, 99}, new[] {30, 1, 1, 4, 2, 5, 6, 0, 99})]
        public void TestRun(int[] program, int[] expectedProgram)
        {
            var outputProgram = _computer.Run(program);

            Assert.AreEqual(expectedProgram, outputProgram);
        }


        [Test]
        public void TestDay2Part1()
        {
            var output = Runner.SolveDay2Part1(12, 2);

            Assert.AreEqual(7210630, output);
        }

        [Test]
        public void TestDay2Part2()
        {
            var target = 19690720;

            var output = Runner.SolveDay2Part2(target);

            Assert.AreEqual(3892, output);
        }
    }
}