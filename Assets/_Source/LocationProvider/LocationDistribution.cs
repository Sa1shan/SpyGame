using UnityEngine;
using Zenject; // Добавили

namespace _Source.LocationProvider
{
    public class LocationDistribution 
    {
        private readonly ILocationProvider _locationProvider;
        
        public LocationDistribution(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
        }

        public void StartDistribution()
        {
            var targetLocation = _locationProvider.GetRandomLocation();
            if (targetLocation != null)
            {
                Debug.Log($"Локация распределена: {targetLocation.Name}");
            }
        }
    }
}