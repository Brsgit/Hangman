
public enum State
{
    Start,
    Game,
    EndGame,
}

namespace FSM
{

    public interface IState
    {
        State State { get; }
        public void Enter();
        public void Exit();
    }


    public class GameStateMachine
    {
        private IState _currentState;

        public void ChangeState(IState newState)
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = newState;
            _currentState.Enter();
        }
    }
}
