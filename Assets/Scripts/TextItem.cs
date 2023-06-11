using UnityEngine;
using UnityEngine.UI;

namespace TextMarkers
{
    public class TextItem : MonoBehaviour
    {
        private Text _textComponent;

        public Text TextComponent => _textComponent;

        private void Awake()
        {
            _textComponent = GetComponent<Text>();
        }

        public void UpdateText(string text)
        {
            _textComponent.text = text;
        }
    }
}