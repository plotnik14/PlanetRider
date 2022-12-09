using UnityEngine;

namespace PlanetRider.Components.Rotators
{
    public class ObjectToGravityRotator : ObjectRotator
    {
        [SerializeField] private Transform _gravityCenter;
        
        public override void Rotate(Transform tr)
        {
            var gravityDirection = _gravityCenter.position - tr.position;
            tr.rotation = Quaternion.FromToRotation( -tr.transform.up, gravityDirection);
        }
    }
}