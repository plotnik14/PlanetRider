using PlanetRider.Infrastructure.Factories;
using Zenject;

namespace PlanetRider.Infrastructure
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFactories();
        }

        private void BindFactories()
        {
            Container.Bind<IObjectFactory>()
                .To<ObjectFactory>()
                .AsSingle();
        }
    }
}