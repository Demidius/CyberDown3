using BsseCode.Services;
using BsseCode.Services.InputFol;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode.Caracters.Hero.PlayerStateMachina
{
    public class IdleState : ICharacterState
    {
        [Inject]
        public void Construct(IInputService inputService, ITimeService timeService, MoveService moveService)
        {
            
        }

        public void Enter()
        {
            Debug.Log("Персонаж остановился.");
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            Debug.Log("Персонаж начал двигаться.");
        }
    }
}