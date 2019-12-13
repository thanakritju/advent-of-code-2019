using System;
using System.Linq;

namespace Codes.day10
{
    public class Runner
    {
        public static int RunPart1(string testInput)
        {
            var asteroids = MonitorStation.Parse(testInput);
            var detections = MonitorStation.GetAllAsteroids(asteroids);
            return detections.Select(allAsteroid => allAsteroid.Count).ToList().Max();
        }

        public static Tuple<int, int> RunPart2(string testInput, int number)
        {
            
            var asteroids = MonitorStation.Parse(testInput);
            return MonitorStation.DestroyAsteroid(asteroids, number);
        }
    }
}