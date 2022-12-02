using PlanetRider.LevelManagement;
using UnityEngine;
using Zenject;

namespace PlanetRider.UI.Windows
{
    public class MainMenuWindow : MonoBehaviour
    {
        [SerializeField] private string _levelToLoad;

        private ILevelLoader _levelLoader;

        [Inject]
        private void Construct(ILevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }
        
        public void OnStart()
        {
            _levelLoader.LoadLevel(_levelToLoad);
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