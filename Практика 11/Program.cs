using System;

namespace Практика_11
{
    internal class Program
    {       //вариант 3
        public static int DigitsSum(string s)
        {
            int res = 0;
            foreach (var ch in s)
            {
                if (ch >= '0' && ch <= '9')
                {
                    res += Convert.ToInt32(ch.ToString());      //char to int convertation gives you symbol index instead of its meaning
                }
            }
            return res;
        }

        public static void CutBeforeColumn(ref string s)
        {
            string res = "";
            int columnIndex = s.LastIndexOf(':');
            for (int i = columnIndex+1; i < s.Length; i++)
            {
                res += s[i];
            }

            s = res;
        } 
        
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();
            CutBeforeColumn(ref s);
            Console.WriteLine(s);
        }
    }
}