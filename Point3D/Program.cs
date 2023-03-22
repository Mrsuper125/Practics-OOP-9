using System;

namespace Point3D
{

    class Point3D
    {
        private int x;
        private int y;
        private int z;

        public Point3D()
        {
            
        }

        public Point3D(int xParam, int yParam, int zParam)
        {
            x = xParam;
            y = yParam;
            z = zParam;
        }

        public void Move()
        {
            Console.Write("Введите  ось координат, по которой сдвинуть точку: ");
            string axis = Console.ReadLine();
            int distance;
            switch (axis)
            {
                case "x":
                    Console.WriteLine("Введите расстояние, на которое сдвинуть точку: ");
                    distance = Convert.ToInt32(Console.ReadLine());
                    x += distance;
                    break;
                case "y":
                    Console.WriteLine("Введите расстояние, на которое сдвинуть точку: ");
                    distance = Convert.ToInt32(Console.ReadLine());
                    y += distance;
                    break;
                case "z":
                    Console.WriteLine("Введите расстояние, на которое сдвинуть точку: ");
                    distance = Convert.ToInt32(Console.ReadLine());
                    z += distance;
                    break;
                default:
                    Console.WriteLine("Такой оси не существует");
                    break;
            }
        }

        public void PrintCoordinates()
        {
            Console.WriteLine($"Координаты точки: x - {x}; y - {y}; z- {z}");
        }

        public double Radius()
        {
            return Math.Sqrt(x*x + y*y + z*z);  
        }
        
        public static Point3D operator +(Point3D a, Point3D b)
        {
            return new Point3D(a.x + b.x, a.y + b.y, a.z + b.z);
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Point3D Bob = new Point3D(0, 0, 0);
            Console.WriteLine("Это Боб.");
            Console.WriteLine("Хотите ввести ему координаты сами или сделам дефолтного боба? \"Да\" = ввести, что-то другое - дефолтного");
            string ans = Console.ReadLine();
            if(ans == "Да")
            {
                for (int i = 0; i < 3; i++)
                {
                    Bob.Move();
                }
            }
            Bob.PrintCoordinates();
            Console.WriteLine("Радиус-вектор Боба - " + Bob.Radius());
            Point3D Bill = new Point3D(3, 2, 1);
            Console.WriteLine("А это Билл.");
            Bill.PrintCoordinates();
            Console.WriteLine("Го сложим Билла с Бобом? Хз зачем но попробуем");
            Point3D Bib = Bob + Bill;
            Console.WriteLine("Получился Биб");
            Bib.PrintCoordinates();
        }
    }
}