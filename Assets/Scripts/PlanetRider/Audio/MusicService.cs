using System;
using UnityEngine;

namespace PlanetRider
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