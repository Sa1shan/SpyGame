using System.Collections.Generic;
using UnityEngine;

namespace _Source.UI
{
    public class PlayerRegistry
    {
        // Список всех созданных игроков
        private readonly List<GameObject> _players = new List<GameObject>();

        // Свойство только для чтения, чтобы другие классы могли брать список
        public IReadOnlyList<GameObject> Players => _players;

        public void AddPlayer(GameObject player)
        {
            _players.Add(player);
        }

        public void Clear()
        {
            _players.Clear();
        }
        
        // Тут же можно добавить удобные методы поиска
        public GameObject GetPlayer(int index) => _players[index];
    }
}