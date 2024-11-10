using System.Collections.Generic;

namespace BsseCode.Mechanics.GameResults
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