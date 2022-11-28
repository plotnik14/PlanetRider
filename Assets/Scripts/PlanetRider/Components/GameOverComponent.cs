using UnityEngine;

namespace PlanetRider.Components
{
    public class GameOverComponent : MonoBehaviour
    {
        public void ShowGameOverWindow()
        {
            var window = Resources.Load<GameObject>("UI/GameOverWindow");
            var canvas = GameObject.FindWithTag("MainUICanvas").GetComponent<Canvas>();
            Object.Instantiate(window, canvas.transform);
        }
    }
}