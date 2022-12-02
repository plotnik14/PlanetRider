using PlanetRider.Inventory;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace PlanetRider.UI.Widgets
{
    public class FuelWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _fuelCounter;

        private IInventoryService _inventory;

        [Inject]
        private void Construct(IInventoryService inventory)
        {
            _inventory = inventory;
        }
        
        private void Start()
        {
            _fuelCounter.text = _inventory.Fuel.Value.ToString("0.0");
            
            _inventory.Fuel.Subscribe(value => _fuelCounter.text = value.ToString("0.0"));
        }
    }
}