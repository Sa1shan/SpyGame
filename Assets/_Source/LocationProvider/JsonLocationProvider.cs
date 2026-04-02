using UnityEngine;
using Zenject;

namespace _Source.LocationProvider
{
    public class JsonLocationProvider : ILocationProvider
    {
        private LocationDatabase _database;
        
        public JsonLocationProvider() { }

        public string CurrentLocation { get; set; }

        public void LoadPool(TextAsset jsonConfig)
        {
            if (jsonConfig == null) return;
        
            _database = JsonUtility.FromJson<LocationDatabase>(jsonConfig.text);
            Debug.Log($"Загружен новый пул локаций. Всего: {_database.locations.Count}");
        }

        public LocationData GetRandomLocation()
        {
            if (_database == null || _database.locations.Count == 0) return null;
            return _database.locations[Random.Range(0, _database.locations.Count)];
        }
    }
}