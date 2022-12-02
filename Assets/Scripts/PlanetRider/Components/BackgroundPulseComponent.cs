using UnityEngine;

namespace PlanetRider.Components
{
    public class BackgroundPulseComponent : MonoBehaviour
    {
        [SerializeField] private float _pulseSpeed;
        [SerializeField] private float _positionShift;

        private float _initialPositionZ;
        private float _targetPositionZ;
        private int _directionMod;
        
        private void Awake()
        {
            _initialPositionZ = transform.localPosition.z;
            _targetPositionZ = _initialPositionZ - _positionShift;
            _directionMod = -1;
        }

        private void LateUpdate()
        {
            
            CalculateMovementDirectionMod();
            
            transform.localPosition = new Vector3(
                transform.localPosition.x,
                transform.localPosition.y,
                transform.localPosition.z + _pulseSpeed * _directionMod * Time.deltaTime
            );
        }

        private void CalculateMovementDirectionMod()
        {
            var currentPositionZ = transform.localPosition.z;

            if (currentPositionZ < _targetPositionZ)
            {
                _directionMod = 1;
                return;
            }

            if (currentPositionZ > _initialPositionZ)
                _directionMod = -1;
        }
    }
}