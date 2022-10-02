using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_3
{
    //первые три сделал в тетради
    class Program
    {
        public static string Ascending(int a, int b, int c)
        {
            if (a > b)
            {
                if (b > c)
                {
                    return $"{c} {b} {a}";
                }
                else if (a > c)
                {
                    return $"{a} {c} {b}";
                }
                else return $"{c} {a} {b}";
            }
            else
            {
                if (a > c)
                {
                    return $"{b} {a} {c}";
                }
                else if (b > c)
                {
                    return $"{b} {c} {a}";
                }
                else return $"{c} {b} {a}";
            }
        }

        // public static string boxes(int A1, int B1, int C1, int A2, int B2, int C2)
        // {
        // }
        
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
