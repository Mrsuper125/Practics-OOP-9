﻿using System;
using System.Collections.Generic;

namespace Фоновая_5._2
{

    enum Month
    {
        январь = 0,
        февраль,
        март,
        апрель,
        май,
        июнь,
        июль,
        август,
        сентябрь,
        октябрь,
        ноябрь,
        декабрь
    }
    
    class WeatherMatrix
    {
        private static int[] monthLength = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private Month month;
        private int day;
        private List<int[]> temperature;

        public WeatherMatrix()
        {
            month = Month.февраль;
            day = 1;
            temperature = new List<int[]>();
            for (int i = 0; i < 4; i++)
            {
                temperature.Add(new int[7]);
            }
        }

        public WeatherMatrix(Month month, int day)
        {
            if (day < 1 || day > 7)
            {
                throw new ArgumentException("Day of week should be between 1 and 7 (both included");
            }

            this.month = month;
            this.day = day;
            temperature = new List<int[]>();
            int toAdd = monthLength[(int)month];
            toAdd -= (8 - day);
            temperature.Add(new int[7]);
            for (int i = 0; i < day - 1; i++)
            {
                temperature[0][i] = NoData;
            }

            while (toAdd >= 7)
            {
                temperature.Add(new int[7]);
                toAdd -= 7;
            }
            
            if(toAdd != 0)
            {
                temperature.Add(new int[7]);
                for (int i = 0; i < 7 - toAdd; i++)
                {
                    temperature[temperature.Count - 1][6 - i] = NoData;
                }
            }
            SetRandomValues(this);
        }

        public Month Month
        {
            get
            {
                return month;
            }
        }

        public List<int[]> Temperature
        {
            get
            {
                return temperature;
            }
        }

        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                if (value < 1 || value > 7)
                {
                    throw new ArgumentException("День недели должен быть выражен числом от 1 до 7 включительно");
                }

                day = value;
                
                List<int> auxillary = new List<int>();
                foreach (int[] row in temperature)
                {
                    foreach (int temp in row)
                    {
                        if (temp != NoData)
                        {
                            auxillary.Add(temp);
                        }
                    }
                }

                WeatherMatrix newMatrix = new WeatherMatrix(month, value);

                int counter = 0;
                for (int i = 0; i < newMatrix.temperature.Count; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (newMatrix.temperature[i][j] != NoData)
                        {
                            newMatrix.temperature[i][j] = auxillary[counter];
                            counter++;
                        }
                    }
                }

