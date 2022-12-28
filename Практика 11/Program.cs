using System;

namespace Практика_11
{
    internal class Program
    {       //вариант 3
        public static int DigitsSum(string s)
        {
            int res = 0;
            foreach (var ch in s){
                if (Char.IsDigit(ch)){
                    res += Convert.ToInt32(ch.ToString());
                }
            }
            return res;
        }

        public static void CutBeforeColumn(ref string s)
        {
            string res = "";
            int columnIndex = s.LastIndexOf(':');
            s = s.Substring(columnIndex+1);
        } 
    
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();
            CutBeforeColumn(ref s);
            Console.WriteLine(s);
        }
    }
}
