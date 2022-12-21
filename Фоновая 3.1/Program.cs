using System;
using System.Net.Configuration;
using Microsoft.SqlServer.Server;

namespace Фоновая_3._1
{
    internal class Program
    {
        public static bool EvenDigitsCount(int number)
        {
            bool res = true;
            while (number > 0)
            {
                res = !res;
                number /= 10;
            }

            return res;
        }
        
        
        public static int EvenDigitsCountOfF()
        {
            int res = 0;
            for (int i = 20; i <= 50; i++)
            {
                if (EvenDigitsCount(F(i)))
                {
                    res++;
                }
            }

            return res;
        }
        
        public static int F(int n)
        {
            if (n < 4)
            {
                return n - 1;
            }
            else if (n % 3 == 0)
            {
                return n + 2 * F(n - 1);
            }
            else
            {
                return F(n - 2) + F(n - 3);
            }
        }

        public static int FromOneNumberToAnother(int from, int to, int without = 0)
        {
            if (from == to) return 1;
            else if (from == without) return 0;
            else if (from > to) return 0;
            return FromOneNumberToAnother(from + 3, to, without) + FromOneNumberToAnother(from * 2, to, without);
        }

        public static int From1To41Without32()
        {
            return FromOneNumberToAnother(1, 16) * FromOneNumberToAnother(16, 41, 32);
        }
        
        public static void Main(string[] args)
        {
            Console.WriteLine(EvenDigitsCountOfF());
            Console.WriteLine(F(9));
            Console.WriteLine(From1To41Without32());
        }
    }
}