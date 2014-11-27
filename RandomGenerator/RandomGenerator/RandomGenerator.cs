using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RandomGenerator
{
    public class RandomOrg
    {
        RandomNetQueue NetRandom;
        Random LocalRandom = new Random();
        int MaxValue { get; set; }
        int MinValue { get; set; }

        public RandomOrg() : this(int.MinValue, int.MaxValue) { }
        public RandomOrg(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            NetRandom = new RandomNetQueue(minValue, maxValue);
        }

        public IEnumerable<int> GetNumbers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (!NetRandom.NetworkError && NetRandom.Count > 0)
                {
                    //Return NetRandom number and add 10000 for visualization
                    //yield return NetRandom.Next + 10000;
                    yield return NetRandom.Next;
                }
                else
                if (!NetRandom.NetworkError && NetRandom.Count == 0)
                {
                    //Request for load new numbers
                    NetRandom.GetNewNumbers();
                    //Return number from local Random
                    yield return LocalRandom.Next(MinValue, MaxValue);
                }
                else
                    yield return LocalRandom.Next(MinValue, MaxValue);
            }
            //TODO Uncomment if you need random numbers loading for future using 
            //if (!NetRandom.NetworkError) NetRandom.GetNewNumbers(N);
        }

    }
}
