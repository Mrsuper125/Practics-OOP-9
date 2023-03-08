using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Instrumentation;
using System.Text.RegularExpressions;

namespace Фоновая_4._3
{
    public enum Subjects
    {
        Русский = 1,
        Математика,
        ООП
    }

    public enum Teachers
    {
        Ляхова_ИВ = 1,
        Солдатова_АВ,
        Терёхина_АО
    }

    public enum Groups
    {
        _9_1 = 1,
        _9_2,
        _9_3
    }

    public struct Lesson
    {
        public bool initialized;
        public int Classroom;
        public Teachers Teacher;
        public Groups Group;
        public Subjects Subject;
        public int Number;
    }
    
    
    internal class Program
    {
        public static Lesson[,] schedule;

        public static Lesson FindLessonByGroupAndNumber(Groups group, int number)
        {
            foreach (Lesson temp in schedule)
            {
                if (temp.Group == group && temp.Number == number)
                {
                    return temp;
                }
            }

            return new Lesson();
        }

        public static void Spaces(int amount)
        {
            for (int i = 0; i < amount; i++) Console.Write(" "); 
        }

        public static void PrintSchedule(Lesson[,] schedule, int columnWidth = 30)
        {
            Console.Write("Урок");
            for (int i = 0; i < schedule.GetLength(1); i++)
            {
                Spaces(columnWidth - ((columnWidth - ((Groups)(i + 1)).ToString().Length) / 2) - ((Groups)(i + 1)).ToString().Length);
                Console.Write($"{(Groups)(i+1)}");
                Spaces((columnWidth - ((Groups)(i + 1)).ToString().Length) / 2);
            }
            Console.Write("\n");

            for (int i = 0; i < schedule.GetLength(0); i++)
            {
                Console.Write("    ");
                for (int j = 0; j < schedule.GetLength(1); j++)
                {
                    Spaces(columnWidth - ((columnWidth - schedule[i,j].Classroom.ToString().Length) / 2) - schedule[i,j].Classroom.ToString().Length);
                    Console.Write($"{((schedule[i,j].initialized)?schedule[i,j].Classroom.ToString() : " ")}");
                    Spaces((columnWidth - schedule[i,j].Classroom.ToString().Length) / 2);
                }
                Console.Write("\n "+(i+1)+"  ");
                for (int j = 0; j < schedule.GetLength(1); j++)
                {
                    Spaces(columnWidth - ((columnWidth - schedule[i,j].Subject.ToString().Length) / 2) - schedule[i,j].Subject.ToString().Length);
                    Console.Write($"{((schedule[i,j].initialized)?schedule[i,j].Subject.ToString() : " ")}");
                    Spaces((columnWidth - schedule[i,j].Subject.ToString().Length) / 2);
                }
                Console.Write("\n    ");
                for (int j = 0; j < schedule.GetLength(1); j++)
                {
                    Spaces(columnWidth - ((columnWidth - schedule[i,j].Teacher.ToString().Length) / 2) - schedule[i,j].Teacher.ToString().Length);
                    Console.Write($"{((schedule[i,j].initialized)?schedule[i,j].Teacher.ToString() : " ")}");
                    Spaces((columnWidth - schedule[i,j].Teacher.ToString().Length) / 2);
                }
                Console.Write("\n");
            }
        }

        public static bool CheckTeachers()
        {
            List<Teachers> busyTeachersList;
            for (int i = 0; i < schedule.GetLength(0); i++)
            {
                busyTeachersList = new List<Teachers>();
                for (int j = 0; j < schedule.GetLength(1); j++)
                {
                    if (busyTeachersList.Contains(schedule[i, j].Teacher))
                    {
                        busyTeachersList.Add(schedule[i, j].Teacher);
                    }
                    else
                    {
                        throw new InvalidDataException("Два урока в одно и то же время у одного учителя");
                        return false;
                    }
                }
            }

            return true;
        }
        
        public static bool CheckClassrooms()
        {
            List<int> occupiedClassroomsList;
            for (int i = 0; i < schedule.GetLength(0); i++)
            {
                occupiedClassroomsList = new List<int>();
                for (int j = 0; j < schedule.GetLength(1); j++)
                {
                    if (occupiedClassroomsList.Contains(schedule[i, j].Classroom))
                    {
                        occupiedClassroomsList.Add(schedule[i, j].Classroom);
                    }
                    else
                    {
                        throw new InvalidDataException("Два урока в одно и то же время в одном классе");
                        return false;
                    }
                }
            }

            return true;
        }

        public static Lesson[] SelectionByLessonNumber(int lessonNumber)
        {
            Lesson[] res = new Lesson[schedule.GetLength(1)];
            for (int i = 0; i < schedule.GetLength(1); i++)
            {
                res[i] = schedule[lessonNumber - 1, i];     //Функция собирает в том числе и дыры, если надо без дыр можно быстро переделать на динамический массив, либо делать в 2 цикла
            }
            return res;
        }
        
        public static Lesson[] SelectionByGroup(Groups group)
        {
            Lesson[] res = new Lesson[schedule.GetLength(0)];
            for (int i = 0; i < schedule.GetLength(0); i++)
            {
                res[i] = schedule[i, (int)group - 1];     //Функция собирает в том числе и дыры, если надо без дыр можно быстро переделать на динамический массив, либо делать в 2 цикла
            }
            return res;
        }
        
        public static void Main(string[] args)
        {
            /*
             * Документация по вводу:
             * В начале файла в 2 строки пишется количество классов и уроков, после него - 1 пустая строка.
             * Каждый урок записан в блоке из 5 строк. Блоки разделяются пустыми строками.
             * В первой строке блока пишется кабинет. Он записывается просто числом.
             * Во второй строке пишется номер учителся, соответствующий его номеру в перечислении.
             * В третьей строке записывается вторая цифра номера группы (пока поддержка только 9 классов).
             * В четвёртой строке записывается номер предмета, соответствующий его номеру в перечислении.
             * В пятой строке записывается номер урока в расписании.
             */
            
            StreamReader scheduleText = new StreamReader("Schedule.txt");
            int groupsCount = Convert.ToInt32(scheduleText.ReadLine());
            int lessonsCount = Convert.ToInt32(scheduleText.ReadLine());
            schedule = new Lesson[lessonsCount,groupsCount];
            scheduleText.ReadLine();
            for (int i = 0; i < lessonsCount * groupsCount; i++)
            {
                if (scheduleText.EndOfStream) break;
                
                Lesson lesson = new Lesson();
                lesson.initialized = true;
                lesson.Classroom = Convert.ToInt32(scheduleText.ReadLine());
                lesson.Teacher = (Teachers)Convert.ToInt32(scheduleText.ReadLine());
                lesson.Group = (Groups)Convert.ToInt32(scheduleText.ReadLine());
                lesson.Subject = (Subjects)Convert.ToInt32(scheduleText.ReadLine());
                lesson.Number = Convert.ToInt32(scheduleText.ReadLine());
                scheduleText.ReadLine();
                
                if (!FindLessonByGroupAndNumber(lesson.Group, lesson.Number).initialized)
                {
                    schedule[lesson.Number - 1, (int)lesson.Group - 1] = lesson;
                }
                else
                {
                    throw new InvalidDataException("Два урока в одно время у одной группы");
                }
            }
            
            PrintSchedule(schedule);
            CheckTeachers();
            CheckClassrooms();
        }
    }
}