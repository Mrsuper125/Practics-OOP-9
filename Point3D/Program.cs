using System;

namespace Point3D
{

    class Point3D
    {
        private int x;
        private int y;
        private int z;

        public static bool CheckValues(int x, int y, int z)
        {
            if (!(x % 5 == 0 || y % 5 == 0 || z % 5 == 0)) return false;
            if (x < 0) return false;
            if (y < 0 || y > 100) return false;
            if (z > x + y) return false;
            return true;
        }
        
        public static Point3D CreatePoint(int x, int y, int z)
        {
            if (CheckValues(x, y, z))
            {
                return new Point3D(x, y, z);
            }
            else
            {
                Console.WriteLine("Дурак. Надоел уже.");
                return new Point3D();
            }
        }
        
        public static Point3D CreatePoint(decimal coordinates)
        {
            Point3D point = new Point3D(coordinates);
            if (Point3D.CheckValues(point.X, point.Y, point.Z))
            {
                return point;
            }
            else
            {
                Console.WriteLine("Дурак. Надоел уже.");
                return new Point3D();
            }
        }
        
        public Point3D()
        {
            
        }

        private Point3D(int x, int y, int z)
        {
            if (Point3D.CheckValues(x, y, z))
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            else
            {
                Console.WriteLine("Ну ты и дурак! Правильную точку делай!");
                this.x = 0;
                this.y = 0;
                this.z = 0;
            }
        }

        private Point3D(decimal coordinates)
        {
            int xUnchecked = Convert.ToInt32(coordinates);
            decimal tail = coordinates % 1;
            while (tail % 1 != 0)
            {
                tail *= 10;
            }

            int yUnchecked = (int)tail;
            if (Point3D.CheckValues(xUnchecked, yUnchecked, 0))
            {
                x = xUnchecked;
                y = yUnchecked;
                z = 0;
            }
            else
            {
                Console.WriteLine("Ну ты и дурак! Правильную точку делай!");
                x = 0;
                y = 0;
                z = 0;
            }
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (Point3D.CheckValues(value, y, z))
                {
                    x = value;
                }
                else Console.WriteLine("Ну ты и дурак! Правильную точку делай!");
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
                if (Point3D.CheckValues(x, value, z))
                {
                    if (x + value <= 100) x = value;
                    else x = 100;
                }
                else Console.WriteLine("Ну ты и дурак! Правильную точку делай!");
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
                if (Point3D.CheckValues(x, y, value))
                {
                    z = value;
                }
                else
                {
                    Console.WriteLine("Ну ты и дурак! Правильную точку делай!");
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
                    if (Point3D.CheckValues(x+distance, y, z))
                    {
                        x += distance;
                    }
                    else
                    {
                        Console.WriteLine("Ну ты и дурак! Правильную точку делай!");
                    }
                    break;
                case "y":
                    Console.WriteLine("Введите расстояние, на которое сдвинуть точку: ");
                    distance = Convert.ToInt32(Console.ReadLine());
                    if (Point3D.CheckValues(x, y+distance, z))
                    {
                        y += distance;
                    }
                    else
                    {
                        Console.WriteLine("Ну ты и дурак! Правильную точку делай!");
                    }
                    break;
                case "z":
                    Console.WriteLine("Введите расстояние, на которое сдвинуть точку: ");
                    distance = Convert.ToInt32(Console.ReadLine());
                    if (Point3D.CheckValues(x, y, z+distance))
                    {
                        z += distance;
                    }
                    else
                    {
                        Console.WriteLine("Ну ты и дурак! Правильную точку делай!");
                    }
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
            if (Point3D.CheckValues(a.X + b.X, a.Y + b.Y, a.Z + b.Z))
            {
                return new Point3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
            }
            else
            {
                Console.WriteLine("Ну ты и дурак! Правильную точку делай!");
                return new Point3D();
            }
        }

        public void AddInt(int term)
        {
            if (Point3D.CheckValues(x + term, y + term, z+term))
            {
                x += term;
                y += term;
                z += term;
            }
            else 
            {
                Console.WriteLine("Ну ты и дурак! Правильную точку делай!");
            }
        }

        public void Add(Point3D term)
        {
            if (Point3D.CheckValues(x + term.X, y + term.Y, z+term.Z))
            {
                x += term.X;
                y += term.Y;
                z += term.Z;
            }
            else 
            {
                Console.WriteLine("Ну ты и дурак! Правильную точку делай!");
            }
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Point3D Bob = new Point3D();
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
            Point3D Bill = Point3D.CreatePoint(3, 2, 1);
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
            Point3D John = Point3D.CreatePoint(Convert.ToDecimal(Console.ReadLine()));
            
            Console.WriteLine("Прибавим Джона к Бибу");
            Bib.Add(John);
            Console.WriteLine(Bib.Coordinates);
            //P.S. Работу свойств X, Y, Z я уже демонстрирую в других методах/свойствах
        }
    }
}