using UnityEngine;
using Zenject;

namespace _Source.UI
{
    public class PlayerCardSpawn : MonoBehaviour
    {
        [Inject] private PlayerRegistry _playerRegistry;
        [Inject] private DiContainer _container; // 1. Добавляем контейнер Zenject

        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject afterGame;

        public void SpawnCard()
        {
            _playerRegistry.Clear();
            Debug.Log("кнопка Continue Нажата");
            for (int i = 0; i < PlayersCountTracker.Instance.Count; i++)
            {
                // 2. Используем _container.InstantiatePrefab вместо обычного Instantiate
                GameObject newPlayer = _container.InstantiatePrefab(prefab, this.transform);
                newPlayer.SetActive(i == 0);

                if (newPlayer.TryGetComponent(out PlayerEnrtry entry))
                {
                    entry.SetPlayerName($"Player {i + 1}");
                }

                _playerRegistry.AddPlayer(newPlayer);
            }
        
            Debug.Log($"Создано и сохранено: {_playerRegistry.Players.Count}");
            LocationDisplay.Instance.AssignRoles();
        }

        void Update()
        {
            if (_playerRegistry.IsPlayerCardEnd) 
            {
                afterGame.SetActive(true);
            }
        }
    }
}
