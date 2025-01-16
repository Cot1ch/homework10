using System.Collections;


namespace Tumakov11
{
    internal class BuildingFactory
    {
        private static Hashtable _HTBuildings = new Hashtable();
        public static Hashtable HTBuildings 
        { 
            get { return _HTBuildings; } 
        }

        protected Building MakeBuilding(double height, uint cFloors, uint cFlats, uint cEntry)
        {
            Building building = new Building(height, cFloors, cFlats, cEntry);
            _HTBuildings[building.PersNumber] = building;

            return building;
        }

        public Building CreateBuilding(double height, uint cFloors, uint cFlats, uint cEntry)
        {

            return MakeBuilding(height, cFloors, cFlats, cEntry);
        }

        public static bool DeleteBuilding(ulong num)
        {
            if (_HTBuildings.ContainsKey(num))
            {
                _HTBuildings.Remove(num);
                return true;
            }

            return false;
        }
    }
}
