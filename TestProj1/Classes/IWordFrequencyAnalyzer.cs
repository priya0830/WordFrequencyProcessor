using System.Collections.Generic;

namespace Test
{
    public interface IWordFrequencyAnalyzer
    {
        int CalculateHighestFrequency(string text);//
        int CalculateFrequencyForWord(string text, string word);
        IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n);
    }
}
