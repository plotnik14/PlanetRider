using UnityEngine.SceneManagement;

namespace PlanetRider.LevelManagement
{
    public class LevelLoader : ILevelLoader
    {
        private string _hudSceneName;
        
        public LevelLoader(string hudSceneName)
        {
            _hudSceneName = hudSceneName;
        }
        
        public void LoadLevel(string levelName, bool loadHud = true)
        {
            SceneManager.LoadScene(levelName);
            
            if (loadHud)
                LoadHud();
        }

        private void LoadHud()
        {
            SceneManager.LoadScene(_hudSceneName, LoadSceneMode.Additive);
        }
    }
}