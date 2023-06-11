using FSM;
using UnityEngine;

namespace Controllers
{
    public class GameStateController : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine = new();

        [Header("Game Layouts")]
        [SerializeField] private GameObject _startLayout;
        [SerializeField] private GameObject _keyBoard;
        [SerializeField] private GameObject _gameLayout;
        [SerializeField] private GameObject _endGameLayout;

        [Header("Button Container")]
        [SerializeField] private ButtonController _buttonController;

        private void OnEnable()
        {
            _buttonController.onPlayClicked += StartGame;
            Mediator.onMessage += ProcessResult;
        }

        private void OnDisable()
        {
            _buttonController.onPlayClicked -= StartGame;
            Mediator.onMessage -= ProcessResult;
        }

        void Start()
        {
            _gameStateMachine.ChangeState(new StartState(_startLayout));

        }

        private void StartGame()
        {
            _gameStateMachine.ChangeState(new GameState(_gameLayout, _keyBoard));
        }

        private void StartEndGame()
        {
            _gameStateMachine.ChangeState(new EndGameState(_gameLayout, _endGameLayout));
        }

        private void ProcessResult(Result result)
        {
            StartEndGame();
        }
    }
}