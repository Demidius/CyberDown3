

namespace BsseCode.Caracters.Hero.PlayerStateMachina
{
    public interface ICharacterState
    {
        void Enter();
        void Execute();
        void Exit();
    }
}