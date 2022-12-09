using UnityEngine;

namespace PlanetRider.Components.Rotators
{
    public abstract class ObjectRotator : MonoBehaviour
    {
        public abstract void Rotate(Transform transform);
    }
}