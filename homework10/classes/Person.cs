namespace homework10
{
    internal class Person
    {
        string _Name;
        string _Hobby;

        public Person(string name, string hobby)
        {
            _Name = name;
            _Hobby = hobby;
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Hobby
        {
            get { return _Hobby; }
            set { _Hobby = value; }
        }
    }
}
