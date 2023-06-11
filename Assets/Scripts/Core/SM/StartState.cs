using UnityEngine;

namespace FSM
{
    public class StartState : IState
    {
        private GameObject _startScreen;

        public State State => State.Start;

        public StartState(GameObject startScreen)
        {
            _startScreen = startScreen;
        }

        public void Enter()
        {
            _startScreen.SetActive(true);
        }

        public void Exit()
        {
            _startScreen.SetActive(false);
        }
    }
}