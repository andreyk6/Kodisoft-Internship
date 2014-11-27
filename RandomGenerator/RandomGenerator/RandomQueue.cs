using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace RandomGenerator
{
    class RandomNetQueue
    {
        Queue<int> RandomNumbers = new Queue<int>();
        public bool NetworkError = false;
        private bool LoadingProcess = false;
        int MaxValue { get; set; }
        int MinValue { get; set; }



        public int Next
        {
            get
            {
                if (RandomNumbers.Count != 0)
                    return RandomNumbers.Dequeue();
                else return 0;
            }
        }

        public int Count
        {
            get
            {
                return RandomNumbers.Count();
            }
        }

        public RandomNetQueue() : this(int.MinValue, int.MaxValue) { }

        public RandomNetQueue(int min, int max)
        {
            MinValue = min;
            MaxValue = max;
        }

        public void GetNewNumbers(int count = 10)
        {
            //Protect from next DownloadRandomNumber call before last iteration finish
            if (LoadingProcess == false)
            {
                //Clear previous numbers
                RandomNumbers.Clear();
                //Get new numbers
                DownloadRandomNumbers(count);
            }

        }

        private async void DownloadRandomNumbers(int count)
        {
            //Protect from next DownloadRandomNumber call before this iteration finish
            LoadingProcess = true; 

            try
            {
                using (var w = new WebClient())
                {
                    //Get response
                    string response = await w.DownloadStringTaskAsync(FormatRequest(count));

                    //Remove last '\n'
                    response = response.Substring(0, response.Length - 2);
                    
                    //Parse numbers and add to Enquenu
                    foreach (string num in response.Split('\n')) RandomNumbers.Enqueue(int.Parse(num));
                }
            }
            catch (Exception e)
            {
                //If NetworkError = true - request will never sent 
                NetworkError = true;

                MessageBox.Show("Error occurred " + e.Message);
            }

            LoadingProcess = false;
        }

        private Uri FormatRequest(int count)
        {
            //Format URI request to Random.org
            return new Uri(string.Format("http://www.random.org//integers//?num={0}&min={1}&max={2}&col=1&base=10&format=plain&rnd=new",count , MinValue, MaxValue));
        }
    }
}
