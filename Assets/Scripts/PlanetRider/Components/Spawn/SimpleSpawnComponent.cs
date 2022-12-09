using PlanetRider.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace PlanetRider.Components.Spawn
{
    public class SimpleSpawnComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _transform;
        
        private IObjectFactory _objectFactory;

        [Inject]
        private void Construct(IObjectFactory objectFactory)
        {
            _objectFactory = objectFactory;
        }
        
        [ContextMenu("Spawn")]
        public void Spawn()
        {
            _objectFactory.Create(_prefab, _transform.position, Quaternion.identity);
        }
        
    }
}