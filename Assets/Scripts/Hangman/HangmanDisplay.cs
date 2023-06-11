using UnityEngine;
using UnityEngine.UI;

namespace TextMarkers
{
    public class HangmanDisplay : MonoBehaviour
    {
        private IHangmanDisplayStrategy _displayStrategy;

        private Image[] _displayParts;

        private void Start()
        {
            _displayParts = GetComponentsInChildren<Image>();
            _displayStrategy = new HangmanDisplayStrategy(_displayParts);
        }

        public void UpdateHangman()
        {
            _displayStrategy.DisplayNextElement();
        }

        public void RefreshHangman()
        {
            foreach (var image in _displayParts)
            {
                image.enabled = false;
            }

            _displayStrategy = new HangmanDisplayStrategy(_displayParts);
        }
    }
}