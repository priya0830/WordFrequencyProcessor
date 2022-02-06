using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static Test.Helper;

namespace Test
{
    [TestClass]
    public class WordFrequencyAnalyzerTest
    {
        WordFrequencyAnalyzer Analyze = new WordFrequencyAnalyzer();
        string Text = "The sun shines over the lake.";

        [TestMethod]
        public void CalculateFrequencyForWordTest()
        {
            var result = Analyze.CalculateFrequencyForWord(Text, "the");

            Assert.IsTrue(result.Equals(2));

            result = Analyze.CalculateFrequencyForWord(Text, "sun");

            Assert.IsTrue(result.Equals(1)); 
            
            result = Analyze.CalculateFrequencyForWord(Text, "you");

            Assert.IsTrue(result.Equals(0)); 
            
            result = Analyze.CalculateFrequencyForWord(Text, "5");

            Assert.IsTrue(result.Equals(0));

        }

        [TestMethod]
        public void CalculateHighestFrequencyTest()
        {
            var result = Analyze.CalculateHighestFrequency(Text);
            Assert.AreEqual(result, 2);
        }
        
        [TestMethod]
        public void CalculateMostFrequentNWordsTest()
        {
            IList<IWordFrequency> list = new WordFrequency[]
            {
                new WordFrequency{ Word = "the", Frequency = 2 },
                new WordFrequency{ Word = "lake", Frequency =1 },
                new WordFrequency{ Word = "over", Frequency = 1 }
            };

            var result = Analyze.CalculateMostFrequentNWords(Text, 3);

            Assert.IsTrue(CompareLists(list, result));


            result = Analyze.CalculateMostFrequentNWords(Text, 2);
            list = new WordFrequency[]
            {
                new WordFrequency{ Word = "the", Frequency = 2 },
                new WordFrequency{ Word = "lake", Frequency =1 }
            };

            Assert.IsTrue(CompareLists(list, result));

            result = Analyze.CalculateMostFrequentNWords(Text, 1);
            list = new WordFrequency[]
            {
                new WordFrequency{ Word = "the", Frequency = 2 }
            };

            Assert.IsTrue(CompareLists(list, result));
        }

    }
}
