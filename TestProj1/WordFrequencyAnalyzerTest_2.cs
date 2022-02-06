using System.Collections.Generic;
using Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Test.Helper;

namespace TestProj1
{
    [TestClass]
    public class WordFrequencyAnalyzerTest_2
    {
        WordFrequencyAnalyzer Analyze = new WordFrequencyAnalyzer();
        string Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
            "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
            "when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
            "It has survived not only five centuries, but also the leap into electronic typesetting, " +
            "remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets " +
            "containing Lorem Ipsum passages, and more recently with desktop publishing software " +
            "like Aldus PageMaker including versions of Lorem Ipsum.";

        [TestMethod]
        public void CalculateFrequencyForWordTest()
        {
            var result = Analyze.CalculateFrequencyForWord(Text, "it");

            Assert.IsTrue(result.Equals(3));

            result = Analyze.CalculateFrequencyForWord(Text, "lorem");

            Assert.IsTrue(result.Equals(4));

            result = Analyze.CalculateFrequencyForWord(Text, "ipsum");

            Assert.IsTrue(result.Equals(4));

            result = Analyze.CalculateFrequencyForWord(Text, "the");

            Assert.IsTrue(result.Equals(6));

        }

        [TestMethod]
        public void CalculateHighestFrequencyTest()
        {
            var result = Analyze.CalculateHighestFrequency(Text);
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void CalculateMostFrequentNWordsTest()
        {
            IList<IWordFrequency> list = new WordFrequency[]
            {
                new WordFrequency{ Word = "the", Frequency = 6 },
                new WordFrequency{ Word = "ipsum", Frequency = 4 },
                new WordFrequency{ Word = "lorem", Frequency = 4 }
            };

            var result = Analyze.CalculateMostFrequentNWords(Text, 3);

            Assert.IsTrue(CompareLists(list, result));


            result = Analyze.CalculateMostFrequentNWords(Text, 2);
            list = new WordFrequency[]
            {
                new WordFrequency{ Word = "the", Frequency = 6 },
                new WordFrequency{ Word = "ipsum", Frequency = 4 }
            };

            Assert.IsTrue(CompareLists(list, result));

            result = Analyze.CalculateMostFrequentNWords(Text, 1);
            list = new WordFrequency[]
            {
                new WordFrequency{ Word = "the", Frequency = 6 }
            };

            Assert.IsTrue(CompareLists(list, result));
        }

    }
}
