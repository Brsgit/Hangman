using UnityEngine;
using UnityEngine.UI;

namespace Letters
{
    public class LetterView : MonoBehaviour
    {
        private Text _text;

        public void Init(char letter)
        {
            _text = GetComponentInChildren<Text>();
            _text.text = letter.ToString();
            _text.enabled = false;
        }

        public void OpenLetter()
        {
            _text.enabled = true;
        }
    }
}