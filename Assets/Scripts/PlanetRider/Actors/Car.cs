using PlanetRider.Audio;
using PlanetRider.Components.Audio;
using PlanetRider.Components.ColliderTriggers;
using PlanetRider.Components.GameOver;
using PlanetRider.Inventory;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace PlanetRider.Actors
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private float _driveSpeed;
        [SerializeField] private float _turnSpeed;
        [SerializeField] private float _fuelConsumption;
        
        [Space][Header("Audio")]
        [SerializeField] private PlaySoundComponent _playEngineSound;
        [SerializeField] private AudioClip _engineSound;
        [SerializeField] private AudioClip _fuelRanOut;
        [SerializeField] private AudioClip _carCrash;

        private float _direction;
        private Rigidbody _rigidbody;
        private bool _isDriving;
        
        private ISfxService _sfxService;
        private IInventoryService _inventory;

        private GameOverComponent _gameOverComponent;
        private CollisionCheckComponent _collisionCheck;
        private PlayerInput _playerInput;

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
            _playEngineSound.Play(_engineSound);
            _inventory.OnFuelRanOut += OnFuelRanOut;
            _collisionCheck.OnTrigger += OnCollision;
        }

        private void OnCollision(GameObject go)
        {
            EndGame(GameOverType.Crash, _carCrash);
        }

        private void OnFuelRanOut()
        {
            EndGame(GameOverType.FuelRanOut, _fuelRanOut);
        }

        private void /* Avengers: */ EndGame(GameOverType gameOverType, AudioClip gameOverSound)
        {
            _playerInput.enabled = false;
            StopCar();
            _sfxService.PlayOneShot(gameOverSound);
            _gameOverComponent.ShowGameOverWindow(gameOverType);
        }

        public void SetDirection(float direction)
        {
            _direction = direction;
            _isDriving = true;
        }

        private void Update()
        {
            ConsumeFuel();
        }

        private void ConsumeFuel()
        {
            if (!_isDriving) return;
            
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

        private void StopCar()
        {
            _isDriving = false;
            _playEngineSound.Stop();
        }

        private void OnDestroy()
        {
            _inventory.OnFuelRanOut -= OnFuelRanOut;
            _collisionCheck.OnTrigger -= OnCollision;
        }
    }
}