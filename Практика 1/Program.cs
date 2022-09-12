using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = 64.100;
            float pl = 0.78932597F;
            float pr = 1.00000000000f;
            double fl = 3.20000;

            decimal dec = 18500.5m;

            int s1 = 4;
            int p = 16;

            string s = "AMD";

            string name;
            float f;

            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("Введите ваше имя: ");
            name = Console.ReadLine();
            Console.Write("Введите дробное число: ");
            f = float.Parse(Console.ReadLine());

            Console.WriteLine($"Привет, {name}!");
            Console.WriteLine("*********************************\n*\tЯ твой компьютер!\t*\n*********************************");

            Console.WriteLine("У меня следующие характеристики:\n");
            Console.WriteLine($"Процессор               {s} с разрядностью {fl:f2}\nМоя память              {p}Gb (доступно {s1:p})\nЖёсткий диск            {s1}Tb\nТип системы             {r}-разрядная ОС\n\n");
            Console.WriteLine($"Моя производительность  {pr:e0} on/сек\nИндекс произв-ти        {f:f0}\nМоя стоимость           {dec:c2}");
            Console.ReadKey();
        }
    }
}
