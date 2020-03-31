using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace ThirdPartyApi
{
    class Program
    {
        private const string ApiUrl = "https://sv443.net/jokeapi/v2/joke/Programming?type=single";

        static void Main(string[] args)
        {
            using (var httpClient = new HttpClient())
            {
                var responseFromApi = httpClient.GetAsync(ApiUrl).Result;
                if (responseFromApi.IsSuccessStatusCode)
                {
                    var responseAsString = responseFromApi.Content.ReadAsStringAsync();

                    var jokes = (JokesApi) JsonConvert.DeserializeObject(responseAsString.Result, typeof(JokesApi));

                    if (jokes != null)
                    {
                        Console.WriteLine(jokes.Joke);
                    }                        
                }
            }
        }
    }

    internal class JokesApi
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Joke { get; set; }
        public string Error { get; set; }
    }

}
