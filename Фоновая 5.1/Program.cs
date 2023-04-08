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


        static bool NormalEllipse(int SemiMinorAxis, int SemiMajorAxis)
        {
            return SemiMinorAxis > 0 && SemiMajorAxis > 0;
        }
        
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

        public Ellipse(int semiMajorAxis, int semiMinorAxis)
        {
            if (NormalEllipse(semiMinorAxis, semiMajorAxis))
            {
                this.semiMajorAxis = semiMajorAxis;
                this.semiMinorAxis = semiMinorAxis;
                focalLength = Math.Sqrt(Math.Pow(semiMajorAxis, 2) - Math.Pow(semiMinorAxis, 2));
            }
            else
            {
                this.semiMinorAxis = 1;
                this.semiMajorAxis = 1;
                focalLength = 0.0;
            }
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

        public double CompressionRatio
        {
            get
            {
                return (double)SemiMinorAxis / (double)SemiMajorAxis;
            }
        }

        public double Radius(int angle)
        {
            if (angle > 0 && angle < 180)
            {
                return semiMinorAxis / (Math.Sqrt(1 - Math.Pow(Eccentricity, 2) * Math.Pow(Math.Cos(angle), 2)));
            }
            else
            {
                Console.WriteLine("Дурак! Угол должен быть от 1 до 89 градусов включительно! Ну играй теперь с 45 градусами!");
                return semiMinorAxis / (Math.Sqrt(1 - Math.Pow(Eccentricity, 2) * Math.Pow(Math.Cos(45), 2)));
            }
        }

        public double FocalParameter
        {
            get { return Math.Pow(semiMinorAxis, 2) / semiMajorAxis; }
        }

        public double Area
        {
            get { return Math.PI * semiMajorAxis * semiMinorAxis; }
        }

        public double PerifocalDistance
        {
            get
            {
                return SemiMajorAxis * (1 - Eccentricity);
            }
        }
        
        public double ApofocalDistance
        {
            get
            {
                return SemiMajorAxis * (1 + Eccentricity);
            }
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
                //Вторая формула Рамануджана
            }
        }

        public string Description
        {
            get
            {
                Console.Write("Введите угол между радиусом и большой полуосью: ");
                return $"Малая полуось - {semiMinorAxis}, большая полуось - {semiMajorAxis}, периметр - {Length:f2} (значение приближённое), площадь - {Area:f2}, кругом {(Circle ? "является" : "не является")}, эксцентриситет - {Eccentricity:f2}, фокусное расстояние - {focalLength:f2}, радиус - {Radius(Convert.ToInt32(Console.ReadLine())):f2}, фокальный параметр - {FocalParameter:f2}, апофокусное расстояние - {ApofocalDistance:f2}, перифокусное расстояние - {PerifocalDistance:f2}";
            }
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Если вы хотите ввести размеры эллипса - введите \"да\", иначе введите что-то другое: ");
            Ellipse ellipse;
            if (Console.ReadLine() == "да")
            {
                Console.Write("Введите большую полуось: ");
                int semiMajorAxis = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите малую полуось: ");
                int semiMinorAxis = Convert.ToInt32(Console.ReadLine());
                ellipse = new Ellipse(semiMajorAxis, semiMinorAxis);
                Console.WriteLine(ellipse.Description);
            }
            else
            {
                Console.WriteLine("Сработал конструктор по умолчанию.");
                ellipse = new Ellipse();
                Console.WriteLine(ellipse.Description);
            }

            ellipse.SemiMajorAxis += 1;
            ellipse.SemiMinorAxis += 1;
        }
    }
}