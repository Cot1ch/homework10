using System;
using System.Collections.Generic;


namespace Tumakov12
{
    internal class Book
    {
        private string _Name;
        private string _Author;
        private string _Publishing;

        public static List<Book> _Books;

        public string Name
        { 
            get { return _Name; } 
            set { _Name = value; }
        }
        public string Author
        {
            get { return _Author; }
            set { _Author = value; }
        }
        public string Publishing
        {
            get { return _Publishing; }
            set { _Publishing = value; }
        }
        public static List<Book> Books
        {
            get { return _Books; }
            set { _Books = value; }
        }
        static Book()
        {
            Books = new List<Book>();
        }
        public Book(string name, string author, string publishing)
        {
            _Name = name;
            _Author = author;
            _Publishing = publishing;
        }
        public override string ToString()
        {
            return $"'{Name}', {Author}, {Publishing}";
        }

        public static void LogBooks()
        {
            foreach (Book book in Books)
            {
                Console.WriteLine(book.ToString());
            }
        }


        public static void SortingByName()
        {
            Books.Sort((book1, book2) => book1.Name.CompareTo(book2.Name));
        }
        public static void SortingByAuthor()
        {
            Books.Sort((book1, book2) => book1.Author.CompareTo(book2.Author));
        }
        public static void SortingByPublishing()
        {
            Books.Sort((book1, book2) => book1.Publishing.CompareTo(book2.Publishing));
        }
    }
}



