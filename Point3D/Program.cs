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
            if (!(x % 5 == 0 || y % 5 == 0 || z % 5 == 0)) throw new ArgumentException("at least one coordinate should be dividable by 5");
            if (x < 0) throw new ArgumentException("x must be non-negative");
            if (y < 0 || y > 100) throw new ArgumentException("y must be between 0 and 100 (both included)");
            if (z > x + y) throw new ArgumentException("z must be not greater than x + y");
            return true;
        }
        
        public static Point3D CreatePoint(int x, int y, int z)
        {
            try
            {
                CheckValues(x, y, z);
            }
            catch (Exception e)
            {
                Console.WriteLine("0,0,0 point was created instead of desired because "+e.Message);
                return new Point3D();
            }
            return new Point3D(x, y, z);
        }
        
        public static Point3D CreatePoint(decimal coordinates)
        {
            Point3D point = new Point3D(coordinates);
            try
            {
                CheckValues(point.X, point.Y, point.Z);
            }
            catch (Exception e)
            {
                Console.WriteLine("0,0,0 point was created instead of desired because "+e.Message);
                return new Point3D();
            }
            return point;
        }
        
        public Point3D()
        {
            
        }

        private Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            }

        private Point3D(decimal coordinates)
        {
            x = Convert.ToInt32(coordinates);
            decimal tail = coordinates % 1;
            while (tail % 1 != 0)
            {
                tail *= 10;
            }

            y = (int)tail;
            z = 0;
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                try
                {
                    CheckValues(value, y, z);
                }
                catch (Exception e)
                {
                    Console.WriteLine("x-coordinate was not changed because "+e.Message);
                    return;
                }
                x = value;
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
                try
                {
                    CheckValues(x, value, z);
                }
                catch (Exception e)
                {
                    Console.WriteLine("y-coordinate was not changed because "+e.Message);
                    return;
                }
                y = value;
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
                try
                {
                    CheckValues(x, y, value);
                }
                catch (Exception e)
                {
                    Console.WriteLine("z-coordinate was not changed because "+e.Message);
                    return;
                }
                z = value;
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
                    try
                    {
                        CheckValues(x + distance, y, z);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("x-coordinate was not changed because "+e.Message);
                    }
                    break;
                case "y":
                    Console.WriteLine("Введите расстояние, на которое сдвинуть точку: ");
                    distance = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        CheckValues(x, y + distance, z);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("y-coordinate was not changed because "+e.Message);
                    }
                    break;
                case "z":
                    Console.WriteLine("Введите расстояние, на которое сдвинуть точку: ");
                    distance = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        CheckValues(x, y, z+distance);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("z-coordinate was not changed because "+e.Message);
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
            try
            {
                Point3D.CheckValues(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
            }
            catch (Exception e)
            {
                Console.WriteLine("Points can't be added because " +e.Message);
                return a;
            }
            return new Point3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
            
        }

        public static Point3D operator +(Point3D a,  int term)
        {
            try
            {
                Point3D.CheckValues(a.x + term, a.y + term, a.z + term);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Number {term} can't be added to the point because " +e.Message);
                return a;
            }
            return new Point3D(a.x + term, a.y + term, a.z + term);
        }
        
        public static Point3D operator -(Point3D a, Point3D b)
        {
            try
            {
                Point3D.CheckValues(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
            }
            catch (Exception e)
            {
                Console.WriteLine("Points can't be subtracted because " +e.Message);
                return a;
            }
            return new Point3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
            
        }

        public static Point3D operator -(Point3D a,  int term)
        {
            try
            {
                Point3D.CheckValues(a.x - term, a.y - term, a.z - term);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Number {term} can't be subtracted from the point because " +e.Message);
                return a;
            }
            return new Point3D(a.x - term, a.y - term, a.z - term);
        }

        public static Point3D operator --(Point3D a)
        {
            try
            {
                Point3D.CheckValues(a.x - 1, a.y - 1, a.z - 1);
            }
            catch (Exception e)
            {
                Console.WriteLine($"1 can't be subtracted from the point because " +e.Message);
                return a;
            }
            return new Point3D(a.x - 1, a.y - 1, a.z - 1);
        }
        
        public static Point3D operator ++(Point3D a)
        {
            try
            {
                Point3D.CheckValues(a.x + 1, a.y + 1, a.z + 1);
            }
            catch (Exception e)
            {
                Console.WriteLine($"1 can't be added to the point because " +e.Message);
                return a;
            }
            return new Point3D(a.x + 1, a.y + 1, a.z + 1);
        }

        public static bool operator <=(Point3D a, Point3D b)
        {
            return a.Radius <= b.Radius;
        }
        
        public static bool operator >=(Point3D a, Point3D b)
        {
            return a.Radius >= b.Radius;
        }

        public static bool operator true(Point3D a)
        {
            return a.x >= 0 && a.y <= 0 && a.z > 0;
        }
        
        public static bool operator false(Point3D a)
        {
            return a.x < 0 || a.y > 0 || a.z <= 0;
        }

        public static bool operator &(Point3D a, Point3D b)
        {
            if (a)
            {
                if (b)
                {
                    return true;
                }

                return false;
            }

            return false;
        }
        
        public static bool operator |(Point3D a, Point3D b)
        {
            if (a)
            {
                return true;
            }

            if (b)
            {
                return true;
            }

            return false;
        }

        public static Point3D operator >> (Point3D a, int num)
        {
            try
            {
                Point3D.CheckValues(a.x + num, a.y + num, a.z + num);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Number {num} can't be added to the point because " +e.Message);
                return a;
            }
            return new Point3D(a.x + num, a.y + num, a.z + num);
        }

        /*public void Add(Point3D term)
        {
            try
            {
                Point3D.CheckValues(x + term.X, y + term.Y, z + term.Z);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Number {term} can't be added to the point because " +e.Message);
                return;
            }
            x += term.X;
            y += term.Y;
            z += term.Z;
        }*/
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
            Bib = Bib + 1;
            Console.WriteLine(Bib.Coordinates);
            
            Console.WriteLine("Создадим Джона. Введите его x и y координаты через запятую без пробелов");
            Point3D John = Point3D.CreatePoint(Convert.ToDecimal(Console.ReadLine()));


            Console.WriteLine("Прибавим Джона к Бибу");
            Bib += John;
            Console.WriteLine(Bib.Coordinates);
            
            Console.WriteLine("Анна Олеговна хочет мейн - мейн она получит. Создадим Саню, Ваню, и Аню.");
            Point3D Sanya = Point3D.CreatePoint(5, 3, 3);
            Point3D Vanya = Point3D.CreatePoint(4, 5, 4);            
            Point3D Anya = Point3D.CreatePoint(5, 5, 5);
            Console.WriteLine("Их координаты: " + Sanya.Coordinates +", " + Vanya.Coordinates + ", " + Anya.Coordinates);
            
            Console.WriteLine("Саня - Ваня: " + (Sanya-Vanya).Coordinates);
            Console.WriteLine("Саня - 5: " + (Sanya-5).Coordinates);
            Console.WriteLine("Ваня++: " + Vanya++.Coordinates);
            Console.WriteLine("Ваня--: " + Vanya--.Coordinates);
            Console.WriteLine("Саня >= Ваня: " + (Sanya >= Vanya));
            Console.WriteLine("Саня <= Ваня: " + (Sanya <= Vanya));
            Console.WriteLine("Саня & Ваня: " + (Sanya&Vanya));
            Console.WriteLine("Саня | Аня: " + (Sanya|Vanya));
            Console.WriteLine("Саня >> 5: " + (Sanya >> 5).Coordinates);
            //P.S. Работу свойств X, Y, Z я уже демонстрирую в других методах/свойствах
        }
    }
}