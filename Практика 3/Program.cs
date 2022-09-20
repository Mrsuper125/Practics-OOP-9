using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            if (a <= 0) Console.WriteLine("Не бей по своим!");
            else if (a < 28) Console.WriteLine("НЕДОЛЕТ");
            else if (a < 31) Console.WriteLine("ПОПАЛ!");
            else Console.WriteLine("ПЕРЕЛЕТ");
            Console.ReadKey();
        }
    }
}
