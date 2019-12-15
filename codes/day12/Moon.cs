using System;

namespace Codes.day12
{
    public class Moon
    {
        public Moon()
        {
            Vx = 0;
            Vy = 0;
            Vz = 0;
        }

        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Vz { get; set; }
        public int Vy { get; set; }
        public int Vx { get; set; }

        public Moon UpdatePosition()
        {
            return new Moon
            {
                Name = Name,
                X = X + Vx,
                Y = Y + Vy,
                Z = Z + Vz,
                Vx = Vx,
                Vy = Vy,
                Vz = Vz
            };
        }

        public int GetTotalEnergy()
        {
            return GetKineticEnergy() * GetPotentialEnergy();
        }

        private int GetKineticEnergy()
        {
            return Math.Abs(Vx) + Math.Abs(Vy) + Math.Abs(Vz);
        }

        private int GetPotentialEnergy()
        {
            return Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
        }

        public Moon ApplyGravity(Moon moon)
        {
            return new Moon
            {
                Name = Name,
                X = X,
                Y = Y,
                Z = Z,
                Vx = Vx + (X == moon.X ? 0 : X < moon.X ? 1 : -1),
                Vy = Vy + (Y == moon.Y ? 0 : Y < moon.Y ? 1 : -1),
                Vz = Vz + (Z == moon.Z ? 0 : Z < moon.Z ? 1 : -1)
            };
        }
    }
}