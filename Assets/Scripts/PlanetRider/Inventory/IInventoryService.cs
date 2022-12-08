using System;
using UniRx;

namespace PlanetRider.Inventory
{
    public interface IInventoryService
    {
        IntReactiveProperty Coins { get;}
        FloatReactiveProperty Fuel { get;}

        event Action OnFuelRanOut; 

        void ResetValues();

        void AddItem(InventoryItemType type, int amount);
    }
}