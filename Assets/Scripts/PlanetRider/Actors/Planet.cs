using PlanetRider.Components.Spawn;
using PlanetRider.Utils;
using UnityEngine;

namespace PlanetRider.Actors
{
    public class Planet : MonoBehaviour
    {
        [Header("Coins")]
        [SerializeField] private ConfigurableSpawnComponent _coinSpawner;
        [SerializeField] private Cooldown _coinSpawnCooldown;
        
        [Header("Fuel")]
        [SerializeField] private ConfigurableSpawnComponent _fuelSpawner;
        [SerializeField] private Cooldown _fuelSpawnCooldown;
        
        [Header("Meteors")]
        [SerializeField] private ConfigurableSpawnComponent _meteorSpawner;
        [SerializeField] private Cooldown _meteorSpawnCooldown;

        private void Update()
        {
            SpawnIfReady(_coinSpawner, _coinSpawnCooldown);
            SpawnIfReady(_meteorSpawner, _meteorSpawnCooldown);
            SpawnIfReady(_fuelSpawner, _fuelSpawnCooldown);
        }

        private void SpawnIfReady(ConfigurableSpawnComponent spawner, Cooldown cooldown)
        {
            if (cooldown.IsReady)
            {
                spawner.Spawn();
                cooldown.Reset();
            }
        }
    }
}