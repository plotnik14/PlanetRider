using PlanetRider.Inventory;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace PlanetRider.UI.Windows
{
    public class GameOverWindow : MonoBehaviour
    {
        private IInventoryService _inventory;

        [Inject]
        private void Construct(IInventoryService inventory)
        {
            _inventory = inventory;
        }

        public void OnRestart()
        {
            _inventory.ResetValues();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
            
            // ToDO move to where?
            SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
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