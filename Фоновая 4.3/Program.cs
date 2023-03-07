using System;
using System.IO;

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
    
    public struct Lesson
    {
        public int Classroom;
        public Teachers Teacher;
        public string Group;
        public Subjects Subject;
        public int Number;
    }
    
    
    internal class Program
    {
        public static Lesson[,] schedule;
        
        public static void Main(string[] args)
        {
            StreamReader scheduleText = new StreamReader("Schedule.txt");
            int classes = Convert.ToInt32(scheduleText.ReadLine());
            int lessons = Convert.ToInt32(scheduleText.ReadLine());
            for (int i = 0; i < classes * lessons; i++)
            {
                Lesson lesson = new Lesson();
                lesson.Classroom = Convert.ToInt32(scheduleText.ReadLine());
                lesson.Teacher = (Teachers)Convert.ToInt32(scheduleText.ReadLine());
                lesson.Group = scheduleText.ReadLine();
                lesson.Subject = (Subjects)Convert.ToInt32(scheduleText.ReadLine());
                lesson.Number = Convert.ToInt32(scheduleText.ReadLine());
            }
        }
    }
}