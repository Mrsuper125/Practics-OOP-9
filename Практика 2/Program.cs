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
            
            Console.WriteLine(Math.Pow(c + b, 1.0/3.0) + Math.Sin(Convert.ToDouble(a) / 4.0) + Math.Sqrt((a + b + 4) / 2) + Math.Pow(c, 2));
        }
    }
}
