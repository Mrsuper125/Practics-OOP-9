using System;

namespace Практика_9
{
    internal class Program
    {
        public static void DigitsOfN(ref int n, int m)
        {
            int digit = 0;
            int copy = n;
            int multiplier = 1;
            while (copy > 0)
            {
                digit = copy % 10;
                copy /= 10;
                if (digit % m == 0)
                {
                    n -= digit * multiplier;
                    n += m * multiplier;
                }
                else if (digit > m)
                {
                    n -= digit * multiplier;
                    n += 9 * multiplier;
                }

                multiplier *= 10;
            }
        }
        
        public static void IncreaseFirstPar(ref int n, int m)
        {
            int copy = m;
            int digits = 0;
            while (copy != 0)
            {
                copy /= 10;
                digits++;
            }

            digits--;
            n *= (int)Math.Pow(10, digits);
        }

        public static void ReplaceWithDivider(ref int n)
        {
            if (n <= 3)
            {
                return;
            }

            int x = n / 2 + 1;

            while (n / x * x != n)
            {
                x--;
            }

            if (x!=1)
            {
                n = x;
            }
        }
        
        public static void Main(string[] args)
        {
            int n = 13;
            ReplaceWithDivider(ref n);
            Console.WriteLine(n);
        }
    }
}