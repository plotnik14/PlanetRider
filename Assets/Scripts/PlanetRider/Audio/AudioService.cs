using UnityEngine;
using Zenject;

namespace PlanetRider
{
    public class AudioService : IAudioService, IInitializable
    {
        private AudioSource _source;
        
        public void Initialize()
        {
            // ToDO
        }
        
        public void Play(AudioClip clip)
        {
            Init();
            _source.clip = clip;
            _source.Play();
        }

        public void PlayOneShot(AudioClip clip)
        {
            Init();
            _source.PlayOneShot(clip);
        }

        private void Init()
        {
            if (_source == null)
                _source = GameObject.FindWithTag("MusicAudioSource").GetComponent<AudioSource>();
        }
    }
}