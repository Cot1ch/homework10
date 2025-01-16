namespace Tumakov11
{
    internal class Building
    {
        #region Fields
        private static ulong _Number = 1;
        private ulong _PersNum;
        private double _Height;
        private uint _CountFloors;
        private uint _CountFlats;
        private uint _СountEntrance;
        #endregion

        #region Properties
        public ulong PersNumber
        {
            get { return _PersNum; }
            set { _PersNum = value; }
        }
        public double height
        {
            get { return _Height; }
            set { _Height = value; }
        }
        public uint countFloors
        {
            get { return _CountFloors; }
            set { _CountFloors = value; }
        }
        public uint countFlat
        {
            get { return _CountFlats; }
            set { _CountFlats = value; }
        }
        public uint countEntrance
        {
            get { return _СountEntrance; }
            set { _СountEntrance = value; }
        }
        #endregion

        #region Constructor
        internal Building(double height, uint countFloors, uint countFlats, uint countEntrance)
        {
            PersNumber = _Number++;
            _Height = height;
            _CountFloors = countFloors;
            _CountFlats = countFlats;
            _СountEntrance = countEntrance;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Возвращает высоту этажа
        /// </summary>
        /// <returns>Число типа double</returns>
        public double FloorsHeight()
        {
            return height / countFloors;
        }

        /// <summary>
        /// Возвращает количество квартир в подъезде
        /// </summary>
        /// <returns>Число типа double</returns>
        public double FlatsInEntrance()
        {
            return countFlat / countEntrance;
        }

        /// <summary>
        /// Возвращает количество квартир на этаже
        /// </summary>
        /// <returns>Число типа double</returns>
        public double FlatsOnFloor()
        {
            return countFlat / countFloors / countEntrance;
        }
        public override string ToString()
        {
            return $"Номер: {PersNumber}\nВысота: {height}\nЭтажи: {countFloors}\nКвартиры: {countFlat}\nПодъезды: {countEntrance}\n-------";
        }
        #endregion
    }
}