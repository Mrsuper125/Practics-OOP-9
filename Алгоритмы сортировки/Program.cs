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

        public static int[] MergeSort(int[] arr)
        {
            int[] res = new int[arr.Length];
            if (arr.Length == 1)
            {
                return arr;
            }
            else
            {
                int middleIndex = (arr.Length-1) / 2;
                int[] left = new int[middleIndex + 1];
                int[] right = new int[arr.Length - middleIndex - 1];
                
                for (int i = 0; i <= middleIndex; i++)
                {
                    left[i] = arr[i];
                }
                for (int i = middleIndex+1; i < arr.Length; i++)
                {
                    right[i - middleIndex - 1] = arr[i];
                }

                left = MergeSort(left);
                right = MergeSort(right);
                
                int j = 0;
                int k = 0;
                for (int i = 0; i < res.Length; i++)
                {
                    if (j == -1)
                    {
                        res[i] = right[k];
                        k++;
                    }
                    else if (k == - 1)
                    {
                        res[i] = left[j];
                        j++;
                    }
                    else
                    {
                        if (left[j] <= right[k])
                        {
                            res[i] = left[j];
                            j++;
                            if (j == left.Length) j = -1;
                        }
                        else
                        {
                            res[i] = right[k];
                            k++;
                            if (k == right.Length) k = -1;
                        }
                    }
                }
            }

            return res;
        }
        
        public static void Main(string[] args)
        {
            int[] initial = new int[] { 4, 6, 3, 6, 7, 7, 5, 6 };
            int[] sorted = MergeSort(initial);
            foreach (int temp in sorted)
            {
                Console.Write(temp + " ");
            }
        }
    }
}