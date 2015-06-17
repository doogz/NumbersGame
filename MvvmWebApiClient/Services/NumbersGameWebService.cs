using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MvvmWebApiClient.ViewModels;
using ScottLogic.NumbersGame.Game;

namespace MvvmWebApiClient.Services
{
    class NumbersGameWebService : INumbersGameWebService
    {
        private int _nextGameId;

        public async Task<Definition> GetNextGameAsync()
        {
            ++_nextGameId;
            string uri = string.Format("api/games/{0}", _nextGameId);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:40477/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Definition gameDefinition =
                        await response.Content.ReadAsAsync<Definition>();
                    return gameDefinition;
                }
            }

            return new Definition();
        }
    }
}
