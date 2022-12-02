using UnityEngine;

namespace PlanetRider.Infrastructure.Factories
{
    public interface IObjectFactory
    {
        GameObject Create(GameObject prefab, Vector3 position, Quaternion rotation, Transform parentTransform);
        GameObject Create(GameObject prefab, Vector3 position, Quaternion rotation);
        GameObject Create(GameObject prefab, Transform parentTransform);
    }
}