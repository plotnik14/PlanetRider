using PlanetRider.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace PlanetRider
{
    public class AppStarter : MonoBehaviour
    {
        [SerializeField] private string _levelToLoad;
        [SerializeField] private AudioClip _musicClip;

        private IMusicService _musicService;

        [Inject]
        private void Construct(IMusicService musicService)
        {
            _musicService = musicService;
        }
        
        private void Start()
        {
            _musicService.Play(_musicClip);
            
            SceneManager.LoadScene(_levelToLoad);
        }
    }
}