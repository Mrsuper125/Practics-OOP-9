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

        static int MinAndMaxOnInterval(out int min)
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
        
        public static void Main(string[] args)
        {
            foreach (var temp in Create(10, 14))
            {
                Console.Write(temp+" ");
            }
        }
    }
}