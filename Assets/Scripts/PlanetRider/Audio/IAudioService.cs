using UnityEngine;

namespace PlanetRider
{
    public interface IAudioService
    {
        public void Play(AudioClip clip);
        public void PlayOneShot(AudioClip clip);
    }
}