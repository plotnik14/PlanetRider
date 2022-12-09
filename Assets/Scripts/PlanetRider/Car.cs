using System;
using PlanetRider.Audio;
using PlanetRider.Components.Audio;
using PlanetRider.Components.ColliderTriggers;
using PlanetRider.Components.GameOver;
using PlanetRider.Inventory;
using UnityEngine;
using UnityEngine.InputSystem;
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
        private CollisionCheckComponent _collisionCheck;
        private PlayerInput _playerInput;

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
            _collisionCheck = GetComponent<CollisionCheckComponent>();
            _playerInput = GetComponent<PlayerInput>();
        }

        private void Start()
        {
            _playSoundComponent.Play(_engineSound);
            _inventory.OnFuelRanOut += OnFuelRanOut;
            _collisionCheck.OnTrigger += OnCollision;
        }

        private void OnCollision(GameObject go)
        {
            _playerInput.enabled = false;
            StopCar();
            _gameOverComponent.ShowGameOverWindow(GameOverType.Crash);
        }

        private void OnFuelRanOut()
        {
            _playerInput.enabled = false;
            _hasNoFuel = true;
            StopCar();
            _gameOverComponent.ShowGameOverWindow(GameOverType.FuelRanOut);
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

        public void StopCar()
        {
            _isDriving = false;
        }

        private void OnDestroy()
        {
            _inventory.OnFuelRanOut -= OnFuelRanOut;
            _collisionCheck.OnTrigger -= OnCollision;
        }
    }
}