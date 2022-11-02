using System;

namespace Практика_9
{
    class Program
    {

        static int BCD(int x, int y)        // biggest common divider = НОД
        {
            while (x != y)
            {
                if (x > y) x -= y;
                else y -= x;
            }

            return x;
        }

        static void remainder()
        {
            int A = int.Parse(Console.ReadLine());
            int B = int.Parse(Console.ReadLine());
            Console.WriteLine(A % B);
        }

        static string first(int n)
        {
            int res = 0;
            int current = 0;
            while (n != 0)
            {
                current = n % 10;
                if (current < 8 && current % 3 != 0 && current % 4 != 0)
                {
                    res++;
                }

                n = n / 10;
            }

            if (res == 0) return "NO";
            else return $"{res}";
        }

        static int second(int n)
        {
            int res = 0;
            int end = 0;
            int prev = 0;
            while (n != 0)
            {
                end = n % 10;
                prev = (n % 100) / 10;
                if ((end + prev) % 2 == 0)
                {
                    res += (end + prev);
                }

                n = n / 10;
            }

            return res;
        }

        static bool third(int n)
        {
            int len = 0;
            int copy = n;
            int left = 0;
            int right = 0;
            while (copy != 0)
            {
                len++;
                copy /= 10;
            }

            for (int i = 0; i < len / 2; i++)
            {
                right += n % 10;
                n /= 10;
            }

            if (len % 2 != 0)
            {
                right += n % 10;
            }

            while (n != 0)
            {
                left += n % 10;
                n /= 10;
            }

            return (left == right);
        }

        static void fourth(int p, int q)
        {
            for (int i = 2; i < Math.Sqrt(q); i++)
            {
                if (BCD(i, p) != 1)
                {
                    Console.WriteLine(i);
                }
                if (BCD(q / i, p) != 1)
                {
                    Console.WriteLine(q / i);
                }
            }
            if (BCD((int)Math.Sqrt(q), p) != 1)
            {
                Console.WriteLine((int)Math.Sqrt(q));
            }
        }

        static int fifth()
        {
            int res = 0;
            for (int x = 16; x <= 25; x++)
            {
                for (int i = 1; i < Math.Sqrt(x); i++)
                {
                    if (x % i == 0)
                    {
                        res += i;
                        res += x / i;
                    }
                    if (Math.Pow((int)(Math.Sqrt(x)), 2) == x)
                    {
                        res += (int)(Math.Sqrt(x));
                    }
                }
            }
            return res;
        }

        static int sixth(int x)
        {
            int res = 0;
            int copy = x;
            int len = 0;
            while (copy > 0)
            {
                len++;
                copy /= 10;
            }
            int multiplier = (int)Math.Pow(-1, len - 1);
            while (x > 0)
            {
                res += multiplier * (x % 10);
                x /= 10;
                multiplier *= -1;
            }
            return res;
        }

        static void additional1() {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            string res = "";
            if (m > n) m = m % n;
            for (int i = 0; i < 50; i++)
            {
                if (m == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
                m *= 10;
                res += $"{m / n}";
                m %= n;
            }
            Console.WriteLine(res);
        }   

        static void Main()
        {
            additional1();
            Console.ReadKey();
        }
    }
}

