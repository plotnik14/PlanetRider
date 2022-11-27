using UnityEngine;
using UnityEngine.InputSystem;

namespace PlanetRider.Input
{
    public class CarInputReader : MonoBehaviour
    {
        private Car _car;

        private void Awake()
        {
            _car = GetComponent<Car>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            // Always ride mode
            
            if (context.performed)
            {
                var direction = context.ReadValue<Vector2>();
                direction.y = 1;
                
                _car.SetDirection(direction);
            }

            if (context.canceled)
            {
                _car.SetDirection(Vector2.up);
            }
        }
    }
}