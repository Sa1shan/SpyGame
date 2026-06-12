using TMPro;
using UnityEngine;
using Zenject;

namespace _Source.UI
{
    public class PlayerEnrtry : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerText;
        [SerializeField] private TextMeshProUGUI locationText;
        
        [Inject] private PlayerRegistry _playerRegistry;
        private int _clickCount = 0;

        public void SetPlayerName(string text)
        {
            playerText.text = text;
        }

        public void SetLocationText(string text)
        {
            locationText.text = text;
        }

        public void Click()
        {
            _clickCount++;
            if (_clickCount == 1) 
            {
                GetComponent<PlayerBonusCardLoader>()?.LoadBonusCards();
            }
        }
        
        public void PlayerCardActivate()
        {
            if (_clickCount >= 2)
            {
                int myIndex = _playerRegistry.Players.IndexOf(gameObject);

                if (myIndex == -1)
                {
                    return;
                }

                // 1. ПРОВЕРЯЕМ: Является ли текущий объект ПОСЛЕДНИМ в списке?
                if (myIndex == _playerRegistry.Players.Count - 1)
                {
                    foreach (GameObject player in _playerRegistry.Players)
                    {
                        player.SetActive(false);
                    }

                    // ВМЕСТО локальной переменной меняем состояние в реестре
                    _playerRegistry.FinishCardShow(); 

                    _clickCount = 0;
                    return;
                }

                int nextIndex = myIndex + 1;
                Debug.Log($"Активация. Я: {myIndex}, Следующий: {nextIndex}");
                _playerRegistry.Players[nextIndex].SetActive(true);
                // Выключаем себя
                gameObject.SetActive(false);
                _clickCount = 0; // Сбрасываем счетчик
            }
        }
    }
}
