using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sermone
{
    class Dictionary
    {
        private int _wordsCount;
        private List<string> _wordsOriginal;
        private List<string> _wordsTranslated;
        private string _nameOfDictionary;

        public Dictionary(int count, List<string> original, List<string> translated, string path)
        {
            wordsCount = count;
            _wordsOriginal = original;
            _wordsTranslated = translated;
            _nameOfDictionary = path;
        }
        public int wordsCount
        {
            get { return _wordsCount; }
            set { _wordsCount = value; }
        }

        public string getName
        {
            get { return _nameOfDictionary; }
        }

        public string getWordOriginal(int IDX)
        {
            return _wordsOriginal[IDX];
        }

        public string getWordTranslated(int IDX)
        {
            return _wordsTranslated[IDX];
        }

        public List<string> getAllWordsOriginal
        {
            get { return _wordsOriginal; }
        }

        public List<string> getAllWordsTranslated
        {
            get { return _wordsTranslated; }
        }
    }
}
