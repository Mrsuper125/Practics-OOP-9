using System;

namespace Творческая_архиватор
{
    class Program
    {
        private static ulong data;

        static void ReadAllData(sbyte cell)
        {
            ulong mask = 0x8000000000000000;
            for (sbyte i = 15; i >=0; i--)
            {
                if (i==cell)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                for (int j = 0; j < 4; j++)
                {
                    Console.Write((data & mask)==0?0:1);
                    mask >>= 1;
                }
                Console.Write(" ");
                if (i==cell)
                {
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }

        static int ReadCell(sbyte cell)
        {
            ulong mask = 1;
            mask <<= cell * 4;
            int digit;
            int res = 0;
            for (digit = 1; digit <= 8; digit*=2)
            {
                if ((data & mask) != 0)
                {
                    res += digit;
                }

                mask <<= 1;
            }
            return res;
        }

        static void WriteToCell(sbyte number,sbyte cell)
        {
            ulong mask = 1;
            mask <<= cell * 4 + 3;
            int power;
            for (power = 3; power >= 0; power--)
            {
                data = data & ~mask;
                if (number - Math.Pow(2, power) >= 0)
                {
                    number -= (sbyte)Math.Pow(2, power);
                    data = data | mask;
                }

                mask >>= 1;
            }
        }

        static sbyte FindFreeCell()
        {
            for (sbyte i = 0; i < 16; i++)
            {
                if (ReadCell(i) == 0)
                {
                    return i;
                }
            }

            return 16;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в архиватор! Вы можете занести число, прочитать ячейку и очистить ячейку при помощи команд з, п, о");
            Console.WriteLine("Пример команды: з 15");
            while (true)
            {
                string input = Console.ReadLine();
                var splitInput = input.Split();
                string command = splitInput[0];
                var number = Convert.ToSByte(splitInput[1]);        // Пришлось совсем чуть-чуть прибегнуть к спискам Ради красивого интерфейса, могу переделать на уродский но без списков
                switch (command)
                {
                    case "з":
                        if (number > 15)
                        {
                            Console.WriteLine("Ошибка, число больше 15");
                            break;
                        }

                        sbyte freeCell = FindFreeCell();
                        if (freeCell == 16)
                        {
                            Console.WriteLine("Место закончилось");
                            ReadAllData(15);
                            break;
                        }
                        WriteToCell(number, freeCell);
                        ReadAllData(freeCell);
                        break;
                    
                    case "о":
                        if (number > 15)
                        {
                            Console.WriteLine("Ошибка, номер ячейки больше 15");
                        }
                        else
                        {
                            WriteToCell(number, 0);
                        }
                        ReadAllData(number);
                        break;
                    
                    case "п":
                        if (number > 15)
                        {
                            Console.WriteLine("Ошибка, номер ячейки больше 15");
                        }
                        else
                        {
                            Console.WriteLine(ReadCell(number));
                        }
                        ReadAllData(number);
                        break;
                    default:
                        Console.WriteLine("Введите корректную команду");
                        break;
                }
            }
        }
    }
}