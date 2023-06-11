using System.Collections.Generic;

namespace Buttons
{
    public class ButtonGenerator
    {
        private Dictionary<ButtonType, string> _mainButtonText = new()
        {
            { ButtonType.Play, "»грать" },
            { ButtonType.Restart, "—ыграть еще раз" },
        };

        private ButtonFactory _factory = new();

        public ButtonModel GetPlayButton()
        {
            return _factory.Create(ButtonType.Play, _mainButtonText[ButtonType.Play]);
        }

        public ButtonModel GetReplayButton()
        {
            return _factory.Create(ButtonType.Restart, _mainButtonText[ButtonType.Restart]);
        }

        public ButtonModel GetLetterButton(char letter)
        {
            return _factory.Create(ButtonType.Letter, letter.ToString());
        }
    }
}