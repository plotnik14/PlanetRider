using PlanetRider.Utils;
using UnityEngine;

namespace PlanetRider.Components
{
    public class SimpleSpawnComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _transform;
        
        [ContextMenu("Spawn")]
        public void Spawn()
        {
            SpawnUtils.SpawnObject(_prefab, _transform.position, Quaternion.identity);
        }
        
    }
}