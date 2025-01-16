using System;
using System.Collections.Generic;
using System.IO;


namespace homework10
{
    internal class Program
    {
        static void Main()
        {
            // Ребят, давайте организуем сбор Ане Харламовой на концерт BTS
            // И давайте уже откроем кофейню на 9 этаже, всем же удобнее будет в субботу

            Task1();
            Task2();


        }

        /// <summary>
        /// 1 задача. 
        /// Студентам периодически необходимо участвовать в различных мероприятиях (студенты могут быть в разных группах).
        /// Участвовать каждый студент во всех мероприятиях не должен. Однако существуют студенты-халявщики, 
        /// которые не хотят делать вообще ничего. Поэтому было решено, что человек, 
        /// не участвовавший ни в одном из последних трех мероприятий с большей вероятностью будет выбран в качестве участника.
        /// Необходимо создать программу, которая будет из текстового файла считывать всех студентов
        /// и их принадлежность к группе. Далее пользователь создает мероприятие с необходимым количеством участников, 
        /// оно записывается в специально созданный файл. Далее дозаписать в файл с мероприятием всех участников мероприятия.
        /// </summary>
        static void Task1()
        {
            Console.WriteLine("1 задача\n");

            Check += ChooseStudents;


            List<VMKshnik> students = new List<VMKshnik>();
            List<Event> events = new List<Event>()
            {
                new Event("МиМ", DateTime.Now.AddMonths(-1), 7), new Event("СтудБаттл", DateTime.Now.AddMonths(-2), 5), new Event("Посвят", DateTime.Now.AddMonths(-3), 4)
            };
            events[0].Students = new List<VMKshnik>{new VMKshnik("Семён", "Берсенев", 1, false),
                                                    new VMKshnik("Никита", "Боронин", 1, false),
                                                    new VMKshnik("Данис", "Валетдинов", 1, false),
                                                    new VMKshnik("Арина", "Гомза", 1, false),
                                                    new VMKshnik("Алиджан", "Джумакулыев", 1, false),
                                                    new VMKshnik("Айназ", "Закиров", 1, false),
                                                    new VMKshnik("Алмаз", "Калимуллин", 1, false)};
            events[1].Students = new List<VMKshnik>{new VMKshnik("Всеволод", "Квятковский", 1, true),
                                                    new VMKshnik("Анастасия", "Кузьмина", 1, true),
                                                    new VMKshnik("Софья", "Меркулова", 1, false),
                                                    new VMKshnik("Анастасия", "Новикова", 1, false),
                                                    new VMKshnik("Семён", "Осипов", 2, true)};
            events[2].Students = new List<VMKshnik>{new VMKshnik("Всеволод", "Квятковский", 1, true),
                                                    new VMKshnik("Анастасия", "Кузьмина", 1, true),
                                                    new VMKshnik("Софья", "Меркулова", 1, false),
                                                    new VMKshnik("Анастасия", "Новикова", 1, false),
                                                    new VMKshnik("Семён", "Осипов", 2, true)};


            string fileWStudInfo = $"{Directory.GetCurrentDirectory()}..\\..\\..\\resourses\\students.txt";
            ReadStudFromFile(out students, fileWStudInfo);

            bool flag = true;
            do
            {
                Console.WriteLine("Выход/Новое событие");

                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "выход":
                        flag = false;
                        break;

                    case "новое событие":
                        Check.Invoke(ref events, ref students);
                        break;

                    default:
                        Console.WriteLine("Нет такого варианта");
                        break;
                }
            }
            while (flag);
        }
        
        /// <summary>
        /// Делегат для события Check
        /// </summary>
        delegate void VMKshnikEventHandler(ref List<Event> events, ref List<VMKshnik> students);

        /// <summary>
        /// Событие, происходящее при вводе нового студенческого мероприятия. 
        /// Выбирает из списка студентов тех, кто отправится на данное мероприятие
        /// </summary>
        static event VMKshnikEventHandler Check;

