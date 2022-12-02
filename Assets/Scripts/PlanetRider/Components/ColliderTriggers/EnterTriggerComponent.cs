using UnityEngine;
using UnityEngine.Events;

namespace PlanetRider.Components.ColliderTriggers
{
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask = ~0;
        [SerializeField] private UnityEvent _onTrigger;

        private void OnTriggerEnter(Collider other)
        {
            if (IsTouchingLayer(other.gameObject.layer, _layerMask))
                _onTrigger?.Invoke();
        }

        private bool IsTouchingLayer(int objectLayer, LayerMask mask)
        {
            return mask == (mask | 1 << objectLayer);
        }
    }
}