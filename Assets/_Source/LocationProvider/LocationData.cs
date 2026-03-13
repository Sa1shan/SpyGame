using System;
using System.Collections.Generic;

namespace _Source.LocationProvider
{
    [Serializable]
    public class LocationData // Сама локация
    {
        public string Name; // Например, название локации
    }

    [Serializable]
    public class LocationDatabase // Обертка для JSON
    {
        public List<LocationData> locations;
    }
}