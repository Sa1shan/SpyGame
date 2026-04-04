using _Source.LocationProvider;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Source.UI
{
    public class LocationTextDisplay : MonoBehaviour
    {
        [Header("Настройки поиска")]
        // Сюда перетаскиваешь заспавненную плашку (или ту, в которой надо искать)
        [SerializeField] private GameObject playerPlaqueObject; 
        [SerializeField] private string targetTag = "LocationText"; // Тэг, который ты повесишь на LocationText
        
        private ILocationProvider _provider;

        [Inject]
        public void Construct(ILocationProvider provider)
        {
            _provider = provider;
        }

        public void ShowLocationText()
        {
            if (playerPlaqueObject == null)
            {
                Debug.LogError("Player Plaque Object не назначен в инспекторе!");
                return;
            }

            if (!string.IsNullOrEmpty(_provider.CurrentLocation))
            {
                // Ищем TMP_Text на объекте с нужным тегом
                TextMeshProUGUI locationText = FindComponentInChildWithTag<TextMeshProUGUI>(playerPlaqueObject, targetTag);

                if (locationText != null)
                {
                    locationText.text = _provider.CurrentLocation;
                    Debug.Log($"Текст локации успешно установлен: {locationText.text}");
                }
                else
                {
                    Debug.LogWarning($"Не удалось найти компонент TextMeshProUGUI на дочернем объекте с тегом '{targetTag}'");
                }
            }
            else
            {
                Debug.Log($"No location found for {_provider.CurrentLocation}");
            }
        }

        /// <summary>
        /// Метод ищет среди всех дочерних объектов тот, у которого совпадает тег, и возвращает нужный компонент.
        /// </summary>
        private T FindComponentInChildWithTag<T>(GameObject parent, string tag) where T : Component
        {
            // Получаем вообще все компоненты нужного типа в детях
            T[] components = parent.GetComponentsInChildren<T>(true); // true — искать даже в выключенных

            foreach (T component in components)
            {
                if (component.CompareTag(tag))
                {
                    return component;
                }
            }
            return null;
        }
    }
}
