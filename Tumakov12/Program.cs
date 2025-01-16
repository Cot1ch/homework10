using System;

namespace Tumakov12
{
    internal class Program
    {
        static void Main()
        {
            //Task1();
            //Task2();
            //Task3();
            //Task4(); // запихнуть массив в отдельный класс
        }
        static void Task1()
        {
            BankAccount account1 = new BankAccount(1000, BankAccount.Account.Текущий);
            BankAccount account2 = new BankAccount(1000);
            BankAccount account3 = new BankAccount(1000, BankAccount.Account.Сберегательный);

            Console.WriteLine(account1.Equals(account2));
            Console.WriteLine(account1.Equals(account3));
        }
        static void Task2()
        {
            Ratio ratio1 = new Ratio(9, 5);
            Ratio ratio2 = new Ratio(9, 6);

            Console.WriteLine("x = " + ratio1.ToString());
            Console.WriteLine("y = " + ratio2.ToString());

            Console.WriteLine($"x == y: {ratio1 == ratio2}");
            Console.WriteLine($"x != y: {ratio1 != ratio2}");

            Console.WriteLine($"x <= y: {ratio1 <= ratio2}");
            Console.WriteLine($"x >= y: {ratio1 >= ratio2}");
            Console.WriteLine($"x < y: {ratio1 < ratio2}");
            Console.WriteLine($"x > y: {ratio1 > ratio2}");

            Console.WriteLine($"x + y = {ratio1 + ratio2}");
            Console.WriteLine($"x - y = {ratio1 - ratio2}");
            Console.WriteLine($"x * y = {ratio1 * ratio2}");
            Console.WriteLine($"x / y = {ratio1 / ratio2}");
            Console.WriteLine($"x % y = {ratio1 % ratio2}");

            Console.WriteLine($"++x = {++ratio1}");
            Console.WriteLine($"--y = {--ratio2}");

            Console.WriteLine($"y to float = {ratio2.ToFloat()}");
            Console.WriteLine($"x to int = {ratio1.ToInt()}");            
        }
        static void Task3()
        {
            Complex complex1 = new Complex(2, 1);
            Complex complex2 = new Complex(2, -1);

            Console.WriteLine(complex1.ToString());
            Console.WriteLine(complex2.ToString());

            Console.WriteLine(complex1 == complex2);
            Console.WriteLine(complex1 != complex2);

            Console.WriteLine(complex1 + complex2);
            Console.WriteLine(complex1 - complex2);
            Console.WriteLine(complex1 * complex2);
            Console.WriteLine(complex1 / complex2);
        }

        static void Task4()
        {
            Book.Books.Add(new Book("1984", "Джордж Оруэлл", "Эксмо"));
            Book.Books.Add(new Book("Пятнадцатилетний капитан", "Жюль Верн", "АСТ"));
            Book.Books.Add(new Book("Понедельник начинается в субботу", "А. и Б. Стругацкие", "АСТ"));
            Book.Books.Add(new Book("Краткие ответы на большие вопросы", "Стивен Хокинг", "Бомбора"));


            BookSort sort1 = new BookSort(Book.SortingByName);
            BookSort sort2 = new BookSort(Book.SortingByAuthor);
            BookSort sort3 = new BookSort(Book.SortingByPublishing);

            Console.WriteLine("Сортировка по имени:\n");
            sort1();
            Book.LogBooks();

            Console.WriteLine("\nСортировка по автору:\n");
            sort2();
            Book.LogBooks();

            Console.WriteLine("\nСортировка по издательству:\n");
            sort3();
            Book.LogBooks();
        }
        delegate void BookSort();
    }
}
