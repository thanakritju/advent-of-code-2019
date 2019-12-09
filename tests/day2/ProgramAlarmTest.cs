using Codes.day2;
using NUnit.Framework;

namespace Tests.day2
{
    public class ProgramAlarmTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new[] {1, 0, 0, 0, 99}, new[] {2, 0, 0, 0, 99})]
        [TestCase(new[] {2,3,0,3,99}, new[] {2,3,0,6,99})]
        [TestCase(new[] {2,4,4,5,99,0}, new[] {2,4,4,5,99,9801})]
        [TestCase(new[] {1,1,1,4,99,5,6,0,99}, new[] {30,1,1,4,2,5,6,0,99})]
        public void TestRun(int[] program, int[] expectedProgram)
        {
            var outputProgram = ProgramAlarm.Run(program);

            Assert.AreEqual(expectedProgram, outputProgram);
        }
    }
}