using System.Collections.Generic;
using System.Linq;

namespace Codes.day12
{
    public class MoonSystem
    {
        private List<Moon> _moons;

        public MoonSystem()
        {
            _moons = new List<Moon>();
        }

        public void AddMoon(Moon moon)
        {
            _moons.Add(moon);
        }

        public int CalculateTotalEnergy(in int step)
        {
            Run(step);
            return _moons.Sum(m => m.GetTotalEnergy());
        }

        public void Run(int times)
        {
            for (var i = 0; i < times; i++)
            {
                _moons = ApplyGravity();
                _moons = ApplyVelocity();
            }
        }

        public List<Moon> ApplyGravity()
        {
            var newMoons = new List<Moon>();
            foreach (var moon in _moons)
            {
                Moon tmpMoon = null;
                foreach (var another in _moons)
                {
                    if (moon.Equals(another)) continue;
                    if (tmpMoon == null) tmpMoon = moon;
                    tmpMoon = tmpMoon.ApplyGravity(another);
                }

                newMoons.Add(tmpMoon);
            }

            return newMoons;
        }

        public List<Moon> ApplyVelocity()
        {
            var newMoons = new List<Moon>();
            foreach (var moon in _moons) newMoons.Add(moon.UpdatePosition());

            return newMoons;
        }
    }
}