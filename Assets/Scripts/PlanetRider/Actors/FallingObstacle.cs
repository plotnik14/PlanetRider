using PlanetRider.Audio;
using PlanetRider.Components.ColliderTriggers;
using PlanetRider.Components.Spawn;
using UnityEngine;
using Zenject;

namespace PlanetRider.Actors
{
    public class FallingObstacle : MonoBehaviour
    {
        [SerializeField] private AudioClip _collisionSound;
        
        private CollisionCheckComponent _collisionCheck;
        private SimpleSpawnComponent _destroyParticlesSpawner;

        private ISfxService _sfxService;

        [Inject]
        private void Construct(ISfxService sfxService)
        {
            _sfxService = sfxService;
        }
        
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
            if (_collisionSound != null)
                _sfxService.PlayOneShot(_collisionSound);
            
            _destroyParticlesSpawner.Spawn();
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _collisionCheck.OnTrigger -= OnCollision;
        }
    }
}