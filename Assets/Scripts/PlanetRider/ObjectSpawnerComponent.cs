using PlanetRider.PositionGeneration;
using UnityEngine;

namespace PlanetRider
{
    public class ObjectSpawnerComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;

        private PositionGenerationStrategy _positionGenerator;

        private void Awake()
        {
            _positionGenerator = GetComponent<PositionGenerationStrategy>();
        }

        [ContextMenu("Spawn one")]
        public void Spawn()
        {
            var position = _positionGenerator.GeneratePosition();
            Instantiate(_prefab, position, Quaternion.identity);
                
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