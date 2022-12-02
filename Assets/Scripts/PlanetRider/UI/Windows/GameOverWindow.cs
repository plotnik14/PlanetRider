using PlanetRider.Inventory;
using PlanetRider.LevelManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace PlanetRider.UI.Windows
{
    public class GameOverWindow : MonoBehaviour
    {
        private IInventoryService _inventory;
        private ILevelLoader _levelLoader;
        
        [Inject]
        private void Construct(IInventoryService inventory, ILevelLoader levelLoader)
        {
            _inventory = inventory;
            _levelLoader = levelLoader;
        }

        public void OnRestart()
        {
            _inventory.ResetValues();
            
            _levelLoader.LoadLevel(SceneManager.GetActiveScene().name);
        }

        public void OnExit()
        {
            Application.Quit();
            
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}