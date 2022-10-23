using System;

namespace Бинарный_поиск
{
    internal class Program
    {
        public static void eqation1()
        {
            double y = Double.Parse(Console.ReadLine());

            double l = 0.0;
            double r = 10000000000.0;
    
            double m = (l+r)/2;
    
            double res;
    
            for(int i = 0; i < 1000; i++){
                res = m + Math.Sqrt(m);
                if(Math.Round(res, 2) == Math.Round(y, 2)) break;
                if (res > y)
                    r = m;
                else l = m;
                m = (l+r)/2;
            }
    
            Console.WriteLine(Math.Round(m, 2));
        }

        public static void lyceumAdministration()
        {
            int n = Int32.Parse(Console.ReadLine());
            int k = Int32.Parse(Console.ReadLine());

            if (k > (n / 3))
            {
                Console.WriteLine(0);
                return;
            }

            int l = 0;
            int r = n;
            int m = (l + r) / 2;
            while (r - l > 1)
            {
                m = (r + l) / 2;
                if ((n + m) / (k + m) < 3)
                {
                    r = m;
                }
                else
                {
                    l = m;
                }
            }
            
            Console.WriteLine(m);
        }

        public static void veryEasyTask()
        {
            int N = Int32.Parse(Console.ReadLine());
        }
        
        public static void Main(string[] args)
        {
            lyceumAdministration();
        }
    }
}