using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.GameOptionsMenu
{
    public class LocationChoosing : MonoBehaviour
    {
        [Header("Списки локаций")]
        [SerializeField] private List<string> baze; 
        [SerializeField] private List<string> cityes;

        [Header("Ссылки на Image кнопок")]
        [SerializeField] private Image bazeButtonImage;
        [SerializeField] private Image cityButtonImage;
        [SerializeField] private Button continueButton; // Ссылка на саму кнопку продолжить (опционально)

        [Header("Цвета")]
        [SerializeField] private Color activeColor = Color.green;
        [SerializeField] private Color normalColor = Color.white;
        [SerializeField] private Color lockedColor = Color.gray; // Цвет для заблокированного состояния

        private string _currentLocation = "";
        private bool _isBazeActive = false;
        private bool _isCityActive = false;
        
        // Переменная-замок
        private bool _isLocked = false;

        public void ChoseBaze()
        {
            // Если выбор уже закреплен, ничего не делаем
            if (_isLocked) return;

            if (_isBazeActive)
            {
                ResetAll();
            }
            else
            {
                ResetAll();
                if (baze != null && baze.Count > 0)
                {
                    _isBazeActive = true;
                    _currentLocation = baze[Random.Range(0, baze.Count)];
                    bazeButtonImage.color = activeColor;
                    Debug.Log("Выбрана База: " + _currentLocation);
                }
            }
        }

        public void ChoseCity()
        {
            // Если выбор уже закреплен, ничего не делаем
            if (_isLocked) return;

            if (_isCityActive)
            {
                ResetAll();
            }
            else
            {
                ResetAll();
                if (cityes != null && cityes.Count > 0)
                {
                    _isCityActive = true;
                    _currentLocation = cityes[Random.Range(0, cityes.Count)];
                    cityButtonImage.color = activeColor;
                    Debug.Log("Выбран Город: " + _currentLocation);
                }
            }
        }

        // Метод для третьей кнопки "Продолжить"
        public void ConfirmSelection()
        {
            // Проверяем, выбрано ли хоть что-то перед закреплением
            if (string.IsNullOrEmpty(_currentLocation))
            {
                Debug.LogWarning("Ничего не выбрано! Сначала выберите локацию.");
                return;
            }

            // Закрепляем выбор
            _isLocked = true;

            Debug.Log("ВЫБОР ЗАКРЕПЛЕН: " + _currentLocation + ". Теперь сменить локацию нельзя.");
        }

        private void ResetAll()
        {
            // Если заблокировано, сброс тоже не должен работать
            if (_isLocked) return;

            _isBazeActive = false;
            _isCityActive = false;
            _currentLocation = "";

            if (bazeButtonImage != null) bazeButtonImage.color = normalColor;
            if (cityButtonImage != null) cityButtonImage.color = normalColor;
        }
    }
}