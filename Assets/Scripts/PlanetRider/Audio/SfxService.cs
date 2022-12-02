using UnityEngine;

namespace PlanetRider.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SfxService : MonoBehaviour, ISfxService
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
    }
}