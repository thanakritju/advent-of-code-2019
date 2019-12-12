using System;
using System.Collections.Generic;
using System.Linq;

namespace Codes.day10
{
    public class MonitorStation
    {
        public static Tuple<int, int> GetBestStation(List<Tuple<int, int>> asteroids)
        {
            var allAsteroids = GetAllAsteroids(asteroids);
            var counts = allAsteroids.Select(allAsteroid => allAsteroid.Count).ToList();
            return asteroids[counts.IndexOf(counts.Max())];
        }

        public static HashSet<double> GetAllAsteroidsForBestStation(List<Tuple<int, int>> asteroids)
        {
            var allAsteroids = GetAllAsteroids(asteroids);
            var counts = allAsteroids.Select(allAsteroid => allAsteroid.Count).ToList();
            return allAsteroids[counts.IndexOf(counts.Max())];
        }
        public static List<HashSet<double>> GetAllAsteroids(List<Tuple<int, int>> asteroids)
        {
            var detections = new List<HashSet<double>>();
            foreach (var asteroid in asteroids)
            {
                var s = new HashSet<double>();
                foreach (var another in asteroids)
                {
                    var (x1, y1) = asteroid;
                    var (x2, y2) = another;
                    if (x1 == x2 && y1 == y2)
                    {
                        continue;
                    }
                    s.Add((Math.Atan2(y2 - y1, x2 - x1)) * 180 / Math.PI);
                }
                detections.Add(s);
            }

            return detections;
        }

        public static List<Tuple<int, int>> Parse(string stringInput)
        {
            string[] rows = stringInput.Split(
                new[] { ' ', '\t', '\r', '\n' }, 
                StringSplitOptions.RemoveEmptyEntries
                );

            var asteroids = new List<Tuple<int, int>>();
            for (var i = 0; i < rows.Length; i++)
            {
                for (var j = 0; j < rows[i].Length; j++)
                {
                    if (rows[i][j].ToString().Equals("#"))
                    {
                        asteroids.Add(Tuple.Create(j ,i));
                    }
                }
            }

            return asteroids;
        }

        public static Tuple<int, int> DestroyAsteroid(List<Tuple<int, int>> asteroids, int number)
        {
            var detection = GetAllAsteroidsForBestStation(asteroids);
            var index = 90.0;
            var count = 0;
            while (count != number)
            {
                
            }
        }
    }
}