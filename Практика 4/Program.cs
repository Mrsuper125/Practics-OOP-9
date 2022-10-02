using System;

namespace Практика_4
{
    internal class Program
    {
        public static double max(double a, double b, double c)
        {
            double max;
            if (a > b) max = a;
            else max = b;
            if (c > max) max = c;
            return max;
        }

        public static double min(double a, double b)
        {
            if (a < b) return a;
            else return b;
        }

        public static void Main(string[] args)
        {
            double a = Convert.ToInt32(Console.ReadLine());
            double b = Convert.ToInt32(Console.ReadLine());
            var res =
                max(Math.Pow(min((a + 1) / a, b), 2.0), a, 2 / (a * b)) * min(a, max(0, -b, Math.Sqrt(1 + a * b))) +
                2 * max(a, 3 + Math.Sqrt(a), Math.Pow(a, 3) * b);
            Console.WriteLine(res);
        }
    }
}