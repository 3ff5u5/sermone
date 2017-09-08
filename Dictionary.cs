using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sermone
{
    class Dictionary
    {
        private int _wordsCount;
        private string[] _wordsOriginal;
        private string[] _wordsTranslated;

        public Dictionary(int count, string[] original, string[] translated)
        {
            wordsCount = count;
            _wordsOriginal = original;
            _wordsTranslated = translated;
        }
        public int wordsCount
        {
            get { return _wordsCount; }
            set { _wordsCount = value; }
        }

        public string getWordOriginal(int IDX)
        {
            return _wordsOriginal[IDX];
        }

        public string getWordTranslated(int IDX)
        {
            return _wordsTranslated[IDX];
        }
    }
}
