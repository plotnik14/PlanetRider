using PlanetRider.Audio;
using PlanetRider.Components.ColliderTriggers;
using PlanetRider.Inventory;
using UnityEngine;
using Zenject;

namespace PlanetRider.Components.Collectable
{
    [RequireComponent(typeof(EnterTriggerComponent))]
    public class CollectableItem : MonoBehaviour
    {
        [SerializeField] private InventoryItemType _type;
        [SerializeField] private int _amount;
        [SerializeField] private AudioClip _collectSound;

        private EnterTriggerComponent _trigger;
        
        private ISfxService _sfxService;
        private IInventoryService _inventory;

        [Inject]
        private void Construct(ISfxService sfxService, IInventoryService inventory)
        {
            _sfxService = sfxService;
            _inventory = inventory;
        }
        
        private void Awake()
        {
            _trigger = GetComponent<EnterTriggerComponent>();
            _trigger.OnTrigger += Collect;
        }

        private void Collect(GameObject go)
        {
            _inventory.AddItem(_type, _amount);
            _sfxService.PlayOneShot(_collectSound);
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _trigger.OnTrigger -= Collect;
        }
    }
}