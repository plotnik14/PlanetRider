using TMPro;
using UnityEngine;

namespace PlanetRider.UI.Widgets
{
    public class CoinsWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinsCounter;

        private void Update()
        {
            // ToDO rework on events
            
            _coinsCounter.text = GameSession.Instance.Coins.ToString();
        }
    }
}