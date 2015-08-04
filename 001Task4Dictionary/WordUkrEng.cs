using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001Task4Dictionary
{
    class WordUkrEng
    {
        public string Word { get; private set; }
        public string UkrTranslation { get; set; }
        public string EngTranslation { get; set; }

        public WordUkrEng(string word, string ukrTranslation, string engTranslation)
        {
            Word = word;
            UkrTranslation = ukrTranslation;
            EngTranslation = engTranslation;
        }

        public override string ToString()
        {
            return Word + " : " + UkrTranslation + " , " + EngTranslation;
        }
    }
}
