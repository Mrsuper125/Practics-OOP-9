using System;

namespace Практика_13
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

        public static bool OnMain(int i, int j)
        {
            return i == j;
        }

        public static bool AboveMain(int i, int j)
        {
            return i < j;
        }

        public static bool UnderMain(int i, int j)
        {
            return i > j;
        }

        public static bool OnAnti(int i, int j, int n)
        {
            return i + j == n - j - 1;
        }

        public static bool AboveAnti(int i, int j, int n)
        {
            return i + j < n - 1;
        }

        public static bool UnderAnti(int i, int j, int n)
        {
            return i + j > n - 1;
        }

        public static void Print(int[,] arr, int column = 10)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    int elem = arr[i, j];
                    Console.Write(elem);
                    for (int k = 0; k < column - Length(elem); k++) Console.Write(" ");     //\t не всегда делает отступы, на больших числах всё плохо
                }
                Console.Write("\n");
            }
        }

        public static void Snake()
        {
            Console.Write("Введите высоту массива: ");
            int h = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ширину массива: ");
            int l = Convert.ToInt32(Console.ReadLine());

            int[,] arr = new int[h, l];
            int elem = 1;
            bool toTheRight = true;
            
            for (int i = 0; i < h; i++)
            {
                if (toTheRight)
                {
                    for (int j = 0; j < l; j++)
                    {
                        arr[i, j] = elem;
                        elem++;
                    }
                }
                else
                {
                    for (int j = l - 1; j > 0; j--)
                    {
                        arr[i, j] = elem;
                        elem++;
                    }
                }

                toTheRight = !toTheRight;
            }
            
            Print(arr);
        }

        public static void Hatched()
        {
            int[,] arr = new int[10, 10];
            Console.BackgroundColor = ConsoleColor.White;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    int n = arr.GetLength(0);
                    if (OnMain(i, j) || OnAnti(i, j, n) || (AboveMain(i, j) && AboveAnti(i, j, n)) || (UnderMain(i, j) && UnderAnti(i, j, n)))
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        arr[i, j] = 1;
                        Console.Write(arr[i, j] + " ");
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else Console.Write(0 + " ");
                }
                Console.Write("\n");
            }
        }
        
        public static void Main(string[] args)
        {
            Hatched();
        }
    }
}