using PlanetRider.Audio;
using PlanetRider.Inventory;
using PlanetRider.LevelManagement;
using UnityEngine;
using Zenject;

namespace PlanetRider.Infrastructure
{
    public class BootInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _musicServicePrefab;
        [SerializeField] private GameObject _sfxServicePrefab;

        // TODO move to settings?
        [SerializeField] private string _hudSceneName;
        
        public override void InstallBindings()
        {
            BindAudioServices();
            BindInventoryService();
            BindLevelLoader();
        }

        private void BindLevelLoader()
        {
            Container.Bind<ILevelLoader>()
                .To<LevelLoader>()
                .AsSingle()
                .WithArguments(_hudSceneName)
                .NonLazy();
        }

        private void BindInventoryService()
        {
            Container.Bind<IInventoryService>()
                .To<InventoryService>()
                .AsSingle();
        }

        private void BindAudioServices()
        {
            Container.Bind<IMusicService>()
                .FromComponentInNewPrefab(_musicServicePrefab)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<ISfxService>()
                .FromComponentInNewPrefab(_sfxServicePrefab)
                .AsSingle()
                .NonLazy();
        }
    }
}