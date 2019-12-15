using Codes.day12;
using NUnit.Framework;

namespace Tests.day12
{
    public class NBodyProblemTest
    {
        private MoonSystem _system;

        [SetUp]
        public void SetUp()
        {
            var moon1 = new Moon {Name = "Io", X = -1, Y = 0, Z = 2};
            var moon2 = new Moon {Name = "Europa", X = 2, Y = -10, Z = -7};
            var moon3 = new Moon {Name = "Ganymede", X = 4, Y = -8, Z = 8};
            var moon4 = new Moon {Name = "Callisto", X = 3, Y = 5, Z = -1};

            _system = new MoonSystem();
            _system.AddMoon(moon1);
            _system.AddMoon(moon2);
            _system.AddMoon(moon3);
            _system.AddMoon(moon4);
        }

        [Test]
        public void TestMoonShouldInitObject()
        {
            var moon = new Moon {Name = "Io", X = 5, Y = 7, Z = 9};

            Assert.AreEqual(0, moon.Vx);
            Assert.AreEqual(0, moon.Vy);
            Assert.AreEqual(0, moon.Vz);
        }

        [Test]
        public void TestUpdateVelocities()
        {
            var moon1 = new Moon {Name = "Io", X = -1, Y = 0, Z = 2};
            moon1.Vx = 2;
            moon1.Vy = 3;
            moon1.Vz = 4;

            var outputMoon = moon1.UpdatePosition();

            Assert.AreEqual(1, outputMoon.X);
            Assert.AreEqual(3, outputMoon.Y);
            Assert.AreEqual(6, outputMoon.Z);
        }


        [TestCase(10, 179)]
        public void TestTotalEnergyOfSystemForEachStep(int step, int expected)
        {
            var output = _system.CalculateTotalEnergy(step);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestDay12Part1()
        {
            var moon1 = new Moon {Name = "Io", X = -10, Y = -13, Z = 7};
            var moon2 = new Moon {Name = "Europa", X = 1, Y = 2, Z = 1};
            var moon3 = new Moon {Name = "Ganymede", X = -15, Y = -3, Z = 13};
            var moon4 = new Moon {Name = "Callisto", X = 3, Y = 7, Z = -4};

            var system = new MoonSystem();
            system.AddMoon(moon1);
            system.AddMoon(moon2);
            system.AddMoon(moon3);
            system.AddMoon(moon4);

            var output = system.CalculateTotalEnergy(1000);

            Assert.AreEqual(8454, output);
        }
    }
}