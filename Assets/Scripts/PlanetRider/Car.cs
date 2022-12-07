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

        private float _direction;
        private Rigidbody _rigidbody;

        private ISfxService _sfxService;
        private IInventoryService _inventory;

        private GameOverComponent _gameOverComponent;

        private bool _hasNoFuel;
        private bool _isDriving;
        
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
            _hasNoFuel = true;
            Stop();
            _gameOverComponent.ShowGameOverWindow();
        }

        public void SetDirection(float direction)
        {
            _direction = direction;
            _isDriving = true; // ToDo create activation trigger?
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
            if (!_isDriving)
            {
                _rigidbody.velocity = Vector3.zero;
                return;
            }

            _rigidbody.velocity = transform.forward * _driveSpeed;
        }

        private void CalculateTurn()
        {
            transform.rotation *= Quaternion.AngleAxis(_turnSpeed * _direction, Vector3.up);
        }

        public void Stop()
        {
            _isDriving = false;
        }
    }
}