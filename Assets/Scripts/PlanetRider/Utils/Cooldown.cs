using System;
using UnityEngine;

namespace PlanetRider.Utils
{
    [Serializable]
    public class Cooldown
    {
        [SerializeField] private float _time;

        private float _targetTime;

        public bool IsReady => Time.time >= _targetTime;

        public void Reset()
        {
            _targetTime = Time.time + _time;
        }
    }
}