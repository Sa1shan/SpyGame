using System.Linq;
using UnityEngine;
using Zenject;

namespace _Source.LocationProvider
{
    public class StartChoose : MonoBehaviour
    {
        [Inject] private LocationSettings _settings;
        [Inject] private ILocationProvider _provider;

        // Теперь принимаем строку (имя), а не число
        public void SelectPoolByName(string poolName)
        {
            // Ищем пул, у которого PoolName совпадает с переданным именем
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