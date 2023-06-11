using System.Collections.Generic;
using UnityEngine;

namespace Letters
{
    public class LettersContainer : MonoBehaviour
    {
        [SerializeField] private LetterItem _prefab;

        private List<LetterItem> _list = new();

        private LettersFactory lf = new();

        public void Init(string word)
        {
            ClearContainer();
            for (int i = 0; i < word.Length; i++)
            {
                var letter = Instantiate(_prefab, transform);
                letter.Init(lf.Create(word[i]));
                _list.Add(letter);
            }
        }

        private void ClearContainer()
        {
            while (_list.Count != 0)
            {
                var letter = _list[0];
                Destroy(letter.gameObject);
                _list.RemoveAt(0);
            }
        }

        public void OpenLetters(List<int> indices)
        {
            foreach (var i in indices)
            {
                _list[i].SetGuessed();
            }
        }

        public void OpenLetters()
        {
            foreach (var l in _list)
            {
                if (!l.Opened)
                {
                    l.SetGuessed();
                }
            }
        }
    }
}