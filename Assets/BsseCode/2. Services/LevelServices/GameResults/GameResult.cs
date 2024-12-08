namespace BsseCode._2._Services.LevelServices.GameResults
{
    [System.Serializable]
    public class GameResult
    {
        public int kills;
        public float survivalTime;

        public GameResult(int kills, float survivalTime)
        {
            this.kills = kills;
            this.survivalTime = survivalTime;
        }
    }

}