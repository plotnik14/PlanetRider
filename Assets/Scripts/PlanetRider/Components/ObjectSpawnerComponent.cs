using PlanetRider.Generators.PositionGeneration;
using PlanetRider.Rotators;
using PlanetRider.Utils;
using UnityEngine;

namespace PlanetRider.Components
{
    public class ObjectSpawnerComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;

        private PositionGenerationStrategy _positionGenerator;
        private ObjectRotator _rotator;

        private void Awake()
        {
            _positionGenerator = GetComponent<PositionGenerationStrategy>();
            _rotator = GetComponent<ObjectRotator>();
        }

        [ContextMenu("Spawn one")]
        public void Spawn()
        {
            var position = _positionGenerator.GeneratePosition();
            var instance = SpawnUtils.SpawnObject(_prefab, position, Quaternion.identity);
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