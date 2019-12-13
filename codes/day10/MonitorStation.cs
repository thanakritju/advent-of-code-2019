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

        public static Dictionary<double, List<double>> GetAllAsteroidsForBestStation(List<Tuple<int, int>> asteroids)
        {
            var allAsteroids = GetAllAsteroids(asteroids);
            var counts = allAsteroids.Select(allAsteroid => allAsteroid.Count).ToList();
            return allAsteroids[counts.IndexOf(counts.Max())];
        }

        public static List<Dictionary<double, List<double>>> GetAllAsteroids(List<Tuple<int, int>> asteroids)
        {
            var detections = new List<Dictionary<double, List<double>>>();
            foreach (var asteroid in asteroids)
            {
                var asteroidsHashtable = GetAsteroidsDictionary(asteroid, asteroids);
                detections.Add(asteroidsHashtable);
            }

            return detections;
        }

        public static Dictionary<double, List<double>> GetAsteroidsDictionary(Tuple<int, int> station,
            List<Tuple<int, int>> asteroids)
        {
            var (x1, y1) = station;
            var table = new Dictionary<double, List<double>>();

            foreach (var asteroid in asteroids)
            {
                var (x2, y2) = asteroid;
                var dy = y2 - y1;
                var dx = x2 - x1;
                if (dx == 0 && dy == 0) continue;

                var key = Math.Atan2(dy, dx);
                if (table.ContainsKey(key))
                    table[key].Add(dx == 0 ? dy : dx);
                else
                    table[key] = new List<double> {dx == 0 ? dy : dx};
            }

            foreach (var item in table) item.Value.Sort((a, b) => Math.Abs(a).CompareTo(Math.Abs(b)));

            return table;
        }

        public static List<Tuple<int, int>> Parse(string stringInput)
        {
            var rows = stringInput.Split(
                new[] {' ', '\t', '\r', '\n'},
                StringSplitOptions.RemoveEmptyEntries
            );

            var asteroids = new List<Tuple<int, int>>();
            for (var i = 0; i < rows.Length; i++)
            for (var j = 0; j < rows[i].Length; j++)
                if (rows[i][j].ToString().Equals("#"))
                    asteroids.Add(Tuple.Create(j, i));

            return asteroids;
        }

        public static Tuple<int, int> DestroyAsteroid(List<Tuple<int, int>> asteroids, int number)
        {
            var bestStation = GetBestStation(asteroids);
            var table = GetAsteroidsDictionary(bestStation, asteroids);
            var count = 0;
            Tuple<int, int> ans = null;
            var isStarted = false;
            while (count != number)
                foreach (var (key, value) in table.OrderBy(p => p.Key))
                {
                    if (count == number) return ans;

                    double dx;
                    double dy;
                    if (value.Count == 0) continue;
                    if (key == Math.PI / 2 || key == -Math.PI / 2)
                    {
                        dy = value[0];
                        dx = 0.0;
                    }
                    else
                    {
                        dy = Math.Tan(key) * value[0];
                        dx = value[0];
                    }

                    var test = Tuple.Create((int) (bestStation.Item1 + dx), (int) (bestStation.Item2 + dy));
                    if (!isStarted)
                    {
                        if (test.Item1 == bestStation.Item1 && test.Item2 < bestStation.Item2)
                        {
                            isStarted = true;
                            ans = test;
                            count++;
                            value.RemoveAt(0);
                        }
                    }
                    else
                    {
                        ans = test;
                        count++;
                        value.RemoveAt(0);
                    }
                }

            return ans;
        }
    }
}