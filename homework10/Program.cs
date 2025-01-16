using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;


namespace homework10
{
    internal class Program
    {
        static void Main()
        {
            // Ребят, скиньтесь Ане Харламовой на билет на BTS

            Task1();
            //Task2(); // ПОльзователь! идет в пенек
        }
        static void Task1()
        {
            Console.WriteLine("1 задача\n");

            List<VMKshnik> students = new List<VMKshnik>();
            string fileWStudInfo = $"{Directory.GetCurrentDirectory()}..\\..\\..\\..\\resourses\\students.txt";

            string nameNDate = String.Empty;
            string outputFile = $"{Directory.GetCurrentDirectory()}..\\..\\..\\..\\resourses\\{nameNDate}.txt";

            




        }
        public delegate bool VMKshnikEventHandler();
        public event VMKshnikEventHandler Check;



        static void Task2()
        {
            Console.WriteLine("2 задача\n");

            Person vasyan = new Person("Васян", "Хоббихорсинг");
            Person petya = new Person("Петя", "Чёрные пазлы");
            Person masha = new Person("Маша", "Горловое пение");

            List<Person> list = new List<Person>() { vasyan, petya, masha };
            Dictionary<string, List<string>> events = new Dictionary<string, List<string>>();

            events["Выход новой линейки чёрных пазлов"] = new List<string>() { "пазл", "чёрн" };
            events["Открытие ещё более чёрного цвета"] = new List<string>() { "чёрн" };
            events["Концерт мастеров горлового пения планеты Глюк"] = new List<string>() { "горл" };
            events["Открытие новой площадки для хоббихорсинга в Казани"] = new List<string>() { "хоббихорс" };



            Notify += CheckHobby;

            foreach (KeyValuePair<string, List<string>> kv in events)
            {
                Notify.Invoke(list, kv);
            }
        }
        public static void CheckHobby(List<Person> persons, KeyValuePair<string, List<string>> evnt)
        {
            Console.WriteLine($"\n>>> {evnt.Key} <<<\n");
            foreach (Person person in persons)
            {
                foreach (string hash in evnt.Value)
                {
                    if (person.Hobby.ToLower().Contains(hash))
                    {
                        Console.WriteLine($"{person.Name} теперь немножко счастливее");
                        break;
                    }
                }
            }
        }
        public delegate void EventHandler(List<Person> persons, KeyValuePair<string, List<string>> evnt);
        public static event EventHandler Notify;

        static int ParseInt(string num)
        {
            if (int.TryParse(num, out int result) && (0 < result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }
    }
}
