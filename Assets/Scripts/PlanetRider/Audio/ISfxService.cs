using UnityEngine;

namespace PlanetRider.Audio
{
    public interface ISfxService
    {
        void PlayOneShot(AudioClip clip);
    }
}