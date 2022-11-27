using UnityEngine;

namespace PlanetRider
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] private float _driveSpeed;
        [SerializeField] private float _turnSpeed;

        private float _orientationSpeed = 1f;
        
        private Vector2 _direction;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>(); ;
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private void FixedUpdate()
        {
            CalculateForwardMovement();
            CalculateTurn();
        }

        private void CalculateForwardMovement()
        {
            _rigidbody.velocity = transform.forward * _direction.y * _driveSpeed;
        }

        private void CalculateTurn()
        {
            var turnDirection = _direction.x * _direction.y;
            transform.rotation *= Quaternion.AngleAxis(_turnSpeed * turnDirection, Vector3.up);
        }
    }
}