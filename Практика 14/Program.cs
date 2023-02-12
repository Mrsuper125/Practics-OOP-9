using System;

namespace Практика_14
{
    internal class Program
    {
        
        public static int Length(int num)
        {
            int res = 0;
            do
            {
                num /= 10;
                res++;
            } while (num != 0);

            return res;
        }

        public static int[][] InputArray(int rows)
        {
            int[][] arr = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Введите длину {i+1}-ой строки: ");
                int items = Convert.ToInt32(Console.ReadLine());
                arr[i] = new int[items];
                for (int j = 0; j < items; j++)
                {
                    Console.Write($"Введите {j+1}-ый элемент {i+1}-ой строки: ");
                    int item = Convert.ToInt32(Console.ReadLine());
                    arr[i][j] = item;
                }
            }

            return arr;
        }

        public static void PrintArray(int[][] arr, int column = 10)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    int elem = arr[i][j];
                    Console.Write(elem);
                    for (int k = 0; k < column - Length(elem); k++) Console.Write(" ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        public static int Columns(int[][] arr)
        {
            int res = arr[0].Length;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i].Length > res) res = arr[i].Length;
            }

            return res;
        }

        public static int[] FirstEven(int[][] arr)
        {
            int columns = Columns(arr);
            int[] res = new int[columns];
            
            
            for (int i = 0; i < columns; i++)
            {
                int first = int.MinValue;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j].Length > i)
                    {
                        if (arr[j][i] % 2 == 0 && arr[j][i] > first) first = arr[j][i];
                    }
                }

                if (first != int.MinValue) res[i] = first;
                else res[i] = 0;
            }

            return res;
        }

        public static bool MoreThanHalfZeroes(int[] arr)
        {
            int count = 0;
            foreach (int item in arr)
            {
                if (item == 0)
                {
                    count++;
                }
            }

            return count > arr.Length / 2;
        }

        public static void Compact(ref int[][] arr)
        {
            int count = arr.Length;
            for (int i = 0; i < arr.Length; i++)
            {
                if (MoreThanHalfZeroes(arr[i])) count--;
            }

            int[][] res = new int[count][];

            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (!MoreThanHalfZeroes(arr[i]))
                {
                    res[j] = arr[i];
                    j++;
                }
            }

            arr = res;
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

        public static void Main(string[] args)
        {
            Console.Write("Введите количество строк массива: ");
            int rows = Convert.ToInt32(Console.ReadLine());
            int[][] arr = InputArray(rows);
            PrintArray(arr);
            
            Console.Write("Введите индекс строки: ");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество сдвигов: ");
            int k = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < k; i++)
            {
                LoopedMove(ref arr[row]);
                PrintArray(arr);
            }
        }
    }
}