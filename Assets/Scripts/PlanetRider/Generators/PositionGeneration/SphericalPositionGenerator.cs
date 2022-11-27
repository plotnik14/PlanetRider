using UnityEngine;
using Random = UnityEngine.Random;

namespace PlanetRider.Generators.PositionGeneration
{
    public class SphericalPositionGenerator : PositionGenerationStrategy
    {
        [SerializeField] private float _sphereRadius = 1f;
        
        public override Vector3 GeneratePosition()
        {
            var z = Random.Range(-_sphereRadius, _sphereRadius);

            var cylinderHeight = Mathf.Abs(z) * 2;
            var cylinderRadius = Mathf.Sqrt(_sphereRadius * _sphereRadius - cylinderHeight * cylinderHeight / 4);
            
            var angle = Random.Range(0, 2 * Mathf.PI);
            
            var x = Mathf.Cos(angle) * cylinderRadius;
            var y = Mathf.Sin(angle) * cylinderRadius;

            return new Vector3(x, y, z);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, _sphereRadius);
        }
    }
}