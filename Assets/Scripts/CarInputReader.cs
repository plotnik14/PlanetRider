using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class CarInputReader : MonoBehaviour
    {
        private CarController _car;

        private void Awake()
        {
            _car = GetComponent<CarController>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                var direction = context.ReadValue<Vector2>();
                _car.SetDirection(direction);
            }

            if (context.canceled)
            {
                _car.SetDirection(Vector2.zero);
            }
        }
    }
}