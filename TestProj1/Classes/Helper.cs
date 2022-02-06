using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace Test
{
    public static class Helper
    {
        public static bool CompareLists(IList<IWordFrequency> FirstList, IList<IWordFrequency> SecondList)
        {
            if(FirstList.Count == SecondList.Count)
            {
                int length = FirstList.Count;
                for (int i = 0; i < length; i++)
                {
                    if ((FirstList[i].Word != SecondList[i].Word) || (FirstList[i].Frequency != SecondList[i].Frequency))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
