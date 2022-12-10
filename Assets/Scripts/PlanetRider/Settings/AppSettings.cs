using UnityEngine;

namespace PlanetRider.Settings
{
    [CreateAssetMenu(menuName = "Settings/AppSettings", fileName = "AppSettings")]
    public class AppSettings : ScriptableObject
    {
        [SerializeField] private string _hudSceneName;

        public string HudSceneName => _hudSceneName;
    }
}