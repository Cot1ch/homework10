using System;
using System.Collections;
using System.Runtime.Remoting.Lifetime;

namespace Tumakov11
{
    internal class Program
    {
        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4();
        }

        /// <summary>
        /// Упражнение 11.1. 
        /// Создать новый класс, который будет являться фабрикой объектов класса банковский счет.
        /// Изменить модификатор доступа у конструкторов класса банковский счет на
        /// internal. Добавить в фабричный класс перегруженные методы создания счета CreateAccount,
        /// которые бы вызывали конструктор класса банковский счет и возвращали номер созданного
        /// счета.Использовать хеш-таблицу для хранения всех объектов банковских счетов в фабричном классе.
        /// </summary>
        static void Task1()
        {
            Console.WriteLine("Упражнение 11.1\n");

            BankAccount bankAccount1 = new BankAccountFactory().CreateProduct(123, BankAccount.Account.Текущий);
            BankAccount bankAccount2 = new BankAccountFactory().CreateProduct(321, BankAccount.Account.Текущий);
            BankAccount bankAccount3 = new BankAccountFactory().CreateProduct(111, BankAccount.Account.Сберегательный);

            foreach (DictionaryEntry de in BankAccountFactory.HTAccounts)
            {
                Console.WriteLine($"{de.Value}");
            }

            Console.WriteLine("-------------");
            if (BankAccountFactory.DeleteAccount(bankAccount2.Id))
            {
                Console.WriteLine("Аккаунт удалён");
            }
            Console.WriteLine("-------------\n");

            foreach (DictionaryEntry de in BankAccountFactory.HTAccounts)
            {
                Console.WriteLine($"{de.Value}");
            }
        }

        /// <summary>
        /// Упражнение 11.2. 
        /// Разбить созданные классы, связанные с банковским счетом, и тестовый
        /// пример в разные исходные файлы. Разместить классы в одно пространство имен и создать сборку. 
        /// Подключить сборку к проекту и откомпилировать тестовый пример со сборкой.
        /// </summary>
        static void Task2()
        {
            Console.WriteLine("Упражнение 11.2\n");

            BankAccount bankAccount1 = new BankAccountFactory().CreateProduct(123, BankAccount.Account.Текущий);
            BankAccount bankAccount2 = new BankAccountFactory().CreateProduct(321, BankAccount.Account.Текущий);
            BankAccount bankAccount3 = new BankAccountFactory().CreateProduct(111, BankAccount.Account.Сберегательный);

            foreach (DictionaryEntry de in BankAccountFactory.HTAccounts)
            {
                Console.WriteLine($"{de.Value}");
            }

            Console.WriteLine("-------------");
            if (BankAccountFactory.DeleteAccount(bankAccount2.Id))
            {
                Console.WriteLine("Аккаунт удалён");
            }
            Console.WriteLine("-------------\n");

            foreach (DictionaryEntry de in BankAccountFactory.HTAccounts)
            {
                Console.WriteLine($"{de.Value}");
            }
        }

        /// <summary>
        /// Домашнее задание 11.1. 
        /// Для реализованного класса из домашнего задания 7.1 создать новый класс Creator, 
        /// который будет являться фабрикой объектов класса здания.
        /// Для этого изменить модификатор доступа к конструкторам класса, в новый созданный класс добавить
        /// перегруженные фабричные методы CreateBuild для создания объектов класса здания.
        /// В классе Creator все методы сделать статическими, конструктор класса сделать закрытым.
        /// Для хранения объектов класса здания в классе Creator использовать хеш-таблицу.
        /// Предусмотреть возможность удаления объекта здания по его уникальному номеру из хеш-таблицы.
        /// </summary>
        static void Task3()
        {
            Console.WriteLine("Домашнее задание 11.1\n");

            Building building1 = new BuildingFactory().CreateBuilding(90, 30, 540, 2);
            Building building2 = new BuildingFactory().CreateBuilding(120, 30, 120, 1);
            Building building3 = new BuildingFactory().CreateBuilding(90, 30, 270, 2);


            foreach (DictionaryEntry de in BuildingFactory.HTBuildings)
            {
                Console.WriteLine($"{de.Value}");
            }

            Console.WriteLine("\n-------------");

            ulong[] del = new ulong[]{2, 4};
            foreach (ulong i in del)
            {
                if (BuildingFactory.DeleteBuilding(i))
                {
                    Console.WriteLine($"{i}: Удалено");
                }
                else
                {
                    Console.WriteLine($"{i}: Такого номера нет");
                }
            }
            Console.WriteLine("-------------\n");


            foreach (DictionaryEntry de in BuildingFactory.HTBuildings)
            {
                Console.WriteLine($"{de.Value}");
            }
        }

        /// <summary>
        /// Домашнее задание 11.2. 
        /// Разбить созданные классы (здания, фабричный класс) и тестовый пример в разные исходные файлы.
        /// Разместить классы в одном пространстве имен.Создать сборку (DLL), включающие эти классы.
        /// Подключить сборку к проекту и откомпилировать тестовый пример со сборкой. 
        /// Получить исполняемый файл, проверить с помощью утилиты ILDASM, 
        /// что тестовый пример ссылается на сборку и не содержит в себе классов здания и Creator.
        /// </summary>
        static void Task4()
        {
            Console.WriteLine("Домашнее задание 11.2\n");

            Building building1 = new BuildingFactory().CreateBuilding(90, 30, 540, 2);
            Building building2 = new BuildingFactory().CreateBuilding(120, 30, 120, 1);
            Building building3 = new BuildingFactory().CreateBuilding(90, 30, 270, 2);


            foreach (DictionaryEntry de in BuildingFactory.HTBuildings)
            {
                Console.WriteLine($"{de.Value}");
            }

            Console.WriteLine("\n-------------");

            ulong[] del = new ulong[] { 2, 4 };
            foreach (ulong i in del)
            {
                if (BuildingFactory.DeleteBuilding(i))
                {
                    Console.WriteLine($"{i}: Удалено");
                }
                else
                {
                    Console.WriteLine($"{i}: Такого номера нет");
                }
            }
            Console.WriteLine("-------------\n");


            foreach (DictionaryEntry de in BuildingFactory.HTBuildings)
            {
                Console.WriteLine($"{de.Value}");
            }
        }
    }
}
