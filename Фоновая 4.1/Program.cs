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
            Console.WriteLine("");
        }

        public static void BetweenMaxAndMin(ref int[] arr)
        {
            int minInd = 0;
            int maxInd = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= arr[minInd]) minInd = i;
                if (arr[i] > arr[maxInd]) maxInd = i;
            }

            if (maxInd <= minInd)
            {
                int[] res = new int[minInd - maxInd + 1];
                for (int i = 0; i < minInd - maxInd + 1; i++)
                {
                    res[i] = arr[i + maxInd];
                }

                arr = res;
            }
            else
            {
                arr = new int[0];
            }
        }

        public static void LoopedMove(ref int[] arr)
        {
            int left = arr[0];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }

            arr[arr.Length - 1] = left;
        }

        public static void LoopedMoveByK(ref int[] arr, int k)
        {
            for (int i = 0; i < k; i++)
            {
                LoopedMove(ref arr);
            }
        }

        public static bool Contains(int[] arr, int num)
        {
            foreach (int item in arr)
            {
                if (item == num) return true;
            }

            return false;
        }

        public static void Erase(ref int[] arr, int num)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num) arr[i] = 0;
            }
        }
        
        public static void Intersect(int[] arr1, int[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                if (Contains(arr2, arr1[i]) && arr1[i] > 0)
                {
                    Console.Write(arr1[i] + " ");
                    Erase(ref arr1, arr1[i]);
                }
            }
        }

        public static void RemoveRepeats(ref int[] arr)
        {
            int count = 0;
            int previous = Int32.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != previous)
                {
                    count++;
                }
                else
                {
                    arr[i] = 0;
                }

                previous = arr[i];
            }

            int[] res = new int[count];
            int j = 0;
            foreach (int item in arr)
            {
                if (item != 0)
                {
                    res[j] = item;
                    j++;
                }
            }

            arr = res;
        }
        
        public static void Main(string[] args)
        {
            int[] arr = Input(10);
            BetweenMaxAndMin(ref arr);
            Print(arr);
            Console.WriteLine("Looped Move time");
            LoopedMoveByK(ref arr, Convert.ToInt32(Console.ReadLine()));
            Print(arr);
            Console.WriteLine("Intersect time");
            Intersect(Input(10), Input(10));
            Console.WriteLine("Removal time");
            arr = Input(10);
            RemoveRepeats(ref arr);
            Print(arr);
        }
    }
}