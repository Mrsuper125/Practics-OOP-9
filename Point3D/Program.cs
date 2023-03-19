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
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Point3D Bob = new Point3D(0, 0, 0);
            Console.WriteLine("Это Боб. Сейчас вам будет предложено ввести его координаты. Зачем - спросите Боба.");
            for (int i = 0; i < 3; i++)
            {
                Bob.Move();
            }
            Bob.PrintCoordinates();
            Console.WriteLine("Радиус-вектор Боба - " + Bob.Radius());
        }
    }
}