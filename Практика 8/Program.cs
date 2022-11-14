using System;

namespace Практика_8
{
    internal class Program
    {
        public static void first()
        {
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine(day & month);
            Console.WriteLine(day | month);
            Console.WriteLine(day ^ month);
            Console.WriteLine(~day);
            Console.WriteLine(~month);
            Console.WriteLine(day >> 1);
            Console.WriteLine(month << 2);
        }

        public static void second()
        {
            int X = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            int mask = 1;
            int res = X & (mask << N);
            Console.WriteLine($"В разряде под номером {N} находится {(res != 0 ? 1:0)}");
        }

        public static void third()
        {
            int number = int.Parse(Console.ReadLine());
            string res = "";
            for (int i = 0; i < 32; i++)
            {
                res = Convert.ToString(number & 1) + res;
                number = number >> 1;
            }
            Console.WriteLine(res);
        }

        public static void Main(string[] args)
        {
            third();
        }
    }
}