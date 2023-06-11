
public enum ButtonType
{
    Play,
    Restart,
    Letter,
}

namespace Buttons
{
    public class ButtonModel
    {
        private string _text;
        public string Text => _text;

        private ButtonType _type;
        public ButtonType Type => _type;

        public ButtonModel(ButtonType type, string text)
        {
            this._type = type;
            this._text = text;
        }
    }
}
