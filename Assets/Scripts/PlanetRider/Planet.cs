using PlanetRider.Components;
using PlanetRider.Utils;
using UnityEngine;

namespace PlanetRider
{
    public class Planet : MonoBehaviour
    {
        [Header("Coins")]
        [SerializeField] private ConfigurableSpawnComponent _coinSpawner;
        [SerializeField] private Cooldown _coinSpawnCooldown;
        
        [Header("Meteors")]
        [SerializeField] private ConfigurableSpawnComponent _meteorSpawner;
        [SerializeField] private Cooldown _meteorSpawnCooldown;

        private void Update()
        {
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
        }
    }
}