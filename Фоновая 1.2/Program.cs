using System;

namespace Фоновая_1._2
{
    internal class Program
    {

        public static int SecondMin(int N)
        {
            int min1 = Int32.Parse(Console.ReadLine());
            int min2 = min1;
            for (int i = 1; i < N; i++)
            {
                int cur = Int32.Parse(Console.ReadLine());
                if (cur < min1)
                {
                    min2 = min1;
                    min1 = cur;
                }
                else if (cur < min2 && cur != min1)
                {
                    min2 = cur;
                }
            }

            return min2;
        }
        
        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine(SecondMin(N));
        }
    }
}