using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlanetRider.UI.Windows
{
    public class MainMenuWindow : MonoBehaviour
    {
        [SerializeField] private string _levelToLoad;
        [SerializeField] private string _hudSceneName;
        
        public void OnStart()
        {
            SceneManager.LoadScene(_levelToLoad);
            
            // ToDO move to where?
            SceneManager.LoadScene(_hudSceneName, LoadSceneMode.Additive);
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