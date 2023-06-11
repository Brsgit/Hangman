using UnityEngine;

namespace FSM
{
    public class GameState : IState
    {
        private GameObject _gameScreen;
        private GameObject _keyLayout;

        public State State => State.Start;

        public GameState(GameObject gameScreen, GameObject keyLayout)
        {
            _gameScreen = gameScreen;
            _keyLayout = keyLayout;
        }

        public void Enter()
        {
            _gameScreen.SetActive(true);
            _keyLayout.SetActive(true);
        }

        public void Exit()
        {
            _keyLayout.SetActive(false);
        }
    }
}