using UnityEngine;

namespace PlanetRider.PositionGeneration
{
    public abstract class PositionGenerationStrategy : MonoBehaviour
    {
        public abstract Vector3 GeneratePosition();
    }
}