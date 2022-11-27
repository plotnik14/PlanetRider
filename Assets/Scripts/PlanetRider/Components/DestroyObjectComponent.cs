using UnityEngine;

namespace PlanetRider.Components
{
    public class DestroyObjectComponent : MonoBehaviour
    {
        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}