using System;


namespace homework10
{
    internal class VMKshnik
    {
        private string _Name;
        private string _SurName;
        private int _Group;
        private bool _Wanting;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string SurName
        {
            get { return _SurName; }
            set { _SurName = value; }
        }
        public int Group
        { 
            get { return _Group; } 
            set { _Group = value; } 
        }
        public bool Wanting
        {
            get { return _Wanting; }
            set { _Wanting = value; }
        }
        public VMKshnik(string name, string surname,int group, bool wanting)
        {
            _Name = name;
            _SurName = surname;
            _Group = group;
            _Wanting = wanting;
        }

        public override string ToString()
        {
            return $"{_Name} {_SurName}\n";
        }
    }
}
