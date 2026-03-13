using UnityEngine;
using Zenject;

namespace _Source.LocationProvider
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private LocationSettings settings;

        public override void InstallBindings()
        {
            // Биндим сами настройки, чтобы UI мог их видеть
            Container.BindInstance(settings).AsSingle();

            // Биндим провайдер
            Container.BindInterfacesAndSelfTo<JsonLocationProvider>().AsSingle();
        }
    }
}