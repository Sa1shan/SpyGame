using TMPro;
using UnityEngine;

namespace _Source.UI
{
    public class PlayerEnrtry : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerText;
        [SerializeField] private TextMeshProUGUI locationText;

        public void SetPlayerName(string text)
        {
            playerText.text = text;
        }

        public void SetLocationText(string text)
        {
            locationText.text = text;
        }
    }
}
