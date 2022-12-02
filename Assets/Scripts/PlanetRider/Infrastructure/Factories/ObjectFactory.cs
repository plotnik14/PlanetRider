using UnityEngine;
using Zenject;

namespace PlanetRider.Infrastructure.Factories
{
    public class ObjectFactory : IObjectFactory 
    {
        private const string DefaultParentObjectName = "--- SPAWNED ---";

        private readonly GameObject _defaultParentObject;
        private readonly DiContainer _diContainer;

        public ObjectFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
            _defaultParentObject = new GameObject(DefaultParentObjectName);
        }

        public GameObject Create(GameObject prefab, Vector3 position, Quaternion rotation, Transform parentTransform)
        {
            return _diContainer.InstantiatePrefab(prefab, position, rotation, parentTransform);
        }
        
        public GameObject Create(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            return Create(prefab, position, rotation, _defaultParentObject.transform);
        }
        
        public GameObject Create(GameObject prefab, Transform parentTransform)
        {
            return _diContainer.InstantiatePrefab(prefab, parentTransform);
        }
    }
}