        /// <summary>
        /// Метод выбирает из списка студентов тех, кто хочет идти на мероприятие / не хочет идти никуда
        /// </summary>
        static void ChooseStudents(ref List<Event> events, ref List<VMKshnik> students)
        {
            events.Add(EnterEvent(students.Count));
            int i = events[events.Count - 1].CountStud;
            int k = 0;
            while (i > 0 && k < students.Count)
            {
                if (students[k].Wanting == true)
                {
                    events[events.Count - 1].Students.Add(students[k]);
                    i--;
                }
                else
                {
                    bool fl = false;
                    for (int j = 1; j < 4; j++)
                    {
                        if (events[events.Count - j].Students.Contains(students[k]))
                        {
                            fl = true;
                        }
                    }
                    if (!fl)
                    {
                        events[events.Count - 1].Students.Add(students[k]);
                        i--;
                    }
                }
                k++;
            }
            string nameNDate = $"{events[events.Count - 1].Name}";
            string outputFile = $"{Directory.GetCurrentDirectory()}..\\..\\..\\resourses\\{nameNDate}.txt";

            events[events.Count - 1].WriteEventToFile(outputFile);
        }

        /// <summary>
        /// Метод ввода нового мероприятия
        /// </summary>
        /// <returns>Объект типа Event</returns>
        static Event EnterEvent(int mv)
        {
            Console.WriteLine("Введите название мероприятия");
            string name = Console.ReadLine();
            Console.WriteLine("Введите дату мероприятия");
            DateTime date = Event.EnterDate();
            Console.WriteLine("Введите количество студентов");
            int countStudents = Event.EnterInt(mv);

            Event ev = new Event(name, date, countStudents);

            return ev;
        }

        /// <summary>
        /// Метод записывает данные о студентах с файла в коллекцию
        /// </summary>
        static void ReadStudFromFile(out List<VMKshnik> studs, string path)
        {
            studs = new List<VMKshnik>();
            if (File.Exists(path))
            {
                string[] allStud = File.ReadAllLines(path);

                for (int i = 0; i < allStud.Length; i++)
                {
                    string[] splitStud = allStud[i].Split(' ');

                    if (ParseInt(splitStud[2]) == -1)
                    {
                        Console.WriteLine($"Ошибка в записи номера шруппы на {i + 1} строке");
                    }
                    else if (splitStud.Length == 3)
                    {
                        studs.Add(new VMKshnik(splitStud[0], splitStud[1], ParseInt(splitStud[2]), false));
                    }
                    else if (splitStud.Length == 4)
                    {
                        studs.Add(new VMKshnik(splitStud[0], splitStud[1], ParseInt(splitStud[2]), true));
                    }
                    else
                    {
                        Console.WriteLine($"Неверный формат записи студента на {i+1} строке");
                    }
                }
            }
        }

        /// <summary>
        /// 2 задача.
        /// У каждого есть хобби. Написать программу для слежения за интересующим вас событием (выход сериала, концерт и т.д.)
        /// Создать не менее трех человек с разными увлечениями. 
        /// Пользователь вводит |не успель((| (можно из заранее определенного списка) событие.
        /// Если событие совпало с увлечением кого-либо, вывести его реакцию на событие
        /// </summary>
        static void Task2()
        {
            Console.WriteLine("\n2 задача");

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

        /// <summary>
        /// Метод проверяет, будет ли полезно кому-то событие
        /// </summary>
        static void CheckHobby(List<Person> persons, KeyValuePair<string, List<string>> evnt)
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

        /// <summary>
        /// Делегат для события Notify
        /// </summary>
        delegate void EventHandler(List<Person> persons, KeyValuePair<string, List<string>> evnt);

        /// <summary>
        /// Событие, происходящее при вводе нового мероприятия
        /// </summary>
        static event EventHandler Notify;

        /// <summary>
        /// Метод преобразовывает, если это возможно, строку в число int.
        /// Через tryparsed cfvjv rjlt не читабельно становится
        /// </summary>
        /// <returns>Число типа int</returns>
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
