using UnityEngine;

namespace DefaultNamespace
{
    public abstract class PositionGenerationStrategy : MonoBehaviour
    {
        public abstract Vector3 GeneratePosition();
    }
}