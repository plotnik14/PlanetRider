using UnityEngine;

namespace PlanetRider.Components.Rotators
{
    public class EditorRotateToTargetComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        [ContextMenu("Rotate")]
        private void Rotate()
        {
            transform.rotation = Quaternion.identity;
            var direction = _target.position - transform.position;
            transform.rotation = Quaternion.FromToRotation( - transform.up, direction);
        }
        
        private void OnDrawGizmosSelected()
        {
            var direction = _target.position - transform.position;

            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, direction);

            Gizmos.color = Color.magenta;
            Gizmos.DrawRay(transform.position, - transform.up);
            
            Gizmos.color = Color.white;
        }
    }
}