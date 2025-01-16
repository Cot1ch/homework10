using System.Collections;


namespace Tumakov11
{
    internal class BuildingFactory
    {
        #region Field
        private static Hashtable _HTBuildings = new Hashtable();
        #endregion

        #region Properties
        public static Hashtable HTBuildings 
        { 
            get { return _HTBuildings; } 
        }
        #endregion

        #region Methods

        /// <summary>
        /// Фабричный метод
        /// </summary>
        /// <returns>Объект типа Building</returns>
        protected Building MakeBuilding(double height, uint cFloors, uint cFlats, uint cEntry)
        {
            Building building = new Building(height, cFloors, cFlats, cEntry);
            _HTBuildings[building.PersNumber] = building;

            return building;
        }

        /// <summary>
        /// Фабричный метод
        /// </summary>
        /// <returns>Объект типа Building</returns>
        public Building CreateBuilding(double height, uint cFloors, uint cFlats, uint cEntry)
        {

            return MakeBuilding(height, cFloors, cFlats, cEntry);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Булево значение</returns>
        public static bool DeleteBuilding(ulong num)
        {
            if (_HTBuildings.ContainsKey(num))
            {
                _HTBuildings.Remove(num);
                return true;
            }

            return false;
        }
        #endregion
    }
}
