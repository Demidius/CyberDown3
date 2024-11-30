using UnityEngine;

namespace BsseCode.Caracters.Hero.PlayerStateMachina
{
    public class MovingState : ICharacterState
    {
        public void Enter()
        {
            Debug.Log("Персонаж начал двигаться.");
        }

        public void Execute()
        {
            // Логика для движения персонажа
            Debug.Log("Персонаж движется.");
        }

        public void Exit()
        {
            Debug.Log("Персонаж прекратил движение.");
        }
    }
}