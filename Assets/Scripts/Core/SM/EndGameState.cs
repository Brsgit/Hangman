using UnityEngine;

namespace FSM
{
    public class EndGameState : IState
    {
        public GameObject _gameScreen;
        public GameObject _restartLayout;

        public State State => State.EndGame;

        public EndGameState(GameObject gameScreen, GameObject restartLayout)
        {
            _gameScreen = gameScreen;
            _restartLayout = restartLayout;
        }

        public void Enter()
        {
            _restartLayout.SetActive(true);
        }

        public void Exit()
        {
            _gameScreen.SetActive(false);
            _restartLayout.SetActive(false);
        }
    }
}