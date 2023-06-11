using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordGeneration
{
    public class WordGenerator
    {
        private Dictionary<string, int> _words = new();

        private int _gameCircle = 0;

        public WordGenerator(string path = "Assets/Resources/words.txt")
        {
            StreamReader sr = new StreamReader(path);
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                string[] arr = s.Split(",");
                foreach (var w in arr)
                {
                    _words.Add(w, 0);
                }
            }

            sr.Close();
        }

        public string GetWord()
        {
            Random rnd = new Random();
            var list = GetAvailableWords();
            if (list.Count == 0)
            {
                _gameCircle++;
                list = GetAvailableWords();
            }

            var word = list[rnd.Next(list.Count)];
            _words[word] = 1;

            return word.ToUpper();
        }

        private List<string> GetAvailableWords()
        {
            return _words.Where(x => x.Value == _gameCircle).Select(x => x.Key).ToList();

        }
    }
}