using System;

namespace Фоновая_5._1
{

    class Paralelipiped
    {
        private int width;
        private int heigth;
        private int length;

        public Paralelipiped()
        {
        }

        public Paralelipiped(int widthParam, int heigthParam, int lengthParam)
        {
            width = widthParam;
            heigth = heigthParam;
            length = lengthParam;
        }

        public int Area()
        {
            return 2 * width * heigth + 2 * heigth * length + 2 * length * width;
        }

        public int Volume()
        {
            return width * heigth * length;
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