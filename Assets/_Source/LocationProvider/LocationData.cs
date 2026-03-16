using System;
using System.Collections.Generic;

namespace _Source.LocationProvider
{
    [Serializable]
    public class LocationData
    {
        public string Name;
    }

    [Serializable]
    public class LocationDatabase
    {
        public List<LocationData> locations;
    }
}