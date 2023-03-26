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

        public Point3D(decimal coordinates)
        {
            x = Convert.ToInt32(coordinates);
            decimal tail = coordinates % 1;
            while (tail % 1 != 0)
            {
                tail *= 10;
            }

            y = (int)tail;
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (x + value > 0) x = value;
                else throw new ArgumentException("x must be positive");
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (x + value > 0)
                {
                    if (x + value <= 100) x = value;
                    else x = 100;
                }
                else throw new ArgumentException("x must be positive");
            }
        }

        public int Z
        {
            get
            {
                return z;
            }
            set
            {
                if (value <= x+y)
                {
                    z = value;  
                }
                else
                {
                    Console.WriteLine("z must not be greater then x+y");
                }
            }
            
        }

        public bool IsInField
        {
            get
            {
                return x <= 10 && y >= 2 && y <= x;
            }
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
        
        public string Coordinates
        {
            get
            {
                return $"Координаты точки: x - {x}; y - {y}; z- {z}";
            }
        }

        public double Radius
        {
            get
            {
                return Math.Sqrt(x * x + y * y + z * z);
            }
        }

        public static Point3D operator +(Point3D a, Point3D b)
        {
            return new Point3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public void AddInt(int term)
        {
            X += term;
            Y += term;
            Z += term;
        }

        public void Add(Point3D term)
        {
            X += term.X;
            Y += term.Y;
            Z += term.Z;
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
            Console.WriteLine(Bob.Coordinates);
            Console.WriteLine("Радиус-вектор Боба - " + Bob.Radius);
            Point3D Bill = new Point3D(3, 2, 1);
            Console.WriteLine("А это Билл.");
            Console.WriteLine(Bill.Coordinates);
            Console.WriteLine("Го сложим Билла с Бобом? Хз зачем но попробуем");
            Point3D Bib = Bob + Bill;
            Console.WriteLine("Получился Биб");
            Console.WriteLine(Bib.Coordinates);
            
            Console.WriteLine("Вот есть у нас область в пространстве. Что за область - спросите Анну Олеговну. Проверим, попадает ли Биб туда. Зачем - спросите Анну Олеговну.");
            Console.WriteLine(Bib.IsInField);
            Console.WriteLine("Давайте сдвинем Биба на 1 по всем осям");
            Bib.AddInt(1);
            Console.WriteLine(Bib.Coordinates);
            
            Console.WriteLine("Создадим Джона. Введите его x и y координаты через запятую без пробелов");
            Point3D John = new Point3D(Convert.ToDecimal(Console.ReadLine()));
            
            Console.WriteLine("Прибавим Джона к Бибу");
            Bib.Add(John);
            Console.WriteLine(Bib.Coordinates);
            //P.S. Работу свойств X, Y, Z я уже демонстрирую в других методах/свойствах
        }
    }
}