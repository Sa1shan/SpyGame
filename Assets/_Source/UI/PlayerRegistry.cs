using System.Collections.Generic;
using UnityEngine;
using System;

namespace _Source.UI
{
    public class PlayerRegistry
    {
        public List<GameObject> Players = new List<GameObject>();
        // Сама переменная
        public bool IsPlayerCardEnd { get; private set; }
        // Событие: на него можно подписаться, чтобы что-то включить в конце
        public event Action OnAllCardsShown;
        public void AddPlayer(GameObject player)
        {
            Players.Add(player);
        }
        // Метод для фиксации финиша
        public void FinishCardShow()
        {
            IsPlayerCardEnd = true;
            OnAllCardsShown?.Invoke(); // Сообщаем всем: "Мы закончили!"
        }

        public void Clear()
        {
            Players.Clear();
            IsPlayerCardEnd = false; // Сбрасываем при новом раунде
        }

        public GameObject GetPlayer(int index) => Players[index];
    }
}