using System;
using System.Collections;

namespace Tumakov11
{
    internal class Program
    {
        static void Main()
        {
            //Task1(); дописать красивое удаление
            //Task2(); написать 
            //Task3(); дописать удаление
            //Task4(); написать 
        }
        static void Task1()
        {
            BankAccount bankAccount1 = new BankAccountFactory().CreateProduct(123, BankAccount.Account.Текущий);
            BankAccount bankAccount2 = new BankAccountFactory().CreateProduct(321, BankAccount.Account.Текущий);
            BankAccount bankAccount3 = new BankAccountFactory().CreateProduct(111, BankAccount.Account.Сберегательный);

            foreach (DictionaryEntry de in BankAccountFactory.HTAccounts)
            {
                Console.WriteLine($"{de.Value}");
            }

            Console.WriteLine("-------------\n");
            BankAccountFactory.DeleteAccount(bankAccount2.Id);

            foreach (DictionaryEntry de in BankAccountFactory.HTAccounts)
            {
                Console.WriteLine($"{de.Value}");
            }
        }
        static void Task2()
        {

        }
        static void Task3()
        {
            Building building1 = new BuildingFactory().CreateBuilding(90, 30, 540, 2);
            Building building2 = new BuildingFactory().CreateBuilding(120, 30, 120, 1);
            Building building3 = new BuildingFactory().CreateBuilding(90, 30, 270, 2);


            foreach (DictionaryEntry de in BuildingFactory.HTBuildings)
            {
                Console.WriteLine($"{de.Value}");
            }

            Console.WriteLine("\n-------------\n");
            BuildingFactory.DeleteBuilding(2);
            BuildingFactory.DeleteBuilding(4);

            foreach (DictionaryEntry de in BuildingFactory.HTBuildings)
            {
                Console.WriteLine($"{de.Value}");
            }
        }
        static void Task4()
        {

        }
    }
}
