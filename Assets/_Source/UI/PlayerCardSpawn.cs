using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Source.UI
{
    public class PlayerCardSpawn : MonoBehaviour
    {
        [Inject] private PlayerRegistry _playerRegistry; // Внедряем наш реестр
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform transform;
        
        private int Count => PlayersCountTracker.Instance.Count;
        private List<GameObject> _spawnedPlayers = new List<GameObject>();
        
        public void SpawnCard()
        {
            _playerRegistry.Clear(); // Очищаем реестр перед новым созданием

            for (int i = 0; i < Count; i++)
            {
                GameObject newPlayer = Instantiate(prefab, transform);
                newPlayer.SetActive(i == 0);

                if (newPlayer.TryGetComponent(out PlayerEnrtry entry))
                {
                    entry.SetPlayerName($"Player {i + 1}");
                }

                // Записываем игрока в наш новый C# класс
                _playerRegistry.AddPlayer(newPlayer);
            }
            Debug.Log($"Создано и сохранено в список объектов: {_spawnedPlayers.Count}");
            LocationDisplay.Instance.AssignRoles();
        }
    }
}
