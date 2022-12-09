using UnityEngine;

namespace PlanetRider.Components.ColliderTriggers
{
    public class EnterTriggerComponent : CollisionCheckComponent
    {
        private void OnTriggerEnter(Collider other)
        {
            PerformCheck(other.gameObject);
        }
    }
}