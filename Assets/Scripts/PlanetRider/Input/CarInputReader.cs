using PlanetRider.Actors;
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
            if (context.performed)
            {
                var direction = context.ReadValue<float>();
                _car.SetDirection(direction);
            }

            if (context.canceled)
            {
                _car.SetDirection(0);
            }
        }
    }
}