using PlanetRider.Audio;
using PlanetRider.LevelManagement;
using UnityEngine;
using Zenject;

namespace PlanetRider
{
    public class AppStarter : MonoBehaviour
    {
        [SerializeField] private string _levelToLoad;
        [SerializeField] private AudioClip _musicClip;

        private IMusicService _musicService;
        private ILevelLoader _levelLoader;

        [Inject]
        private void Construct(IMusicService musicService, ILevelLoader levelLoader)
        {
            _musicService = musicService;
            _levelLoader = levelLoader;
        }
        
        private void Start()
        {
            _musicService.Play(_musicClip);
            _levelLoader.LoadLevel(_levelToLoad, loadHud: false);
        }
    }
}