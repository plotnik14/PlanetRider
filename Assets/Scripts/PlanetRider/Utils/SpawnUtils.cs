using UnityEngine;

namespace PlanetRider.Utils
{
    public static class SpawnUtils
    {
        private static readonly string ContainerName = "--- SPAWNED ---";

        private static GameObject _container;

        public static GameObject SpawnObject(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            var container = GetContainer();
            return Object.Instantiate(prefab, position, rotation, container.transform);
        }

        private static GameObject GetContainer()
        {
            if (_container == null)
                _container = new GameObject(ContainerName);
            
            return _container;
        }
    }
}