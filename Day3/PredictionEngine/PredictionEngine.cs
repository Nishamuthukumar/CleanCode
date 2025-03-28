using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictionEngine
{
    internal class PredictionEngine
    {
        ILanguageModelAlgo LanguageModelAlgo;
        public PredictionEngine(ILanguageModelAlgo algo) {
            LanguageModelAlgo = algo;
        }
        private string Predict(string phrase)
        {
            string lastword = getLastWord(phrase);

            if (phrase.EndsWith(" "))
            {
                return LanguageModelAlgo.predictUsingBigram(lastword);
            }
            else
            {
                return LanguageModelAlgo.predictUsingMonogram(lastword);
            }
        }

        private string getLastWord(string phrase)
        {
            string[] words = phrase.Trim().Split(" ");
            string lastword = words[words.Length - 1];
            return lastword;
        }
    }
}
