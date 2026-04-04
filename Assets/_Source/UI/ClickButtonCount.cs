using UnityEngine;
using UnityEngine.UI;

namespace _Source.UI
{
    public class ClickButtonCount : MonoBehaviour
    {
        [SerializeField] private GameObject message;
        [SerializeField] private Button continueButton;

        private bool _wasClicked;

        private void Awake()
        {
            if (continueButton != null)
            {
                continueButton.onClick.AddListener(OnContinueClicked);
            }

            if (message != null)
            {
                message.SetActive(false);
            }
        }

        // Кнопка, на которой висит этот скрипт
        public void OnMainButtonClicked()
        {
            _wasClicked = true;
        }

        // Кнопка Continue
        private void OnContinueClicked()
        {
            if (message == null)
            {
                return;
            }
            message.SetActive(!_wasClicked);
        }
    }
}
