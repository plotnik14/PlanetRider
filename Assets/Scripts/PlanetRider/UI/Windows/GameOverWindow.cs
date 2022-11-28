using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlanetRider.UI.Windows
{
    public class GameOverWindow : MonoBehaviour
    {
        public void Restart()
        {
            // ToDo rework
            SceneManager.LoadScene(0);
            GameSession.Instance.Coins = 0;
        }
    }
}