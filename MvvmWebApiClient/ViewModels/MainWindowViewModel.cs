using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace MvvmWebApiClient.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            //NewGameCommand = new DelegateCommand<object>(OnNewGame);
            NewGameCommand = new DelegateCommand(OnNewGame);
            SubmitSolutionCommand = new DelegateCommand(OnSubmitSolution);
            NumbersGameViewModel = new NumbersGameViewModel();
        }

        /// <summary>
        /// Our commands - "New Game", and "Submit Solution"
        /// </summary>
        public ICommand NewGameCommand { get; private set; }
        public ICommand SubmitSolutionCommand { get; private set; }
        public NumbersGameViewModel NumbersGameViewModel { get; set; }

        private static int _nextGameId;

        private async void OnNewGame()
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
                    ScottLogic.NumbersGame.Game.Definition gameDefinition =
                        await response.Content.ReadAsAsync<ScottLogic.NumbersGame.Game.Definition>();

                    var game=new ScottLogic.NumbersGame.Game.NumbersGame(gameDefinition.StartingValues,
                        gameDefinition.Target);

                    NumbersGameViewModel.CurrentGame = game;
                }

            }
        }

        private void OnSubmitSolution()
        {
            
        }
        /*
        private int _target = 911;
        private int[] _currentValues = new int[] { 100, 25, 10, 7, 5, 2 };

        public int Target
        {
            get { return _target; }
            private set { _target = value; }
        }
        

        public int[] CurrentValues
        {
            get { return _currentValues; }
            private set { _currentValues = value; }
        }
         * */
    }
}
