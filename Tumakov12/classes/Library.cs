using System;
using System.Collections.Generic;


namespace Tumakov12
{
    internal class Library
    {
        #region Field
        private static List<Book> _Books = new List<Book>();
        #endregion

        #region Properties
        public static List<Book> Books
        {
            get { return _Books; }
            set { _Books = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Метод выводит информацию о книгах на экран
        /// </summary>
        public static void LogBooks()
        {
            foreach (Book book in Books)
            {
                Console.WriteLine(book.ToString());
            }
        }

        /// <summary>
        /// Метод сортирует книги по названию
        /// </summary>
        public static void SortingByName()
        {
            Books.Sort((book1, book2) => book1.Name.CompareTo(book2.Name));
        }

        /// <summary>
        /// Метод сортирует книги по автору
        /// </summary>
        public static void SortingByAuthor()
        {
            Books.Sort((book1, book2) => book1.Author.CompareTo(book2.Author));
        }

        /// <summary>
        /// Метод сортирует книги по издательству
        /// </summary>
        public static void SortingByPublishing()
        {
            Books.Sort((book1, book2) => book1.Publishing.CompareTo(book2.Publishing));
        }
        #endregion
    }
}
