using UnityEngine;

namespace PlanetRider.Generators.PositionGeneration
{
    public abstract class PositionGenerationStrategy : MonoBehaviour
    {
        public abstract Vector3 GeneratePosition();
    }
}