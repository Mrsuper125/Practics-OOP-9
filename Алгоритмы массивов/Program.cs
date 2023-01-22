using System;

namespace Алгоритмы_массивов
{
    internal class Program
    {

        public static double AverageSquaredDifference(int[] mas, int N)
        {
            double sum = 0;
            double sumOfSquares = 0;
            foreach (int num in mas)
            {
                sum += num;
                sumOfSquares += Math.Pow(num, 2);
            }

            double average = sum / N;
            double averageBetweenSquares = sumOfSquares / N;
            double std = Math.Sqrt(averageBetweenSquares - Math.Pow(average, 2));
            return std;
        }
        
        public static void Main(string[] args)
        {
            int[] arr = {1, 2, 3, 4, 5};
            int N = arr.Length;
            Console.WriteLine(AverageSquaredDifference(arr, N));
        }
    }
}