using System;

namespace Codes.day11
{
    public enum Directions
    {
        North = 0,
        West = 1,
        South = 2,
        East = 3
    }

    public class Robot
    {
        public int Direction;
        public int X;
        public int Y;

        public Robot(int x = 0, int y = 0, int direction = (int) Directions.North)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public void Forward()
        {
            switch (Direction)
            {
                case (int) Directions.North:
                    Y++;
                    break;
                case (int) Directions.South:
                    Y--;
                    break;
                case (int) Directions.East:
                    X++;
                    break;
                case (int) Directions.West:
                    X--;
                    break;
                default:
                    throw new InvalidOperationException("Invalid direction");
            }
        }

        public void Move(int i)
        {
            if (i == 1) // Right
            {
                Direction += 3;
                Direction %= 4;
                Forward();
            }
            else if (i == 0) // Left
            {
                Direction += 1;
                Direction %= 4;
                Forward();
            }
            else
            {
                throw new InvalidOperationException("Invalid Move Action");
            }
        }
    }
}