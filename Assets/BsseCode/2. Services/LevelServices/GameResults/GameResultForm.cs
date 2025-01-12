namespace BsseCode._2._Services.LevelServices.GameResults
{
    [System.Serializable]
    public class GameResultForm
    {
        public int kills;
        public float survivalTime;
        public int numberOfTry;

        public GameResultForm(int kills, float survivalTime, int numberOfTry)
        {
            this.kills = kills;
            this.survivalTime = survivalTime;
            this.numberOfTry = numberOfTry;
        }
    }

}