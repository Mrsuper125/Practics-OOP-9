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
            
        }

        public Ellipse(int semiMajorAxisParam, int semiMinorAxisParam)
        {
            semiMajorAxis = semiMajorAxisParam;
            semiMinorAxis = semiMinorAxisParam;
            focalLength = Math.Sqrt(Math.Pow(semiMajorAxis, 2) - Math.Pow(semiMinorAxis, 2));
        }

        public double Eccentricity()
        {
            return focalLength / semiMajorAxis;
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}