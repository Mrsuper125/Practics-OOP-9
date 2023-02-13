using System;

namespace Проект_5_модуля
{
    internal class Program
    {

        public static bool LowerLeft(int blackI, int blackJ, int whiteI, int whiteJ)
        {
            return (blackI < 6 && blackJ > 1 && whiteI - 1 == blackI && whiteJ == blackJ - 1);
        }
        
        public static bool LowerRight(int blackI, int blackJ, int whiteI, int whiteJ)
        {
            return (blackI < 6 && blackJ < 6 && whiteI - 1 == blackI && whiteJ - 1 == blackJ);
        }
        
        public static bool UpperLeft(int blackI, int blackJ, int whiteI, int whiteJ)
        {
            return (blackI > 1 && blackJ > 1 && whiteI == blackI - 1 && whiteJ == blackJ - 1);
        }
        
        public static bool UpperRight(int blackI, int blackJ, int whiteI, int whiteJ)
        {
            return (blackI > 1 && blackJ < 6 && whiteI == blackI - 1 && whiteJ - 1 == blackJ);
        }
        
        public static void DisplayBoard(int[,] board)
        {
            bool white = true;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.BackgroundColor = white ? ConsoleColor.White : ConsoleColor.Black;
                    if (board[i, j]!= 0)
                    {
                        if (board[i, j] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        
                        Console.Write(" * ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }

                    white = !white;
                }
                Console.Write("\n");
                white = !white;
            }
            Console.Write("\n");
        }
        
        public static void Main(string[] args)
        {
            int[,] board = new int[8, 8];   //0 - пустая, 1 - белая, -1 - чёрная
            board[4, 4] = -1;
            board[5, 5] = 1;
            board[3, 5] = 1;
            board[5, 3] = 1;
            board[3, 3] = 1;
            DisplayBoard(board);
            
            Console.WriteLine(LowerRight(4, 4, 5, 5));
            Console.WriteLine(LowerLeft(4, 4, 5, 3));
            Console.WriteLine(UpperLeft(4, 4, 3, 3));
            Console.WriteLine(UpperRight(4, 4, 3, 5));
        }
    }
}