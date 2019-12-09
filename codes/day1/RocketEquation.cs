using System;
using System.IO;

namespace Codes.day1
{
    public class RocketEquation
    {
        public static int Fuel(int mass)
        {
            return mass / 3 - 2;
        }
        
        public static int FuelRecursive(int mass)
        {
            var remaining = Fuel(mass);
            if (remaining <= 0)
            {
                return 0;
            }
            return remaining + FuelRecursive(remaining);
        }

        public static int SolvePart1()
        {
            var data = GetData();
            var sum = 0;
            foreach (var mass in data)
            {
                sum += Fuel(mass);
            }

            return sum;
        }
        
        public static int SolvePart2()
        {
            var data = GetData();
            var sum = 0;
            foreach (var mass in data)
            {
                sum += FuelRecursive(mass);
            }

            return sum;
        }

        public static int[] GetData()
        {
            string fileContent = File.ReadAllText(@"../../../../codes/day1/data.txt");

            string[] integerStrings = fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int[] integers = new int[integerStrings.Length];

            for (int n = 0; n < integerStrings.Length; n++)
                integers[n] = int.Parse(integerStrings[n]);

            return integers;
        }
    }
}
