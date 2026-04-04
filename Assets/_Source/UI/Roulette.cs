using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Обязательно добавляем для работы с Image
using Zenject;
using TMPro;
using DG.Tweening;

namespace _Source.UI
{
    public class Roulette : MonoBehaviour
    {
        [Inject] private PlayerRegistry _playerRegistry;
        [Inject] private DiContainer _container;
        
        [Header("Префабы")]
        [SerializeField] private List<GameObject> layoutPrefabs = new List<GameObject>();
        [SerializeField] private GameObject playerPlaquePrefab;
        
        [Header("Настройки цветов рулетки")]
        [SerializeField] private Color defaultColor = Color.white;
        [SerializeField] private Color highlightColor = Color.green;

        private bool _isLayoutSpawned = false;
        private bool _isSelecting = false;
        
        // Список для хранения заспавненных плашек
        private List<GameObject> _spawnedSelectionCards = new List<GameObject>();
        private int _lastHighlightedIndex = 0;

        public void Update()
        {
            if (_playerRegistry.IsPlayerCardEnd) 
            {
                if (!_isLayoutSpawned)
                {
                    Debug.Log("Вторая есть");
                    SpawnPlayers();
                    _isLayoutSpawned = true;
                }
            }
        }

        private void SpawnPlayers()
        {
            // Очищаем список на случай повторного спавна
            _spawnedSelectionCards.Clear();

            int index = Mathf.Clamp(_playerRegistry.Players.Count - 3, 0, layoutPrefabs.Count - 1);
            GameObject layoutInstance = _container.InstantiatePrefab(layoutPrefabs[index], this.transform);

            int playerIndex = 0;
            foreach (Transform spawnPoint in layoutInstance.transform)
            {
                if (playerIndex >= _playerRegistry.Players.Count) break;

                GameObject plaqueInstance = _container.InstantiatePrefab(playerPlaquePrefab, spawnPoint);
                _spawnedSelectionCards.Add(plaqueInstance);

                TMP_Text nameText = plaqueInstance.GetComponentInChildren<TMP_Text>();
                if (nameText != null)
                {
                    nameText.text = $"Player {playerIndex + 1}";
                }
                
                // Устанавливаем дефолтный цвет сразу при спавне
                SetCardColor(playerIndex, defaultColor);
                
                playerIndex++;
            }
        }

        public void StartRoulette()
        {
            if (_isSelecting || _spawnedSelectionCards.Count == 0) return;
            
            _isSelecting = true;
            
            int totalSteps = Random.Range(20, 35);
            float duration = 3.0f;
            
            // Сбрасываем все в дефолт и подсвечиваем первую
            SetAllCardsToDefaultColor();
            _lastHighlightedIndex = 0;
            SetCardColor(_lastHighlightedIndex, highlightColor);

            DOVirtual.Float(0, totalSteps, duration, (float value) =>
            {
                int currentStep = Mathf.FloorToInt(value);
                int currentIndex = currentStep % _spawnedSelectionCards.Count;

                if (currentIndex != _lastHighlightedIndex)
                {
                    // Возвращаем старой карточке обычный цвет
                    SetCardColor(_lastHighlightedIndex, defaultColor);
                    // Красим новую в зеленый
                    SetCardColor(currentIndex, highlightColor);
                    
                    _lastHighlightedIndex = currentIndex;
                }
            })
            .SetEase(Ease.OutCubic)
            .OnComplete(() =>
            {
                Debug.Log($"Выбран игрок: {_lastHighlightedIndex + 1}");
                _isSelecting = false;
            });
        }

        // Вспомогательный метод для смены цвета одной карточки
        private void SetCardColor(int index, Color color)
        {
            if (index < 0 || index >= _spawnedSelectionCards.Count) return;

            // Ищем Image.GetComponentInChildren найдет его и на самом объекте, и внутри.
            // Предполагается, что основной фон плашки — это первый Image, который найдется.
            Image cardImage = _spawnedSelectionCards[index].GetComponentInChildren<Image>();
            
            if (cardImage != null)
            {
                cardImage.color = color;
            }
        }

        // Метод для полного сброса цветов (полезно перед стартом рулетки)
        private void SetAllCardsToDefaultColor()
        {
            for (int i = 0; i < _spawnedSelectionCards.Count; i++)
            {
                SetCardColor(i, defaultColor);
            }
        }
    }
}