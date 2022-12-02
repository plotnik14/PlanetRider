namespace PlanetRider.LevelManagement
{
    public interface ILevelLoader
    {
        void LoadLevel(string levelName, bool loadHud = true);
    }
}