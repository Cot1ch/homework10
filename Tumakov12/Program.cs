using System;

namespace Tumakov12
{
    internal class Program
    {
        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4();

            Console.WriteLine("Пресс кнопочку пжалста");
            Console.ReadKey();
        }

        /// <summary>
        /// Упражнение 12.1. Для класса банковский счет переопределить операторы == и != для
        /// сравнения информации в двух счетах.Переопределить метод Equals аналогично оператору ==,
        /// не забыть переопределить метод GetHashCode(). 
        /// Переопределить метод ToString() для печати информации о счете.
        /// Протестировать функционирование переопределенных методов и операторов на простом примере.
        /// </summary>
        static void Task1()
        {
            Console.WriteLine("Упражнение 12.1\n");

            BankAccount account1 = new BankAccount(1000, BankAccount.Account.Текущий);
            BankAccount account2 = new BankAccount(1000);
            BankAccount account3 = new BankAccount(1000, BankAccount.Account.Сберегательный);

            Console.WriteLine(account1.Equals(account2));
            Console.WriteLine(account1.Equals(account3));
        }

        /// <summary>
        /// Упражнение 12.2. Создать класс рациональных чисел. В классе два поля – числитель и знаменатель.
        /// Предусмотреть конструктор.Определить операторы ==, != (метод Equals()), <,>, <=, >=, +, – , ++, --. 
        /// Переопределить метод ToString() для вывода дроби.
        /// Определить операторы преобразования типов между типом дробь, float, int. 
        /// Определить операторы *, /, %.
        /// </summary>
        static void Task2()
        {
            Console.WriteLine("\nУпражнение 12.2\n");

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

        /// <summary>
        /// Домашнее задание 12.1. На перегрузку операторов. Описать класс комплексных чисел.
        /// Реализовать операцию сложения, умножения, вычитания, проверку на равенство двух комплексных чисел.
        /// Переопределить метод ToString() для комплексного числа. Протестировать на простом примере.
        /// </summary>
        static void Task3()
        {
            Console.WriteLine("\nДомашнее задание 12.1\n");

            Complex complex1 = new Complex(2, 1);
            Complex complex2 = new Complex(2, -1);

            Console.WriteLine("c1 = " + complex1.ToString());
            Console.WriteLine("c2 = " + complex2.ToString());

            Console.WriteLine($"c1 == c2: {complex1 == complex2}");
            Console.WriteLine($"c1 != c2: {complex1 != complex2}");

            Console.WriteLine($"c1 + c2: {complex1 + complex2}");
            Console.WriteLine($"c1 - c2: {complex1 - complex2}");
            Console.WriteLine($"c1 * c2: {complex1 * complex2}");
            Console.WriteLine($"c1 / c2: {complex1 / complex2}");

        }

        /// <summary>
        /// Домашнее задание 12.2. Написать делегат, с помощью которого реализуется сортировка книг.
        /// Книга представляет собой класс с полями Название, Автор, Издательство и конструктором.
        /// Создать класс, являющийся контейнером для множества книг(массив книг).
        /// В этом классе предусмотреть метод сортировки книг.Критерий сортировки определяется экземпляром делегата, 
        /// который передается методу в качестве параметра.
        /// Каждый экземпляр делегата должен сравнивать книги по какому-то одному полю: названию, автору, издательству.
        /// </summary>
        static void Task4()
        {
            Console.WriteLine("\nДомашнее задание 12.2\n");

            Library.Books.Add(new Book("1984", "Джордж Оруэлл", "Эксмо"));
            Library.Books.Add(new Book("Пятнадцатилетний капитан", "Жюль Верн", "АСТ"));
            Library.Books.Add(new Book("Понедельник начинается в субботу", "А. и Б. Стругацкие", "АСТ"));
            Library.Books.Add(new Book("Краткие ответы на большие вопросы", "Стивен Хокинг", "Бомбора"));


            BookSort sort1 = new BookSort(Library.SortingByName);
            BookSort sort2 = new BookSort(Library.SortingByAuthor);
            BookSort sort3 = new BookSort(Library.SortingByPublishing);

            Console.WriteLine("Сортировка по имени:\n");
            sort1();
            Library.LogBooks();

            Console.WriteLine("\nСортировка по автору:\n");
            sort2();
            Library.LogBooks();

            Console.WriteLine("\nСортировка по издательству:\n");
            sort3();
            Library.LogBooks();
        }
        delegate void BookSort();
    }
}
