using UnityEngine.UI;

namespace TextMarkers
{
    public class HangmanDisplayStrategy : IHangmanDisplayStrategy
    {
        private Image[] _hangmanParts;
        private int _currentStage;

        public HangmanDisplayStrategy(Image[] parts)
        {
            _hangmanParts = parts;
        }

        public void DisplayNextElement()
        {
            if (_currentStage < _hangmanParts.Length)
            {
                _hangmanParts[_currentStage].enabled = true;
                _currentStage++;
            }
        }
    }
}