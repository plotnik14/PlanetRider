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
            // Todo rework
            
            if (_coinSpawnCooldown.IsReady)
            {
                _coinSpawner.Spawn();
                _coinSpawnCooldown.Reset();
            }
            
            if (_meteorSpawnCooldown.IsReady)
            {
                _meteorSpawner.Spawn();
                _meteorSpawnCooldown.Reset();
            }
            
            if (_fuelSpawnCooldown.IsReady)
            {
                _fuelSpawner.Spawn();
                _fuelSpawnCooldown.Reset();
            }
        }
    }
}