                temperature = newMatrix.temperature;
            }
        }

        public int Count
        {
            get
            {
                return monthLength[(int)month];
            }
        }

        public int ZeroDegreesDays
        {
            get
            {
                int res = 0;
                foreach (int[] row in temperature)
                {
                    foreach (int temp in row)
                    {
                        if (temp == 0)
                        {
                            res++;
                        }
                    }
                }

                return res;
            }
        }

        private static int NoData
        {
            get
            {
                return -1000;
            }
        }

        private static void SetRandomValues(WeatherMatrix matrix)
        {
            Random rn = new Random();
            int max = 25;
            int min = -15;
            int current;
            if ((int)matrix.month < 6)
            {
                current = min + ((int)matrix.month)*5;
            }
            else
            {
                current = max - (((int)matrix.month - 6))*5;
            }
            foreach (int[] row in matrix.temperature)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (row[i] != NoData)
                    {
                        row[i] = rn.Next(current - 5, current + 5);
                    }
                }
            }
        }

        public int Difference()
        {
            int previous = temperature[0][0];
            int maxDiff = 0;
            foreach (int[] row in temperature)
            {
                foreach (int temp in row)
                {
                    if (previous != NoData && temp != NoData && Math.Abs(temp - previous) > maxDiff)
                    {
                        maxDiff = Math.Abs(temp - previous);
                    }

                    previous = temp;
                }
            }

            return maxDiff;
        }

        public int Difference(out int jumpDay, out int initialTemp)
        {
            int previous = temperature[0][0];
            int maxDiff = 0;
            int dayCounter = 0;
            initialTemp = 0;
            jumpDay = 1;
            foreach (int temp in temperature[0])
            {
                if (temp != NoData)
                {
                    initialTemp = temp;
                    break;
                }
            }
            foreach (int[] row in temperature)
            {
                foreach (int temp in row)
                {
                    if (temp != NoData)
                    {
                        dayCounter++;
                    }
                    if (previous != NoData && temp != NoData && Math.Abs(temp - previous) > maxDiff)
                    {
                        initialTemp = previous;
                        maxDiff = Math.Abs(temp - previous);
                        jumpDay = dayCounter-1;
                    }

                    previous = temp;
                }
            }

            return maxDiff;
        }
        
        private static string Spaces(int length)
        {
            string res = "";
            for (int i = 0; i < length; i++)
            {
                res = res + " ";
            }

            return res;
        }

        private static int intLength(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                int res = 0;
                if (n < 0)
                {
                    res++;
                    n *= -1;
                }

                while (n != 0)
                {
                    n /= 10;
                    res++;
                }

                return res;
            }
        }
        
        private static string Block(int num1, int num2, int halfLength, int fullLength)
        {
            string firstSpace = Spaces(halfLength - intLength(num1));
            string res = num1 + firstSpace + num2 +
                         Spaces(fullLength - intLength(num1) - intLength(num2) - firstSpace.Length);
            return res;
        }
        
        public void Print()
        {
            int columnWidth = 10;
            string[] days = { "пн", "вт", "ср", "чт", "пт", "сб", "вс" };
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string weekDay in days)
            {
                Console.Write(weekDay + Spaces(columnWidth-2));
            }
            Console.Write("\n");
            Console.ResetColor();
            int dayCounter = 1;
            int weekDayCounter = day;
            foreach (int[] row in temperature)
            {
                foreach (int temp in row)
                {
                    if (temp == NoData)
                    {
                        Console.Write(Spaces(columnWidth));
                    }
                    else
                    {
                        Console.Write(Block(dayCounter, temp, columnWidth/2, columnWidth));
                        dayCounter++;
                    }
                }
                Console.Write("\n");
            }
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            // matrix.Print();
            // int jumpday = 0;
            // int temp = 0;
            // Console.WriteLine(matrix.Difference(out jumpday, out temp) + " " + jumpday + " " + temp);
            // matrix.Day = 5;
            // matrix.Print();
            // Console.WriteLine(matrix.Count + " " + matrix.ZeroDegreesDays);
            
            Console.WriteLine("Добро пожаловать в дневник погоды. Введите номер месяца: ");
            int intMonth;
            Month month;
            bool success = int.TryParse(Console.ReadLine(), out intMonth);
            if (success && intMonth <= 12 && intMonth >= 1)
            {
                month = (Month)intMonth;
            }
            else
            {
                Console.WriteLine("Введён некорректный номер месяца или не число. Месяцем установлен январь.");
                month = Month.январь;
            }
            
            Console.WriteLine("Введите номер дня недели, с которого начинается месяц: ");
            int inputDay;
            success = int.TryParse(Console.ReadLine(), out inputDay);
            if (!(success && intMonth <= 7 && intMonth >= 1))
            {
                Console.WriteLine("Введён некорректный номер дня недели или не число. Днём недели установлен понедельник.");
                inputDay = 1;
            }
            
            WeatherMatrix matrix = new WeatherMatrix(month, inputDay);
            
            Console.WriteLine("Введите номер желаемого действия:\n" +
                              "1) Вывести на экран номер дня недели первого дня текущего месяца\n" +
                              "2) Изменить номер дня недели первого дня текущего месяца\n" +
                              "3) Вывести на экран номер месяца\n" +
                              "4) Вывести на экран массив со всей температурой\n" +
                              "5) Вывести на экран количество дней в месяце\n" +
                              "6) Вывести на экран количество дней в месяце с температурой в 0 градусов\n" +
                              "7) Вывести на экран максимальный скачок температуры за месяц\n" +
                              "8) Вывести на экран максимальный скачок температуры за месяц с номером дня и температурой до скачка\n" +
                              "9) Закрыть программу");

            bool running = true;
            while (running)
            {
                Console.Write("Введите номер действия здесь: ");
                
                int action;

                success = int.TryParse(Console.ReadLine(), out action);
                if (!success)
                {
                    Console.WriteLine("Введено не число");
                    continue;
                }

                switch (action)
                {
                    case 1:
                        Console.WriteLine(matrix.Day);
                        break;
                    case 2:
                        Console.Write("Введите новый день недели в виде числа от 1 до 7 включительно: ");
                        int number;

                        success = int.TryParse(Console.ReadLine(), out number);

                        if (!success)
                        {
                            Console.WriteLine("Введено не число");
                            continue;
                        }

                        try
                        {
                            matrix.Day = number;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 3:
                        Console.WriteLine((int)matrix.Month);
                        break;
                    case 4:
                        matrix.Print();
                        break;
                    case 5:
                        Console.WriteLine(matrix.Count);
                        break;
                    case 6:
                        Console.WriteLine(matrix.ZeroDegreesDays);
                        break;
                    case 7:
                        Console.WriteLine(matrix.Difference());
                        break;
                    case 8:
                        int day;
                        int temp;
                        Console.WriteLine($"{matrix.Difference(out day, out temp)}, номер дня до скачка - {day}, температура до скачка - {temp}");
                        break;
                    case 9:
                        Console.WriteLine("Выполнение программы остановлено");
                        running = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}