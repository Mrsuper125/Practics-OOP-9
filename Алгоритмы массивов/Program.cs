using System;

namespace Алгоритмы_массивов
{
    internal class Program
    {

        public static double AverageSquaredDifference(int[] mas, int N)
        {
            double average = 0;
            foreach (var item in mas)
            {
                average += item;
            }

            average /= N;

            double dispersion = 0;

            foreach (var item in mas)
            {
                dispersion += Math.Pow(item - average, 2);
            }

            dispersion /= N;

            return Math.Sqrt(dispersion);
        }
        
        public static void Main(string[] args)
        {
            int[] arr = {1, 2, 3, 4, 5};
            int N = arr.Length;
            Console.WriteLine(AverageSquaredDifference(arr, N));
        }
    }
}