using System;

namespace Фоновая_4._1
{
    internal class Program
    {
        public static int[] Input(int N)
        {
            int[] res = new int[N];
            for (int i = 0; i < N; i++)
            {
                res[i] = Convert.ToInt32(Console.ReadLine());
            }

            return res;
        }

        public static void Print(int[] arr)
        {
            foreach (int elem in arr)
            {
                Console.Write(elem + " ");
            }
        }
        
        
        
        public static void Main(string[] args)
        {
            int[]arr = Input(10);
            Print(arr);
        }
    }
}