using System;
using System.Collections.Generic;


namespace Tumakov12
{
    internal class Book
    {
        private string _Name;
        private string _Author;
        private string _Publishing;


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
        static Book()
        {
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
    }
}



