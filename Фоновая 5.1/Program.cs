using System;

namespace Фоновая_5._1
{

    class Paralelipiped
    {
        private int width;
        private int height;
        private int length;
        private int x;
        private int y;

        public Paralelipiped()
        {
            width = 6;
            height = 5;
            length = 7;
        }

        public Paralelipiped(int width, int height, int length, int x, int y)
        {
            this.width = width;
            this.height = height;
            this.length = length;
            this.x = x;
            this.y = y;
        }

        public string Dimensions()
        {
            return $"Длина - {length}, ширина - {width}, высота - {height}";
        }

        public int Area()
        {
            return 2 * width * height + 2 * height * length + 2 * length * width;
        }

        public int Volume()
        {
            return width * height * length;
        }

        public void Move(int x, int y)
        {
            this.x += x;
            this.y += y;
        }
    }

    class Ellipse
    {
        private int semiMajorAxis;
        private int semiMinorAxis;
        private double focalLength;

        public Ellipse()
        {
            semiMajorAxis = 5;
            semiMinorAxis = 2;
        }

        public Ellipse(int semiMajorAxisParam, int semiMinorAxisParam)
        {
            semiMajorAxis = semiMajorAxisParam;
            semiMinorAxis = semiMinorAxisParam;
            focalLength = Math.Sqrt(Math.Pow(semiMajorAxis, 2) - Math.Pow(semiMinorAxis, 2));
        }

        private double Eccentricity()
        {
            return focalLength / semiMajorAxis;
        }

        public double Radius()
        {
            Console.Write("Введите угол между большой полуосью и радиусом");
            int angle = Convert.ToInt32(Console.ReadLine());
            return semiMinorAxis / (Math.Sqrt(1 - Math.Pow(Math.E, 2) * Math.Pow(Math.Cos(angle), 2)));
        }

        public double FocalParameter()
        {
            return Math.Pow(semiMinorAxis, 2) / semiMajorAxis;
        }

        public double Area()
        {
            return Math.PI * semiMajorAxis * semiMinorAxis;
        }

        public double Length()
        {
            double sum = semiMajorAxis + semiMinorAxis;
            double diff = semiMajorAxis - semiMinorAxis;

            return Math.PI * sum *
                   (1 + 3 * Math.Pow(diff / sum, 2) / 
                       (10 + Math.Sqrt(4 - 3 * Math.Pow(diff / sum, 2))));
            //Вторая формула Рамануджана
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}