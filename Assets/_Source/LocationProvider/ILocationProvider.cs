using UnityEngine;

namespace _Source.LocationProvider
{
    public interface ILocationProvider
    {
        string CurrentLocation { get; set; }
        LocationData GetRandomLocation();
        void LoadPool(TextAsset jsonConfig); 
    }
}