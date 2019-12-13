using System;
using System.IO;
using Codes.day10;
using NUnit.Framework;

namespace Tests.day10
{
    public class RunnerTests
    {
        private string _testInput;
        
        [SetUp]
        public void Setup()
        {
            _testInput = File.ReadAllText(@"../../../../codes/day10/asteroids.txt");
        }

        [Test]
        public void TestPart1()
        {
            var output = Runner.RunPart1(_testInput);
            
            Assert.AreEqual(292, output);
        }
        
        [Test]
        public void TestPart2()
        {
            var output = Runner.RunPart2(_testInput, 200);
            
            Assert.AreEqual(Tuple.Create(3, 17), output);
        }
    }
}