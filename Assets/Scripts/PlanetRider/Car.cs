using System;
using PlanetRider.Audio;
using PlanetRider.Components;
using PlanetRider.Components.Audio;
using PlanetRider.Inventory;
using UnityEngine;
using Zenject;

namespace PlanetRider
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private float _driveSpeed;
        [SerializeField] private float _turnSpeed;
        [SerializeField] private float _fuelConsumption;
        [SerializeField] private AudioClip _engineSound;
        [SerializeField] private PlaySoundComponent _playSoundComponent;

        private Vector2 _direction;
        private Rigidbody _rigidbody;

        private ISfxService _sfxService;
        private IInventoryService _inventory;

        private GameOverComponent _gameOverComponent;

        private bool _hasNoFuel;
        
        [Inject]
        private void Construct(IInventoryService inventory, ISfxService sfxService)
        {
            _inventory = inventory;
            _sfxService = sfxService;
        }
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>(); ;
            _gameOverComponent = GetComponent<GameOverComponent>();
        }

        private void Start()
        {
            _playSoundComponent.Play(_engineSound);

            _inventory.OnFuelRanOut += OnFuelRanOut;

        }

        private void OnFuelRanOut()
        {
            // ToDO stop moving!!
            
            
            _hasNoFuel = true;
            Stop();
            _gameOverComponent.ShowGameOverWindow();
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private void Update()
        {
            ConsumeFuel();
        }

        private void ConsumeFuel()
        {
            if (_hasNoFuel) return;
            
            _inventory.Fuel.Value -= _fuelConsumption * Time.deltaTime;
        }

        private void FixedUpdate()
        {
            CalculateForwardMovement();
            CalculateTurn();
        }

        private void CalculateForwardMovement()
        {
            _rigidbody.velocity = transform.forward * _direction.y * _driveSpeed;
        }

        private void CalculateTurn()
        {
            var turnDirection = _direction.x * _direction.y;
            transform.rotation *= Quaternion.AngleAxis(_turnSpeed * turnDirection, Vector3.up);
        }

        public void Stop()
        {
            _direction = Vector2.zero;
        }
    }
}