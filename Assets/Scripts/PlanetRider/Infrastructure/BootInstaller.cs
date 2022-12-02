using PlanetRider.Inventory;
using UnityEngine;
using Zenject;

namespace PlanetRider.Infrastructure
{
    public class BootInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _musicServicePrefab;
        
        public override void InstallBindings()
        {
            BindMusicService();
            BindInventoryService();
        }

        private void BindInventoryService()
        {
            Container.Bind<IInventoryService>().To<InventoryService>().AsSingle().NonLazy();
        }

        private void BindMusicService()
        {
            Container.Bind<IMusicService>().FromComponentInNewPrefab(_musicServicePrefab).AsSingle().NonLazy();
        }
    }
}