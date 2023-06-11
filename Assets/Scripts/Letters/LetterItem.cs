using UnityEngine;

namespace Letters
{

    [RequireComponent(typeof(LetterView))]
    public class LetterItem : MonoBehaviour
    {
        private LetterModel _letter;
        private LetterView _letterView;

        public bool Opened { get; private set; } = false;

        public void Init(LetterModel letter)
        {
            this._letter = letter;

            _letterView = GetComponent<LetterView>();
            _letterView.Init(_letter.Letter);
        }

        public void SetGuessed()
        {
            Opened = true;
            _letterView.OpenLetter();
        }
    }
}
