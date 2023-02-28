using System;

namespace Практика_15
{
    internal class Program
    {
        enum Months
        {
            январь = 1,
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

        enum Seasons
        {
            зима = 0,
            весна,
            лето,
            осень
        }

        static int GetMonthLegth(Months month)
        {
            if (month == Months.февраль)
            {
                return 28;
            }
            else if (month == Months.апрель || month == Months.июнь || month == Months.сентябрь || month == Months.ноябрь)
            {
                return 30;
            }
            else
            {
                return 31;
            }
        }
        
        public static void Main(string[] args)
        {
            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine($"Месяц: \"{(Months)i}\", соответствует числу {i}");
            }
            Console.Write("Введите номер месяца: ");
            int monthNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите номер для: ");
            int currentDay = Convert.ToInt32(Console.ReadLine());
            Console.Write("Сколько дней нужно отсчитать? ");
            int n = Convert.ToInt32(Console.ReadLine());

            if (currentDay + n <= GetMonthLegth((Months)monthNumber))
            {
                if (monthNumber == 12)
                {
                    Console.WriteLine("Зима");
                }
                else
                {
                    Console.WriteLine((Seasons)(monthNumber/3));
                }
            }
            else
            {
                n -= GetMonthLegth((Months)monthNumber) - currentDay;
                monthNumber++;
                if (monthNumber == 13) monthNumber = 1;
                while (n > GetMonthLegth((Months)monthNumber))
                {
                    n -= GetMonthLegth((Months)monthNumber);
                    monthNumber++;
                    if (monthNumber == 13) monthNumber = 1;
                }
                if (monthNumber == 12)
                {
                    Console.WriteLine("Зима");
                }
                else
                {
                    Console.WriteLine((Seasons)(monthNumber/3));
                }
            }
        }
    }
}