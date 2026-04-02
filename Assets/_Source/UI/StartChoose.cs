using System.Linq;
using _Source.LocationProvider;
using UnityEngine;
using Zenject;

namespace _Source.UI
{
    public class StartChoose : MonoBehaviour
    {
        [Inject] private LocationSettings _settings;
        [Inject] private ILocationProvider _provider;
        [Inject] private LocationDistribution _distributor;
        
        public void SelectPoolByName(string poolName)
        {
            var selectedPool = _settings.Pools.FirstOrDefault(p => p.PoolName == poolName);

            if (selectedPool != null)
            {
                _provider.LoadPool(selectedPool.JsonFile);
        
                // 2. ВЫБИРАЕМ ЛОКАЦИЮ И СОХРАНЯЕМ ЕЁ (Добавьте это)
                var randomLoc = _provider.GetRandomLocation();
                if (randomLoc != null)
                {
                    _provider.CurrentLocation = randomLoc.Name;
                    Debug.Log($"Локация '{_provider.CurrentLocation}' сохранена в провайдер.");
                }
            }
        }
    }
}