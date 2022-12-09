using PlanetRider.Components.Rotators;
using PlanetRider.Generators.PositionGeneration;
using PlanetRider.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace PlanetRider.Components.Spawn
{
    public class ConfigurableSpawnComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;

        private PositionGenerationStrategy _positionGenerator;
        private ObjectRotator _rotator;

        private IObjectFactory _objectFactory;

        [Inject]
        private void Construct(IObjectFactory objectFactory)
        {
            _objectFactory = objectFactory;
        }
        
        private void Awake()
        {
            _positionGenerator = GetComponent<PositionGenerationStrategy>();
            _rotator = GetComponent<ObjectRotator>();
        }

        [ContextMenu("Spawn one")]
        public void Spawn()
        {
            var position = _positionGenerator.GeneratePosition();
            var instance = _objectFactory.Create(_prefab, position, Quaternion.identity);
             _rotator.Rotate(instance.transform);
        }
        
        [ContextMenu("Spawn 1000")]
        public void Spawn1000()
        {
            for (int i = 0; i < 1000; i++)
            {
                Spawn();
            }
        }
    }
}