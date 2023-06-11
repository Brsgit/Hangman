using Buttons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Controllers
{
    public class ButtonController : MonoBehaviour, IObserver<GameButton>
    {
        [Header("MenuButtons")]
        [SerializeField] private GameButton _playButton;
        [SerializeField] private GameButton _replayButton;

        [SerializeField] private GameButton _prefab;
        [SerializeField] private GameObject _buttonContainer;

        private ButtonGenerator _buttonGenerator;

        private List<GameButton> _buttonsList = new();

        public event Action onPlayClicked;
        public event Action<string> onLetterClicked;

        private void OnEnable()
        {
            Mediator.onMessage += RecieveMessage;
        }

        private void OnDisable()
        {
            Mediator.onMessage -= RecieveMessage;
        }

        private void Start()
        {
            _buttonGenerator = new ButtonGenerator();

            _playButton.Init(_buttonGenerator.GetPlayButton());
            _playButton.Subscribe(this);


            _replayButton.Init(_buttonGenerator.GetReplayButton());
            _replayButton.Subscribe(this);

            for (char c = 'À'; c <= 'ß'; c++)
            {
                var button = Instantiate(_prefab, _buttonContainer.transform);
                button.Init(_buttonGenerator.GetLetterButton(c));
                button.Subscribe(this);
                _buttonsList.Add(button);
            }
        }

        private async Task ProcessResult()
        {
            await Task.Delay(500);
            foreach (var button in _buttonsList)
            {
                button.ReEnable();
            }

        }

        private void OnDestroy()
        {
            _playButton.Unsubscribe(this);
            _replayButton.Unsubscribe(this);

            foreach (var b in _buttonsList)
                b.Unsubscribe(this);
        }

        private void RecieveMessage(Result result)
        {
            _ = ProcessResult();
        }

        public void Notify(GameButton button)
        {
            var type = button.GetButtonType();
            switch (type)
            {
                case ButtonType.Play:
                    onPlayClicked?.Invoke();
                    break;
                case ButtonType.Restart:
                    onPlayClicked?.Invoke();
                    break;
                case ButtonType.Letter:
                    onLetterClicked?.Invoke(button.GetButtonText());
                    break;
            }
        }
    }
}