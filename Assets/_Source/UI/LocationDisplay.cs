using _Source.LocationProvider;
using UnityEngine;
using Zenject;

namespace _Source.UI
{
    public class LocationDisplay : MonoBehaviour
    {
        [Inject] private PlayerRegistry _playerRegistry;
        private int Count => PlayersCountTracker.Instance.Count;
        private ILocationProvider _provider;
        public static LocationDisplay Instance { get; private set; }

        [Inject]
        public void Construct(ILocationProvider provider)
        {
            _provider = provider;
        }
        
        private void Awake()
        {
            // Простейшая проверка на Singleton
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject); // Если вдруг в сцене два таких объекта, удаляем лишний
            }
        }
        
        public void AssignRoles()
        {
            // Для удобства сохраняем список в локальную переменную
            var allPlayers = _playerRegistry.Players;

            if (allPlayers.Count == 0)
            {
                return;
            }

            // 1. Выбираем случайный ИНДЕКС шпиона
            int spyIndex = UnityEngine.Random.Range(0, allPlayers.Count);
    
            // 2. Запоминаем сам ОБЪЕКТ шпиона до начала цикла
            GameObject spyPlayer = allPlayers[spyIndex];

            // 3. Перебираем всех игроков через foreach
            foreach (GameObject player in allPlayers)
            {
                if (player.TryGetComponent(out PlayerEnrtry enrtry))
                {
                    // Сравниваем текущего игрока в цикле с объектом шпиона
                    if (player == spyPlayer)
                    {
                        // Если это тот самый объект — он шпион
                        enrtry.SetLocationText("You are Spy");
                    }
                    else
                    {
                        // Для всех остальных — обычная локация
                        enrtry.SetLocationText(_provider.CurrentLocation);
                    }
                }
            }
        }
    }
}
