using UnityEngine;

namespace PlanetRider.Components.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class PlaySoundComponent : MonoBehaviour
    {
        private AudioSource _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        public void PlayOneShot(AudioClip clip)
        {
            _source.PlayOneShot(clip);
        }
        
        public void Play(AudioClip audioClip)
        {
            _source.clip = audioClip;
            _source.Play();
        }
    }
}