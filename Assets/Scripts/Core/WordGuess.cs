using TextMarkers;
using System.Collections.Generic;

public enum Result
{
    Win,
    Lose,
}

namespace WordGeneration
{


    public class WordGuess : IObservable<Result>
    {
        private HangmanDisplay _hangmanDisplay;

        private string _targetWord;

        private int _remainingGuesses;

        private List<IObserver<Result>> _observers = new();

        private List<int> _revealedLetters = new();

        public WordGuess(string word, int guesses)
        {
            this._targetWord = word;
            this._remainingGuesses = guesses;
        }

        public void SetHangmanDisplay(HangmanDisplay hangmanDisplay)
        {
            _hangmanDisplay = hangmanDisplay;
        }

        public List<int> GuessLetter(char letter)
        {

            List<int> result = new();

            var letterExists = false;

            for (int i = 0; i < _targetWord.Length; i++)
            {
                if (_targetWord[i] == letter)
                {
                    letterExists = true;
                    _revealedLetters.Add(i);
                    result.Add(i);
                }
            }

            if (!letterExists)
            {
                _hangmanDisplay.UpdateHangman();
                _remainingGuesses--;
            }

            if (_remainingGuesses == 0)
            {
                Notify(Result.Lose);
            }

            if (_revealedLetters.Count == _targetWord.Length)
            {
                Notify(Result.Win);
            }

            return result;
        }

        public void Subscribe(IObserver<Result> observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver<Result> observer)
        {
            _observers.Add(observer);
        }

        private void Notify(Result result)
        {
            foreach (var obs in _observers)
            {
                obs.Notify(result);
            }

            Mediator.SendMessage(result);
        }
    }
}
