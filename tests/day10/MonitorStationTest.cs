using System;
using System.Collections.Generic;
using Codes.day10;
using NUnit.Framework;

namespace Tests.day10
{
    public class MonitorStationTests
    {
        private string _testInput;
        
        [SetUp]
        public void Setup()
        {
            _testInput = @".#..#
                           .....
                           #####
                           ....#
                           ...##";
        }
        
        [Test]
        public void TestParseStation()
        {
            List<Tuple<int, int>> field = MonitorStation.Parse(_testInput);

            var expected = new List<Tuple<int, int>> { 
                Tuple.Create(1, 0), 
                Tuple.Create(4, 0), 
                Tuple.Create(0, 2), 
                Tuple.Create(1, 2), 
                Tuple.Create(2, 2), 
                Tuple.Create(3, 2), 
                Tuple.Create(4, 2), 
                Tuple.Create(4, 3), 
                Tuple.Create(3, 4), 
                Tuple.Create(4, 4), 
            };
            
            Assert.AreEqual(expected, field);
        }
        
        [Test]
        public void TestStation()
        {
            var parsedInput = MonitorStation.Parse(_testInput);
            
            Tuple<int, int> station = MonitorStation.GetBestStation(parsedInput);

            Assert.AreEqual(Tuple.Create(3, 4), station);
        }
        
        [Test]
        public void TestRotation()
        {
            const string input = @".#....#####...#..
                                   ##...##.#####..##
                                   ##...#...#.#####.
                                   ..#.....#...###..
                                   ..#.#.....#....##";
            
            var asteroids = MonitorStation.Parse(input);
            
            Tuple<int, int> station = MonitorStation.GetBestStation(asteroids);
            Assert.AreEqual(Tuple.Create(8, 3), station);

            var firstAsteroidDestroyed = MonitorStation.DestroyAsteroid(asteroids, 1);
            Assert.AreEqual(Tuple.Create(8, 1), firstAsteroidDestroyed);
            
            var secondAsteroidDestroyed = MonitorStation.DestroyAsteroid(asteroids, 2);
            Assert.AreEqual(Tuple.Create(9, 0), secondAsteroidDestroyed);
            
            var ninthAsteroidDestroyed = MonitorStation.DestroyAsteroid(asteroids, 9);
            Assert.AreEqual(Tuple.Create(15, 1), ninthAsteroidDestroyed);
        }
        
        
    }
}