using PlanetRider.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace PlanetRider.Components
{
    public class GameOverComponent : MonoBehaviour
    {
        private IObjectFactory _objectFactory;

        [Inject]
        private void Construct(IObjectFactory objectFactory)
        {
            _objectFactory = objectFactory;
        }
        
        public void ShowGameOverWindow()
        {
            var window = Resources.Load<GameObject>("UI/GameOverWindow");
            var canvas = GameObject.FindWithTag("MainUICanvas").GetComponent<Canvas>();
            _objectFactory.Create(window, canvas.transform);
        }
    }
}