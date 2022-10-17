using System;

namespace Урок03._10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int min;
            int max;
            if (a < b)
            {
                min = a;
                max = b;
            }
            else
            {
                min = b;
                max = a;
            }
            Console.WriteLine($"{max/2 + max%2} {min}");
        }
    }
}