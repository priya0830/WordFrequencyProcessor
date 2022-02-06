using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Test
{
    public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
    {
        public int CalculateFrequencyForWord(string text, string word)
        {
            int count = 0;
            
            // get list of words:
            var WordsList = Regex.Split(text.ToLower(), @"\W+")
                .Where(x => x.Length > 0);
            
            foreach(var _word in WordsList)
            {
                if(_word == word)
                {
                    count++;
                }
            }
            return count;
        }

        public int CalculateHighestFrequency(string text)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            int HighestFrequency = 0;
            string[] words = text.Split(delimiterChars);
            foreach(var word in words)
            {
                if (word.Length > 0)
                {
                    int frequency = CalculateFrequencyForWord(text, word);
                    if (frequency > HighestFrequency)
                    {
                        HighestFrequency = frequency;
                    }
                }
            }
            return HighestFrequency;
        }

        public IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n)
        {
            IList<IWordFrequency> MostFrequentWords = new WordFrequency[n];

            // Fetch each word, non-zero length, sort in alphabetical order and descending order of count.
            var res = Regex.Split(text.ToLower(), @"\W+")
                .Where(x => x.Length > 0)
                .GroupBy(s => s)
                .OrderBy(a => a.Key)
                .OrderByDescending(g => g.Count());

            int counter = 0;

            foreach(var word in res)
            {
                IWordFrequency frequency = new WordFrequency()
                {
                    Word = word.Key,
                    Frequency = word.Count()
                };
                if(counter < n)
                {
                    MostFrequentWords[counter] = frequency;
                    counter++;
                }
                else
                {
                    break;
                }
            }
            return MostFrequentWords;
        }
    }
}
