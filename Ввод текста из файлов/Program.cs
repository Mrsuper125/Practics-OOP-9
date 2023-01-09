using System;
using System.IO;

namespace Ввод_текста_из_файлов
{
    internal class Program
    {
        public static int InARow(){
            int max = 0;
            StreamReader file = new StreamReader("Task-1.txt");
            int current = 0;
            char previous = ' ';
            string str = file.ReadLine();
            for (int i = 0; i < str.Length; i++){
                if(str[i]!=previous && str[i]!='Z'){
                    current++;
                }
                else{
                    current = 0;
                }
                if(current > max){
                    max = current;
                }
                previous = str[i];
            }
            return max;
        }

        public static int DigitsInARow()
        {
            int max = 0;
            StreamReader file = new StreamReader("Task-2.txt");
            int row = 0;
            string str = file.ReadLine();
            foreach (var ch in str)
            {
                if (Char.IsDigit(ch))
                {
                    row++;
                }
                else
                {
                    row = 0;
                }

                if (row > max)
                {
                    max = row;
                }
            }

            return max;
        }

        public static int WithBAndCButWithoutD()
        {
            int max = 0;
            StreamReader file = new StreamReader("Task-3.txt");
            bool B = false;
            bool C = false;
            int row = 0;
            string str = file.ReadLine();
            foreach (var ch in str)
            {
                switch (ch)
                {
                    case 'B':
                        B = true;
                        row++;
                        break;
                    case 'C':
                        C = true;
                        row++;
                        break;
                    case 'D':
                        B = false;
                        C = false;
                        row = 0;
                        break;
                    default:
                        row++;
                        break;
                }

                if (B && C && row > max)
                {
                    max = row;
                }
            }
            return (max);
        }
        
        public static void Main(string[] args)
        {
            Console.WriteLine(WithBAndCButWithoutD());
        }
    }
}