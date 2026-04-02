using TMPro;
using UnityEngine;

namespace _Source.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class PlayersCountTracker : MonoBehaviour
    {
        // Создаем статическую ссылку на этот объект
        public static PlayersCountTracker Instance { get; private set; }

        private TextMeshProUGUI _playerCountText;
        public int Count { get; private set; } = 3;

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

            _playerCountText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            UpdateScoreUI();
        }

        public void AddScoreButton()
        { 
            if (Count < 10)
            {
                Count++;
                UpdateScoreUI();
            }
        }

        public void MinuseScoreButton()
        {
            if (Count > 3)
            {
                Count--;
                UpdateScoreUI(); // Перенес внутрь условия для красоты, но можно и снаружи
            }
        }

        private void UpdateScoreUI()
        {
            if (_playerCountText != null)
                _playerCountText.text = Count.ToString();
        }
        
        // Дополнительный метод, чтобы другие скрипты могли узнать текущий счет
        public int GetCurrentCount()
        {
            return Count;
        }
    }
}