using PlanetRider.Inventory;
using UnityEngine;
using Zenject;

namespace PlanetRider.Components.Collectors
{
    public class CollectFuelComponent : MonoBehaviour
    {
        [SerializeField] private int _amount;

        private IInventoryService _inventory;

        [Inject]
        private void Construct(IInventoryService inventory)
        {
            _inventory = inventory;
        }
        
        public void AddFuel()
        {
            _inventory.Fuel.Value += _amount;
        }
    }
}