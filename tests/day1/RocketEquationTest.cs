using Codes.day1;
using NUnit.Framework;

namespace tests.day1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFuel()
        {
            var mass = 14;

            var fuel = RocketEquation.Fuel(mass);

            Assert.AreEqual(2, fuel);
        }
    }
}