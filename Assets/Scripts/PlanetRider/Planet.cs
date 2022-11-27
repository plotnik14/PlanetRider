using PlanetRider.Components;
using PlanetRider.Utils;
using UnityEngine;

namespace PlanetRider
{
    public class Planet : MonoBehaviour
    {
        [SerializeField] private ObjectSpawnerComponent _coinSpawner;
        [SerializeField] private Cooldown _spawnCooldown;

        private void Update()
        {
            if (_spawnCooldown.IsReady)
            {
                _coinSpawner.Spawn();
                _spawnCooldown.Reset();
            }
        }
    }
}