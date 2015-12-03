using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OccurrenceGenerator
{
    internal class Program
    {
        #region Private Fields

        private const string rootUrl = "http://localhost:10572/api/occurrence";

        #endregion Private Fields

        #region Private Methods

        private static void Main(string[] args)
        {
            Simulate();

            Console.WriteLine("Generating occurrences....");
            Console.ReadLine();
        }

        private static async Task Simulate()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var currntValue = rnd.Next(0,100);
            while (true)
            {
                try
                {
                    if ((currntValue % 3) != 0)
                    {
                        currntValue = rnd.Next(0, 100);
                        continue;
                    }

                    var response =
                        await
                            client.PostAsync(new Uri(rootUrl), new StringContent(currntValue.ToString(), Encoding.UTF8, "application/json"));

                    Console.WriteLine($"Sent: {currntValue} and the response was {response.StatusCode}");

                    currntValue = rnd.Next(0, 100);
                }
                catch (Exception)
                {
                    currntValue = rnd.Next(0, 100);
                }
            }
        }

        #endregion Private Methods
    }
}