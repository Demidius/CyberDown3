namespace BsseCode.Caracters.Hero.PlayerStateMachina
{
    public class CharacterStateMachine
    {
        private ICharacterState currentState;

        public void ChangeState(ICharacterState newState)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }

            currentState = newState;
            currentState.Enter();
        }

        public void Update()
        {
            if (currentState != null)
            {
                currentState.Execute();
            }
        }
    }
}
