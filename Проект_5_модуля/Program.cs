using System;
using System.Runtime.ExceptionServices;
using System.Linq;

namespace Проект_5_модуля
{
    internal class Program
    {

        public static int[,,] history;
        public static int max;

        public static bool OnBoard(int i, int j)
        {
            return i < 8 && i >= 0 && j < 8 && j >= 0;
        }

        public static bool White(int i, int j, int[,] board)
        {
            return OnBoard(i, j) && board[i, j] == 1;
        }
        
        public static bool LowerLeft(int blackI, int blackJ, int whiteI, int whiteJ)
        {
            return (blackI < 6 && blackJ > 1 && whiteI - 1 == blackI && whiteJ == blackJ);
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

        public static int[,,] fillHistory(int[,,] historyParam, int[,] board)
        {
            int[,,] resultHistory = new int[historyParam.GetLength(0) + 1, 8, 8];
            if (history.GetLength(0) > 0)
            {
                for (int i = 0; i < historyParam.GetLength(0); i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            resultHistory[i, j, k] = history[i, j, k];
                        }
                    }
                }
            }
            else
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        resultHistory[0, j, k] = board[j, k];
                    }
                }
            }

            return resultHistory;
        }

        public static void AddToLocalHistory(ref int[,,] localHistory, int[,] board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    localHistory[localHistory.GetLength(0) - 1, i, j] = board[i, j];
                }
            }
        }
        
        public static void Take(int[,,] historyParam, int[,] board, int blackI, int blackJ, int count)
        {
            int[,,] localHistory = fillHistory(historyParam, board);
            
            if (White(blackI - 1, blackJ -1, board) && UpperLeft(blackI, blackJ, blackI - 1, blackJ - 1))
            {
                int[,] boardCopy = board;

                boardCopy[blackI, blackJ] = 0;
                boardCopy[blackI - 1, blackJ - 1] = 0;
                boardCopy[blackI - 2, blackJ - 2] = -1;

                AddToLocalHistory(ref localHistory, boardCopy);
                
                Take(localHistory, boardCopy, blackI - 2, blackJ - 2, count + 1);
            }
            if (White(blackI+1, blackJ +1, board) && LowerRight(blackI, blackJ, blackI+1, blackJ+1))
            {
                int[,] boardCopy = board;

                boardCopy[blackI, blackJ] = 0;
                boardCopy[blackI + 1, blackJ + 1] = 0;
                boardCopy[blackI + 2, blackJ + 2] = -1;

                AddToLocalHistory(ref localHistory, boardCopy);
                
                Take(localHistory, boardCopy, blackI + 2, blackJ + 2, count + 1);
            }
            if (White(blackI+1, blackJ -1, board) && LowerLeft(blackI, blackJ, blackI+1, blackJ-1))
            {
                int[,] boardCopy = board;

                boardCopy[blackI, blackJ] = 0;
                boardCopy[blackI + 1, blackJ - 1] = 0;
                boardCopy[blackI + 2, blackJ - 2] = -1;

                AddToLocalHistory(ref localHistory, boardCopy);
                
                Take(localHistory, boardCopy, blackI + 2, blackJ - 2, count + 1);
            }
            if (White(blackI-1, blackJ +1, board) && UpperRight(blackI, blackJ, blackI-1, blackJ+1))
            {
                int[,] boardCopy = board;

                boardCopy[blackI, blackJ] = 0;
                boardCopy[blackI - 1, blackJ + 1] = 0;
                boardCopy[blackI - 2, blackJ + 2] = -1;

                AddToLocalHistory(ref localHistory, boardCopy);
                
                Take(localHistory, boardCopy, blackI - 2, blackJ + 2, count + 1);
            }
            if (count > max)
            {
                max = count;
                history = historyParam;
            }
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

            history = new int[0,8,8];
            
            board[4, 4] = -1;
            board[5, 5] = 1;
            board[3, 5] = 1;
            board[5, 3] = 1;
            board[3, 3] = 1;
            board[1, 1] = 1;
            board[7, 1] = 1;
            DisplayBoard(board);
            
            Take(new int[0,8,8], board, 4, 4, 0);

            Console.WriteLine(max);
            for (int i = 0; i < history.GetLength(0); i++)
            {
                int [,] buffer = new int[8,8];
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        buffer[j, k] = history[i, j, k];
                    }
                }
                DisplayBoard(buffer);
            }
        }
    }
}