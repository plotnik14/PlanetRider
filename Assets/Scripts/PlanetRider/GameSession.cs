namespace PlanetRider
{
    public class GameSession
    {
        private static GameSession _instance;

        public int Coins { get; set; }
        
        public static GameSession Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameSession();

                return _instance;
            }
        }
    }
}