using PlanetRider.Inventory;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace PlanetRider.UI.Widgets
{
    public class CoinsWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinsCounter;

        private IInventoryService _inventory;

        [Inject]
        private void Construct(IInventoryService inventory)
        {
            _inventory = inventory;
        }
        
        private void Start()
        {
            _coinsCounter.text = _inventory.Coins.Value.ToString();
            
            _inventory.Coins.Subscribe(value => _coinsCounter.text = value.ToString());
        }
    }
}