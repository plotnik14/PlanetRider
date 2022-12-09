using System;
using UnityEngine;

namespace PlanetRider.Components.ColliderTriggers
{
    public abstract class CollisionCheckComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask = ~0;
        
        public event Action<GameObject> OnTrigger;

        protected void PerformCheck(GameObject go)
        {
            if (IsTouchingLayer(go.layer, _layerMask))
                OnTrigger?.Invoke(go);
        }

        private bool IsTouchingLayer(int objectLayer, LayerMask mask)
        {
            return mask == (mask | 1 << objectLayer);
        }
    }
}