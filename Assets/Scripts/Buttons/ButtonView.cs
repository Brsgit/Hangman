using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    public class ButtonView : MonoBehaviour
    {
        private Text _textComponent;

        public void Init(string text)
        {
            _textComponent = GetComponentInChildren<Text>();
            _textComponent.text = text;
        }
    }
}