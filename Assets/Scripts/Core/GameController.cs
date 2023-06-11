using TextMarkers;
using System.Collections;
using UnityEngine;
using WordGeneration;
using Letters;

namespace Controllers
{
    public class GameController : MonoBehaviour, IObserver<Result>
    {
        [SerializeField] private LettersContainer _lettersContainer;
        [SerializeField] private ButtonController _buttonController;

        [SerializeField] private HangmanDisplay _hangmanDisplay;

        private const int MAX_MISTAKE_AMOUNT = 7;

        private WordGenerator _wordgenerator;
        private WordGuess _wordGuess;

        private void OnEnable()
        {
            _buttonController.onLetterClicked += GuessLetter;
            _buttonController.onPlayClicked += PrepareWord;
        }

        private void OnDisable()
        {
            _buttonController.onLetterClicked -= GuessLetter;
            _buttonController.onPlayClicked -= PrepareWord;
        }

        private void Start()
        {
            _wordgenerator = new WordGenerator();

        }

        private void PrepareWord()
        {
            var word = _wordgenerator.GetWord();

            _wordGuess = new WordGuess(word, MAX_MISTAKE_AMOUNT);
            _wordGuess.Subscribe(this);

            _lettersContainer.Init(word);

            StartCoroutine(ProcessHangman());
        }

        private IEnumerator ProcessHangman()
        {
            yield return new WaitUntil(() => _hangmanDisplay != null);

            _hangmanDisplay.RefreshHangman();
            _wordGuess.SetHangmanDisplay(_hangmanDisplay);
        }

        private void GuessLetter(string s)
        {
            var indicies = _wordGuess.GuessLetter(char.Parse(s));

            if (indicies.Count != 0)
                _lettersContainer.OpenLetters(indicies);
        }

        private void ProcessLose()
        {
            _lettersContainer.OpenLetters();
        }

        private void ProcessWin()
        {
            // mock
        }

        public void Notify(Result data)
        {
            switch (data)
            {
                case Result.Win:
                    ProcessWin();
                    break;
                case Result.Lose:
                    ProcessLose();
                    break;
            }
        }
    }
}