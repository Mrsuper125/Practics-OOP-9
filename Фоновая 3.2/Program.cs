using System;
using System.Linq;

namespace Фоновая_3._2
{
    internal class Program
    {

        public static int CompareStrings(string s1, string s2)  // I use int because first string can be bigger, less or be equal
        {
            if (s1.Length != s2.Length)
            {
                if (s1.Length > s2.Length)
                {
                    return 1;
                }
                else return -1;
            }
            else
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1[i] > s2[i])
                    {
                        return 1;
                    }
                    else if (s1[i] < s2[i])
                    {
                        return -1;
                    }
                }
            
                return 0;
            }
        }

        public static string AddBigNumbers(string s1, string s2)      //it works only if first string is longer or equal to second
        {
            s1 = new string(s1.ToCharArray().Reverse().ToArray());     //Подсмотрено из инета. Анна Олеговна, я знаю, что мы это не проходили, но это возможно реализовать и циклом + методами строк, просто будет уродливо.
            s2 = new string(s2.ToCharArray().Reverse().ToArray());
            int additional1 = 0;
            string res = "";
            int toAdd = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (i <= s2.Length - 1)
                {
                    toAdd += Convert.ToInt32(s2[i] - '0');
                }

                toAdd += additional1;
                additional1 = 0;
                toAdd += Convert.ToInt32(s1[i] - '0');
                if (toAdd > 9)
                {
                    toAdd -= 10;
                    additional1 = 1;
                }
                res = String.Concat(res, toAdd.ToString());
                toAdd = 0;
            }

            if (additional1 == 1)
            {
                res = String.Concat("1", res);
            }

            return new string(res.ToCharArray().Reverse().ToArray());
        }
        
        public static string SubtractBigNumbers(string s1, string s2, bool negative)      //it works only if first string is longer or equal to second
        {
            s1 = new string(s1.ToCharArray().Reverse().ToArray());     //Подсмотрено из инета. Анна Олеговна, я знаю, что мы это не проходили, но это возможно реализовать и циклом + методами строк, просто будет уродливо.
            s2 = new string(s2.ToCharArray().Reverse().ToArray());
            int additional1 = 0;
            string res = "";
            int toWriteToRes = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (i <= s2.Length - 1)
                {
                    toWriteToRes -= Convert.ToInt32(s2[i] - '0');
                }

                toWriteToRes -= additional1;
                additional1 = 0;
                toWriteToRes += Convert.ToInt32(s1[i] - '0');
                if (toWriteToRes < 0)
                {
                    toWriteToRes += 10;
                    additional1 = 1;
                }
                res = String.Concat(res, toWriteToRes.ToString());
                toWriteToRes = 0;
            }

            res = new string(res.ToCharArray().Reverse().ToArray());
            
            while (res[0] == '0')
            {
                res = res.Substring(1);
            }
            
            if (negative)
            {
                res = String.Concat("-", res);
            }
            
            return res;
        }
        
        public static void Main(string[] args)
        {

            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            char sign = Console.ReadLine()[0];      //quickly convert string to char
            int diff = CompareStrings(s1, s2);

            string bigger;
            string smaller;
            
            if (CompareStrings(s1, s2) >= 0)
            {
                bigger = s1;
                smaller = s2;
            }
            else
            {
                bigger = s2;
                smaller = s1;
            }

            if (sign == '-')
            {
                if (diff == 0)
                {
                    Console.WriteLine(0);
                }
                else if (diff == 1)
                {
                    Console.WriteLine(SubtractBigNumbers(bigger, smaller, false));
                }
                else
                {
                    Console.WriteLine(SubtractBigNumbers(bigger, smaller, true));
                }
            }
            else
            {
                Console.WriteLine(AddBigNumbers(bigger, smaller));
            }
        }
    }
}