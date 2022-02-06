using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateFrequency
{
    public interface IWordFrequencyAnalyzer
    {
        //the highest frequency in the text(several words might actually have this frequency)
        int CalculateHighestFrequency(string text);//
        // frequency of the specified word
        int CalculateFrequencyForWord(string text, string word);
        // list of the most frequent "n" words in the input text, all the words returned in lower case
        IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n);
    }
}
