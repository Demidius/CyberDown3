using System.Collections.Generic;

namespace BsseCode._2._Services.LevelServices.GameResults
{
    [System.Serializable]
    public class GameResultsWrapper
    {
        public List<GameResult> results;

        public GameResultsWrapper(List<GameResult> results)
        {
            this.results = results;
        }
    }
}