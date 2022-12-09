using System;
using UnityEngine;

namespace PlanetRider.Components.GameOver
{
    [Serializable]
    public struct GameOverReason
    {
        [SerializeField] private GameOverType _type;
        [SerializeField] private string _message;

        public GameOverType Type => _type;

        public string Message => _message;
    }

    public enum GameOverType
    {
        Crash,
        FuelRanOut
    }
}