using UnityEngine;
using Zenject;

namespace _Source.LocationProvider
{
    public class LocationUIHandler : MonoBehaviour
    {
        private ILocationProvider _locationProvider;

        [Inject]
        public void Construct(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
        }

        public void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                string name = _locationProvider.GetRandomLocation().Name;
                Debug.Log("Случайная локация: " + name);
            }
        }
    }
}