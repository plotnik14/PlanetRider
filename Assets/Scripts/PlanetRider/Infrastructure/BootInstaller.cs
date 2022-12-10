using PlanetRider.Audio;
using PlanetRider.Inventory;
using PlanetRider.LevelManagement;
using PlanetRider.Settings;
using UnityEngine;
using Zenject;

namespace PlanetRider.Infrastructure
{
    public class BootInstaller : MonoInstaller
    {
        [SerializeField] private AppSettings _appSettings;
        [SerializeField] private GameObject _musicServicePrefab;
        [SerializeField] private GameObject _sfxServicePrefab;

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
                .WithArguments(_appSettings.HudSceneName)
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