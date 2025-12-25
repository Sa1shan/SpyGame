using TMPro;
using UnityEngine;

namespace _Source.GameOptionsMenu
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class PlayersCountTracker : MonoBehaviour
    {
        // Создаем статическую ссылку на этот объект
        public static PlayersCountTracker Instance { get; private set; }

        private TextMeshProUGUI _playerCountText; 
        private int _count = 0;

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
            if (_count < 10)
            {
                _count++;
                UpdateScoreUI();
            }
        }

        public void MinuseScoreButton()
        {
            if (_count > 0)
            {
                _count--;
                UpdateScoreUI(); // Перенес внутрь условия для красоты, но можно и снаружи
            }
        }

        private void UpdateScoreUI()
        {
            if (_playerCountText != null)
                _playerCountText.text = _count.ToString();
        }
        
        // Дополнительный метод, чтобы другие скрипты могли узнать текущий счет
        public int GetCurrentCount()
        {
            return _count;
        }
    }
}