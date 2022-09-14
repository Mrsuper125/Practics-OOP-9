using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine(Math.Pow(a + b, 1.0/3) + Math.Sin(a / 4) + Math.Sqrt((a + b + 4) / 2) + Math.Pow(c, 2));
        }
    }
}
