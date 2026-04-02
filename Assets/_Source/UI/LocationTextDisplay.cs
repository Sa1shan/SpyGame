using _Source.LocationProvider;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Source.UI
{
    public class LocationTextDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI locationText;
        
        private ILocationProvider _provider;

        [Inject]
        public void Construct(ILocationProvider provider)
        {
            _provider = provider;
        }

        public void ShowLocationText()
        {
            if (!string.IsNullOrEmpty(_provider.CurrentLocation))
            {
                locationText.text = _provider.CurrentLocation;
                Debug.Log(locationText.text);
            }
            else
            {
                Debug.Log($"No location found for {_provider.CurrentLocation}");
            }
        }
    }
}
