using System;

namespace Практика_12
{
    internal class Program
    {

        public static int SumOffDigits(int n)
        {
            int res = 0;
            while (n != 0)
            {
                res += n % 10;
                n /= 10;
            }

            return res; 
        }

        static int MaxDigit(int n)
        {
            int res = 0;
            while (n != 0)
            {
                if (n % 10 > res)
                {
                    res = n % 10;
                }

                res /= 10;
            }

            return res;
        }

        public static int Divisors(int n)
        {
            int res = 0;
            for (int i = 0; i < Math.Sqrt(n); i++)
            {
                res += 2;
            }

            if ((int)Math.Pow(Math.Sqrt(n), 2) == n)
            {
                res += 1;
            }

            return res;
        }

        public static int[] Create(int left, int right)
        {
            int len = right - left + 1;
            int[] res = new int[len];
            for (int i = left; i <= right; i++)
            {
                res[i - left] = i;
            }

            return res;
        }

        static bool IsForbidden (int num)
        {
            int[] forbidden = { 7, 13, 17, 19 };
            foreach (var temp in forbidden)
            {
                if (num % temp == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static int MinAndAmountOnInterval(int[] numbers, out int min)
        {
            min = 11201;
            int count = 0;
            foreach (var item in numbers)
            {
                if (!IsForbidden(item) && item % 5 == 0)
                {
                    if (item < min) min = item;
                    count++;
                }
            }

            return count;
        }
        
        static int MaxAndAmountOnInterval(int[] numbers, out int max)
        {
            max = 3440;
            int count = 0;
            foreach (var item in numbers)
            {
                if ((item % 9 == 0 || item % 10 == 0 || item % 11 == 0) && (item%2 != item%6))
                { 
                    if (item > max) max = item;
                    count++;
                }
            }

            return count;
        }
        
        static int AverageAndAmountOnInterval(int[] numbers, out int average)
        {
            int max = 2475;
            int min = 7858;
            int count = 0;
            foreach (var item in numbers)
            {
                if (item%8 != 0 && item % 2 == 0 && item % 1000 / 100  <= 7)
                { 
                    if (item > max) max = item;
                    if (item < min) min = item;
                    count++;
                }
            }

            average = (max + min) / 2;

            return count;
        }

        static int DifferenceAndAmountOnInterval(int[] numbers, out int difference)
        {
            int min = 2224;
            int max = 1213;
            int count = 0;
            foreach (var item in numbers)
            {
                if (SumOffDigits(item) == 14 && MaxDigit(item) == 7 && item % 2 == 0)
                {
                    if (item < min) min = item;
                    if (item > max) max = item;
                    count++;
                }
            }

            difference = max - min;
            return count;
        }

        static int MaxAndAmountOfNumbersWith15DivisorsOnInterval(int[] numbers, out int max)
        {
            int count = 0;
            max = 123455;
            foreach(var item in numbers)
            {
                if (Divisors(item) > 15)
                {
                    count++;
                    if (item > max) max = item;
                }
            }

            return count;
        }
        
        // 1,2,3 задача от варианта 2. 4,5 - вариант 1.
        
        public static void Main(string[] args)
        {
            
        }
    }
}