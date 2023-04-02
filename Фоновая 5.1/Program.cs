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

        public int SemiMajorAxis
        {
            get { return semiMajorAxis; }
            set
            {
                if (value > 0)
                {
                    semiMajorAxis = value;
                }
                else
                {
                    throw new ArgumentException("Semi-major axis can't be equal to zero or be negative");
                }
            }
        }

        public int SemiMinorAxis
        {
            get { return semiMinorAxis; }
            set
            {
                if (value > 0)
                {
                    semiMinorAxis = value;
                }
                else
                {
                    throw new ArgumentException("Semi-minor axis can't be equal to zero or be negative");
                }
            }
        }

        public bool Circle
        {
            get { return this.Eccentricity == 0; }
        }

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

        public double FocalLength
        {
            get
            {
                return focalLength;
            }
        }

        public double Eccentricity
        {
            get { return focalLength / semiMajorAxis; }
        }

        public double Radius()
        {
            Console.Write("Введите угол между большой полуосью и радиусом: ");
            int angle = Convert.ToInt32(Console.ReadLine());
            return semiMinorAxis / (Math.Sqrt(1 - Math.Pow(Math.E, 2) * Math.Pow(Math.Cos(angle), 2)));
        }

        public double FocalParameter
        {
            get { return Math.Pow(semiMinorAxis, 2) / semiMajorAxis; }
        }

        public double Area
        {
            get { return Math.PI * semiMajorAxis * semiMinorAxis; }
        }

        public double Length
        {
            get
            {
                double sum = semiMajorAxis + semiMinorAxis;
                double diff = semiMajorAxis - semiMinorAxis;

                return Math.PI * sum *
                       (1 + 3 * Math.Pow(diff / sum, 2) /
                           (10 + Math.Sqrt(4 - 3 * Math.Pow(diff / sum, 2))));
                //Вторая формула Рамануджана}
            }
        }

        public string Description
        {
            get
            {
                return $"Малая полуось - {semiMinorAxis}, большая полуось - {semiMajorAxis}, периметр - {Length} (значение приближённое), площадь - {Area}, кругом {(Circle ? "является" : "не является")}, эксцентриситет - {Eccentricity}, фокусное расстояние - {focalLength}, радиус - {Radius()}";
            }
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Ellipse ellipse = new Ellipse(3, 2);
            ellipse.SemiMinorAxis = 3;
            ellipse.SemiMajorAxis = 4;
            Console.WriteLine(ellipse.Description);
        }
    }
}