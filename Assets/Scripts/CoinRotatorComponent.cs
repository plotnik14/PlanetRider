using UnityEngine;

namespace DefaultNamespace
{
    public class CoinRotatorComponent : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;

        private void Update()
        {
            transform.rotation *= Quaternion.AngleAxis(_rotationSpeed * Time.deltaTime, Vector3.up);
            // transform.rotation *= Quaternion.Euler(0, _rotationSpeed * Time.deltaTime, 0);
        }
    }
}