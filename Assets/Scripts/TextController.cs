using System.Collections;
using System.IO;
using TextMarkers;
using UnityEngine;

namespace Controllers
{
    public class TextController : MonoBehaviour
    {
        [SerializeField] private TextItem _status;
        [SerializeField] private TextItem _endGame;
        [SerializeField] private TextItem _rules;

        private ButtonController _buttonController;

        private int _loseCount = 0;
        private int _winCount = 0;

        private const string WIN_TEXT = "ПОБЕДА!!";
        private const string LOSE_TEXT = "Они повесили кучерявого Бобби(";

        private void Awake()
        {
            _buttonController = FindObjectOfType<ButtonController>();
        }

        private void OnEnable()
        {
            Mediator.onMessage += IncreaseCounter;
            _buttonController.onPlayClicked += UpdateStatus;
        }

        private void OnDisable()
        {
            Mediator.onMessage -= IncreaseCounter;
            _buttonController.onPlayClicked -= UpdateStatus;
        }

        public void Start()
        {
            UpdateRules();
        }

        private void IncreaseCounter(Result result)
        {
            switch (result)
            {
                case Result.Win:
                    _winCount++;
                    UpdateResultText(true);
                    break;
                case Result.Lose:
                    _loseCount++;
                    UpdateResultText(false);
                    break;
            }

            UpdateStatus();
        }

        private void UpdateStatus()
        {
            var scoreString = string.Format("Выиграно: {0}. Проиграно: {1}.", _winCount, _loseCount);

            StartCoroutine(TextUpdater(_status, scoreString));
        }

        private void UpdateResultText(bool win)
        {
            var str = win ? WIN_TEXT : LOSE_TEXT;

            StartCoroutine(TextUpdater(_endGame, str));
        }

        private void UpdateRules()
        {
            string path = "Assets/Resources/rules.txt";
            StreamReader sr = new(path);
            var str = sr.ReadToEnd();

            StartCoroutine(TextUpdater(_rules, str));

            sr.Close();
        }

        private IEnumerator TextUpdater(TextItem item, string text)
        {
            yield return new WaitUntil(()=> item != null);

            item.UpdateText(text);
        }
    }
}