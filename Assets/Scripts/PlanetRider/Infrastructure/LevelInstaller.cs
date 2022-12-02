using PlanetRider.Infrastructure.Factories;
using Zenject;

namespace PlanetRider.Infrastructure
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFactories();
            
            // ToDo remove
            Container.Bind<IAudioService>().To<AudioService>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<IObjectFactory>().To<ObjectFactory>().AsSingle();
        }
    }
}