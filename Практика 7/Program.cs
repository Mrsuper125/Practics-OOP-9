using System;

namespace Практика_9
{
    class Program
    {

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

        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine(third(N));
            Console.ReadKey();
        }
    }
}