using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class WordFrequency : IWordFrequency
    {
        private string _word;
        public string Word
        {
            get => _word;
            set => _word = value;
        }
        private int _frequency;
        public int Frequency
        {
            get => _frequency;
            set => _frequency = value;
        }
    }
}
