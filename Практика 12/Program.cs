using System;

namespace Практика_12
{
    internal class Program
    {

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

        static int MinAndAmountOnInterval(out int min)
        {
            min = 11201;
            int count = 0;
            for (int i = 1200; i <= 11200; i+=5)
            {
                if (!IsForbidden(i))
                {
                    if (i < min) min = i;
                    count++;
                }
            }

            return count;
        }
        
        static int MaxAndAmountOnInterval(out int max)
        {
            max = 3440;
            int count = 0;
            for (int i = 3439; i <= 7410; i+=1)
            {
                if ((i % 9 == 0 || i % 10 == 0 || i % 11 == 0) && (i%2 != i%6))
                { 
                    if (i > max) max = i;
                    count++;
                }
            }

            return count;
        }
        
        static int AverageAndAmountOnInterval(out int average)
        {
            int max = 2475;
            int min = 7858;
            int count = 0;
            for (int i = 2476; i <= 7857; i+=2)
            {
                if (i%8 != 0 && i % 1000 / 100  <= 7)
                { 
                    if (i > max) max = i;
                    if (i < min) min = i;
                    count++;
                }
            }

            average = (max + min) / 2;

            return count;
        }
        
        public static void Main(string[] args)
        {
            
        }
    }
}