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
        
        [Test]
        public void TestFuelRecursive()
        {
            var mass = 100756;

            var fuel = RocketEquation.FuelRecursive(mass);

            Assert.AreEqual(50346, fuel);
        }
        
        [Test]
        public void TestPart1()
        {
            var fuels = RocketEquation.SolvePart1();

            Assert.AreEqual(3266516, fuels);
        }
        
        [Test]
        public void TestPart2()
        {
            var fuels = RocketEquation.SolvePart2();

            Assert.AreEqual(4896902, fuels);
        }
        
    }
}