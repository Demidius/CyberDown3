namespace BsseCode._2._Services.LevelServices.GameResults
{
    [System.Serializable]
    public class GameResult
    {
        public int kills;
        public float survivalTime;
        public int numberOfTry;

        public GameResult(int kills, float survivalTime, int numberOfTry)
        {
            this.kills = kills;
            this.survivalTime = survivalTime;
            this.numberOfTry = numberOfTry;
        }
    }

}