using System;

namespace Фоновая_1._1
{
    internal class Program
    {
        static double wrongU(double x, double y)
        {
            return x * Math.Pow(y, 3) + 7;
        }
        
        public static void Main(string[] args)
        {
            double x = Convert.ToDouble(Console.ReadLine());
            double y = Convert.ToDouble(Console.ReadLine());
            double U;
            if (x<=0.5)
            {
                if (x>=-0.5)
                {
                    if (y<=1)
                    {
                        if (y>=-1)
                        {
                            U = y * Math.Pow(x, 2) - 1;
                        }
                        else
                        {
                            U = wrongU(x, y);
                        }
                    }
                    else
                    {
                        U = wrongU(x, y);
                    }
                }
                else
                {
                    U = wrongU(x, y);
                }
            }
            else
            {
                U = wrongU(x, y);
            }
            Console.WriteLine(U);
        }
    }
}