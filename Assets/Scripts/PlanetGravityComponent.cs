using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Collider))]
    public class PlanetGravityComponent : MonoBehaviour
    {
        [SerializeField] private float _gravity;
        [SerializeField] private float _rotationSpeed;

        private void OnTriggerStay(Collider other)
        {
            var rb = other.GetComponent<Rigidbody>();
            if (rb == null) return;
            
            var gravityDirection = transform.position - rb.position;
            ApplyGravity(rb, gravityDirection);
            RotateToGravityCenter(rb, gravityDirection);
        }
        
        private void ApplyGravity(Rigidbody rb, Vector3 gravityDirection)
        {
            rb.AddForce(gravityDirection.normalized * _gravity * rb.mass);
        }

        private void RotateToGravityCenter(Rigidbody rb, Vector3 gravityDirection)
        {
            var orientationDirection = rb.rotation * Quaternion.FromToRotation( -rb.transform.up, gravityDirection);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, orientationDirection, _rotationSpeed * Time.deltaTime));
        }
    }
}