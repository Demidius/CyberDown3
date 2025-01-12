using System.Collections.Generic;

namespace BsseCode._2._Services.LevelServices.GameResults
{
    [System.Serializable]
    public class GameResultsWrapper
    {
        public List<GameResultForm> results;

        public GameResultsWrapper(List<GameResultForm> results)
        {
            this.results = results;
        }
    }
}