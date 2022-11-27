using System;
using UnityEngine;

namespace PlanetRider.Components
{
    public class AddCoinsComponent : MonoBehaviour
    {
        [SerializeField] private int _amount;
        
        public void AddCoins() {
            GameSession.Instance.Coins += _amount;
        }
    }
}