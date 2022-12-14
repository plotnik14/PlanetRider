using System;
using UniRx;

namespace PlanetRider.Inventory
{
    public class InventoryService : IInventoryService
    {
        private const int CoinsDefault = 0;
        private const int FuelDefault = 20;
        
        public IntReactiveProperty Coins { get; }
        public FloatReactiveProperty Fuel { get; }
        
        public event Action OnFuelRanOut;

        public InventoryService()
        {
            Coins = new IntReactiveProperty(CoinsDefault);
            Fuel = new FloatReactiveProperty(FuelDefault);

            InitFuelRanOutTracking();
        }

        private void InitFuelRanOutTracking()
        {
            Fuel.Subscribe(value =>
            {
                if (value <= 0)
                    OnFuelRanOut?.Invoke();
            });
        }

        public void ResetValues()
        {
            Coins.Value = CoinsDefault;
            Fuel.Value = FuelDefault;
        }

        public void AddItem(InventoryItemType type, int amount)
        {
            // Rework to dictionary if new types are introduced
            
            switch (type)
            {
                case InventoryItemType.Coin:
                    Coins.Value += amount;
                    break;
                case InventoryItemType.Fuel:
                    Fuel.Value += amount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}