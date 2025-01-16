using System;
using System.Collections.Generic;
using System.IO;


namespace homework10
{
    internal class Event
    {
        string _Name;
        DateTime _Date;
        int _CountStud;
        List<VMKshnik> students;


        public Event(string name, DateTime date, int countStud)
        {
            _Name = name;
            _Date = date;
            _CountStud = countStud;
            students = new List<VMKshnik>();
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public int CountStud
        {
            get { return _CountStud; }
            set { _CountStud = value; }
        }

        public List<VMKshnik> Students
        { 
            get { return students; }
            set { students = value; }
        }


        /// <summary>
        /// Принимает информацию о дате рождения и преобразовывает к типу DateTime
        /// </summary>
        /// <returns>Объект типа DateTime</returns>
        public static DateTime EnterDate()
        {
            DateTime date = DateTime.Now;
            bool flag = true;
            Console.WriteLine("Введите дату в формате dd.MM.yyyy");
            do
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime resultDate) && resultDate > DateTime.Now)
                {
                    date = resultDate;
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Введите грядущую дату в формате dd.MM.yyyy");
                }
            }
            while (flag);

            return date;
        }

        /// <summary>
        /// Считывает строку символов с консоли и преобразует ее к целому неотрицательному числу. Ввод продолжается до тех пор, 
        /// пока пользователь не введет число.
        /// </summary>
        /// <returns>Число типа int</returns>
        public static int EnterInt(int maxVal)
        {
            bool flag = true;
            int number;
            do
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out number);
                if (isNumber && number <= maxVal)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine($"Неверный ввод - необходимо ввести натуральное число num <= {maxVal}");
                }
            }
            while (flag);

            return number;
        }

        public void WriteEventToFile(string path)
        {
            File.AppendAllText(path, Name + " " + Date + "\n");
            foreach (VMKshnik stud in Students)
            {
                File.AppendAllText(path, stud.ToString());
            }
        }
    }
}
