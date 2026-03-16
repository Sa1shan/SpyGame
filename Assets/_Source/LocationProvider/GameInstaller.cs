using UnityEngine;
using Zenject;

namespace _Source.LocationProvider
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private LocationSettings settings;

        public override void InstallBindings()
        {
            Container.BindInstance(settings).AsSingle();
            Container.BindInterfacesAndSelfTo<JsonLocationProvider>().AsSingle();
        }
    }
}