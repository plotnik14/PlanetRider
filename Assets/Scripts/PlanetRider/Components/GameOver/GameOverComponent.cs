using System.Collections.Generic;
using PlanetRider.Infrastructure.Factories;
using PlanetRider.UI.Windows;
using UnityEngine;
using Zenject;

namespace PlanetRider.Components.GameOver
{
    public class GameOverComponent : MonoBehaviour
    {
        [SerializeField] private List<GameOverReason> _reasons;

        private IObjectFactory _objectFactory;

        [Inject]
        private void Construct(IObjectFactory objectFactory)
        {
            _objectFactory = objectFactory;
        }
        
        public void ShowGameOverWindow(GameOverType gameOverType)
        {
            var windowPrefab = Resources.Load<GameObject>("UI/GameOverWindow");
            var canvas = GameObject.FindWithTag("MainUICanvas").GetComponent<Canvas>();
            var instance = _objectFactory.Create(windowPrefab, canvas.transform);
            
            var message = GetReasonMessageByType(gameOverType);
            var window = instance.GetComponent<GameOverWindow>();
            window.SetGameOverReason(message);
        }

        private string GetReasonMessageByType(GameOverType type)
        {
            return _reasons.Find(reason => reason.Type == type).Message;
        }
    }
}