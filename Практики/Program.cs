using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практики
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Как тебя зовут?");
            string name = Console.ReadLine();
            Console.SetCursorPosition(Console.WindowWidth / 2 -(name.Length + 9) / 2, Console.WindowHeight / 2);
            Console.Write($"Привет, ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(name);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("!");
            Console.ReadKey();
        }
    }
}
