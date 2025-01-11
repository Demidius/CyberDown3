using BaseCode2._1.StateMachine.Logic;
using UnityEngine;
using Zenject;

namespace BaseCode2._1.StateMachine
{
    public class GameStateModule : MonoBehaviour, IGameStateModule
    {
        
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(
          IGameStateMachine gameStateMachine
        )
        {
            _gameStateMachine = gameStateMachine;
        }
        
        
    }

    public interface IGameStateModule
    {
    }
}