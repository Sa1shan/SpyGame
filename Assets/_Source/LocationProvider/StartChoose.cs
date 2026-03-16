using System.Linq;
using UnityEngine;
using Zenject;

namespace _Source.LocationProvider
{
    public class StartChoose : MonoBehaviour
    {
        [Inject] private LocationSettings _settings;
        [Inject] private ILocationProvider _provider;
        
        public void SelectPoolByName(string poolName)
        {
            var selectedPool = _settings.Pools.FirstOrDefault(p => p.PoolName == poolName);

            if (selectedPool != null)
            {
                _provider.LoadPool(selectedPool.JsonFile);
                Debug.Log($"Выбран режим: {selectedPool.PoolName}");
            }
            else
            {
                Debug.LogError($"Пул с именем {poolName} не найден в настройках!");
            }
        }
    }
}