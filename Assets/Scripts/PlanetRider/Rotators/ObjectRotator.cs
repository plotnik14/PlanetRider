using UnityEngine;

namespace PlanetRider.Rotators
{
    public abstract class ObjectRotator : MonoBehaviour
    {
        public abstract void Rotate(Transform transform);
    }
}