using System;
using UnityEngine;

namespace PlanetRider.Components.ColliderTriggers
{
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask = ~0;
        
        public event Action<GameObject> OnTrigger;

        private void OnTriggerEnter(Collider other)
        {
            if (IsTouchingLayer(other.gameObject.layer, _layerMask))
                OnTrigger?.Invoke(other.gameObject);
        }

        private bool IsTouchingLayer(int objectLayer, LayerMask mask)
        {
            return mask == (mask | 1 << objectLayer);
        }
    }
}