namespace Tumakov12
{
    internal class Book
    {
        #region Fields
        private string _Name;
        private string _Author;
        private string _Publishing;
        #endregion

        #region Properties
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
        #endregion

        #region Constructor
        public Book(string name, string author, string publishing)
        {
            _Name = name;
            _Author = author;
            _Publishing = publishing;
        }
        #endregion

        #region Method
        public override string ToString()
        {
            return $"'{Name}', {Author}, {Publishing}";
        }
        #endregion
    }
}