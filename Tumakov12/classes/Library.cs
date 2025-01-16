using System;
using System.Collections.Generic;


namespace Tumakov12
{
    internal class Library
    {
        private static List<Book> _Books = new List<Book>();
        public static List<Book> Books
        {
            get { return _Books; }
            set { _Books = value; }
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
