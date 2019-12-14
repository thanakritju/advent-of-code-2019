using Codes.day7;
using NUnit.Framework;

namespace Tests.day7
{
    public class AmplificationCircuitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new[] {3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0}, 43210)]
        [TestCase(new[]
        {
            3, 23, 3, 24, 1002, 24, 10, 24, 1002, 23, -1, 23,
            101, 5, 23, 23, 1, 24, 23, 23, 4, 23, 99, 0, 0
        }, 54321)]
        [TestCase(new[]
        {
            3, 31, 3, 32, 1002, 32, 10, 32, 1001, 31, -2, 31, 1007, 31, 0, 33,
            1002, 33, 7, 33, 1, 33, 31, 31, 1, 32, 31, 31, 4, 31, 99, 0, 0, 0
        }, 65210)]
        public void TestAmplificationCircuit(int[] program, int expected)
        {
            var output = AmplificationCircuit.FindMaxThrust(program, new[] {0, 1, 2, 3, 4});

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestDay7Part1()
        {
            var output = Runner.SolveDay7Part1();

            Assert.AreEqual(45730, output);
        }
    }
}