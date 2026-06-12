using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _Source.UI
{
    public class PlayerBonusCardLoader : MonoBehaviour
    {
        [Header("JSON Файлы карточек")]
        [SerializeField] private TextAsset actionJsonFile;
        [SerializeField] private TextAsset conditionJsonFile;

        [Header("TextMeshPro Компоненты на самой Карточке")]
        [SerializeField] private TextMeshProUGUI actionTextDisplay;
        [SerializeField] private TextMeshProUGUI conditionTextDisplay;

        // Публичные переменные, куда сохранятся выпавшие значения для этого конкретного игрока
        public CardData SavedAction { get; private set; }
        public CardData SavedCondition { get; private set; }

        /// <summary>
        /// Метод выбирает случайные действия и условия и записывает их в переменные и UI.
        /// </summary>
        public void LoadBonusCards()
        {
            // 1. Извлекаем случайное действие
            SavedAction = GetRandomCard(actionJsonFile);
            if (SavedAction != null && actionTextDisplay != null)
            {
                actionTextDisplay.text = SavedAction.Name;
            }

            // 2. Извлекаем случайное условие
            SavedCondition = GetRandomCard(conditionJsonFile);
            if (SavedCondition != null && conditionTextDisplay != null)
            {
                conditionTextDisplay.text = SavedCondition.Name;
            }
            
            Debug.Log($"[Бонус] Карточка {gameObject.name} получила Действие: {SavedAction?.Name}, Условие: {SavedCondition?.Name}");
        }

        // Универсальная мини-функция чтения JSON
        private CardData GetRandomCard(TextAsset jsonAsset)
        {
            if (jsonAsset == null) return null;

            CardListWrapper wrapper = JsonUtility.FromJson<CardListWrapper>(jsonAsset.text);

            if (wrapper != null && wrapper.cards != null && wrapper.cards.Count > 0)
            {
                int randomIndex = Random.Range(0, wrapper.cards.Count);
                return wrapper.cards[randomIndex];
            }

            Debug.LogError($"[PlayerBonusCardLoader] Ошибка парсинга или пустой файл в: {jsonAsset.name}");
            return null;
        }

        // Полезный метод на случай, если карточки используются повторно в новом раунде
        public void ResetBonusCards()
        {
            SavedAction = null;
            SavedCondition = null;
            if (actionTextDisplay != null) actionTextDisplay.text = string.Empty;
            if (conditionTextDisplay != null) conditionTextDisplay.text = string.Empty;
        }
    }
}