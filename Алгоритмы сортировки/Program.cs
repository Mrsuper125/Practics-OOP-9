using System;

namespace Алгоритмы_сортировки
{
    internal class Program
    {

        public static int[] StupidSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i+1])
                {
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                    i = - 1;
                }
            }

            return arr;
        }

        public static int[] BubbleSort(int[] arr)
        {
            bool sorted = false;
            int N = arr.Length;
            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < N - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        sorted = false;
                    }
                }
                N--;
            }

            return arr;
        }

        public static int[] SelectionSort(int[] arr)
        {
            for (int N = 0; N < arr.Length - 1; N++)
            {
                int minInd = N;
                for (int i = N ; i <= arr.Length - 1; i++)
                {
                    if (arr[i] < arr[minInd])
                    {
                        minInd = i;
                    }
                }

                int temp = arr[N];
                arr[N] = arr[minInd];
                arr[minInd] = temp;
            }

            return arr;
        }

        public static int[] CountSort(int[] arr)
        {
            int max = Int32.MinValue;
            foreach (int temp in arr)
            {
                if (temp > max)
                {
                    max = temp;
                }
            }

            int[] auxiliary = new int[max+1];
            
            foreach (int temp in arr)
            {
                auxiliary[temp]++;
            }

            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                while (auxiliary[j] == 0)
                {
                    j++;
                }

                auxiliary[j]--;
                arr[i] = j;
            }

            return arr;
        }
        
        public static void Main(string[] args)
        {
            int[] initial = new int[] { 4, 6, 3, 6, 7, 7, 5, 6 };
            int[] sorted = CountSort(initial);
            foreach (int temp in sorted)
            {
                Console.Write(temp + " ");
            }
        }
    }
}