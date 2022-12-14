using UnityEngine;

namespace PlanetRider.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicService : MonoBehaviour, IMusicService
    {
        private AudioSource _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        public void Play(AudioClip audioClip)
        {
            _source.clip = audioClip;
            _source.Play();
        }
    }
}