using UnityEngine;
using UnityEngine.Events;

namespace PlanetRider.Components
{
    public class EnterCollisionComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask = ~0;
        [SerializeField] private UnityEvent _onTrigger;

        private void OnCollisionEnter(Collision collision)
        {
            if (IsTouchingLayer(collision.gameObject.layer, _layerMask))
                _onTrigger?.Invoke();
        }

        private bool IsTouchingLayer(int objectLayer, LayerMask mask)
        {
            return mask == (mask | 1 << objectLayer);
        }
    }
}