using PlanetRider.Components;
using PlanetRider.Components.ColliderTriggers;
using UnityEngine;

namespace PlanetRider
{
    public class FallingObstacle : MonoBehaviour
    {
        private CollisionCheckComponent _collisionCheck;
        private SimpleSpawnComponent _destroyParticlesSpawner;

        private void Awake()
        {
            _collisionCheck = GetComponent<CollisionCheckComponent>();
            _destroyParticlesSpawner = GetComponent<SimpleSpawnComponent>();
        }

        private void Start()
        {
            _collisionCheck.OnTrigger += OnCollision;
        }

        private void OnCollision(GameObject obj)
        {
            _destroyParticlesSpawner.Spawn();
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _collisionCheck.OnTrigger -= OnCollision;
        }
    }
}