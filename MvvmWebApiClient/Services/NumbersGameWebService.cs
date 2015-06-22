using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MvvmWebApiClient.ViewModels;
using ScottLogic.NumbersGame;

namespace MvvmWebApiClient.Services
{
    class NumbersGameWebService : INumbersGameWebService
    {
        private int _nextGameId;

        public async Task<IPuzzle> GetNextGameAsync()
        {
            ++_nextGameId;
            _nextGameId %= 25;

            string uri = string.Format("api/games/{0}", _nextGameId);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:40477/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Puzzle puzzle =
                        await response.Content.ReadAsAsync<Puzzle>();
                    return puzzle;
                }
            }

            return new Puzzle(new int[] {}, 999);
        }
    }
}
