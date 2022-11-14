using System;

namespace Фоновая_2
{
    internal class Program
    {

        public static uint looped_move(uint x1)
        {
            if ((x1 & 0x1) != 0)
            {
                x1 = x1 >> 1;
                x1 = x1 | 0x80000000;
            }
            else
            {
                x1 = x1 >> 1;
            }

            return x1;
        }
        
        public static void first(uint x1)
        {
            int res = 0;
            uint mask = 1;
            for (int i = 0; i < 32; i++)
            {
                res += ((x1 & mask) == 0) ? 1 : 0;
                mask = mask << 1;
            }
            Console.WriteLine(res);
        }

        public static void second(int x2)
        {
            uint mask = 0x80000000;
            bool found = false;
            int current = 0;
            for (int i = 0; i < 32; i++)
            {
                current = (x2 & mask) != 0 ? 1 : 0;
                if (current != 0) found = true;
                if (found) Console.Write(current);
                mask = mask >> 1;
            }
        }

        public static void third(uint x1, uint n)
        {
            for (int i = 0; i < n; i++)
            {
                x1 = looped_move(x1);
            }
            Console.WriteLine(Convert.ToString(x1, 2));
        }

        public static void Main(string[] args)
        {
            uint x1 = Convert.ToUInt32(Console.ReadLine());
            uint n = Convert.ToUInt32(Console.ReadLine());
            int x2 = Convert.ToInt32(Console.ReadLine());
            third(x1, n);
        }
    }
}