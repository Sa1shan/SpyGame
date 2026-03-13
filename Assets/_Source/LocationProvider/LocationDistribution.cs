using UnityEngine;
using Zenject; // Добавили

namespace _Source.LocationProvider
{
    // Реализуем IInitializable для автозапуска
    public class LocationDistribution : IInitializable 
    {
        private readonly ILocationProvider _locationProvider;
        
        public LocationDistribution(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
        }

        public void Initialize() // Метод из IInitializable
        {
            StartDistribution();
        }

        public void StartDistribution()
        {
            var targetLocation = _locationProvider.GetRandomLocation();
            Debug.Log($"Starting distribution for {targetLocation.Name}");
        }
    }
}