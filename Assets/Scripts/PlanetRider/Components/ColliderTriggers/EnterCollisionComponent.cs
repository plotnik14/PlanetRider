using UnityEngine;

namespace PlanetRider.Components.ColliderTriggers
{
    public class EnterCollisionComponent : CollisionCheckComponent
    {
        private void OnCollisionEnter(Collision collision)
        {
            PerformCheck(collision.gameObject);
        }
    }
}