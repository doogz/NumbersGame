using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using MvvmWebApiClient.Services;
using ScottLogic.NumbersGame;
using ScottLogic.NumbersGame.Game;

namespace MvvmWebApiClient.ViewModels
{
    public class MainWindowViewModel
    {
        private INumbersGameWebService _webService;
        public MainWindowViewModel()
        {
            //NewGameCommand = new DelegateCommand<object>(OnNewGame);
            NewGameCommand = new DelegateCommand(OnNewGame);
            SubmitSolutionCommand = new DelegateCommand(OnSubmitSolution, CanSubmitSolution);
            NumbersGameViewModel = new NumbersGameViewModel();
            //TODO: Unity/MEF DI
            _webService = new NumbersGameWebService();
        }

        /// <summary>
        /// Our commands - "New Game", and "Submit Solution"
        /// </summary>
        public ICommand NewGameCommand { get; private set; }
        public ICommand SubmitSolutionCommand { get; private set; }
        public NumbersGameViewModel NumbersGameViewModel { get; private  set; }


        private async void OnNewGame()
        {
            Puzzle puzzle = await _webService.GetNextGameAsync();
            var game = new NumbersGamePlayer(puzzle.StartingValues, puzzle.TargetValue);
            NumbersGameViewModel.CurrentGamePlayer = game;
        }

        private void OnSubmitSolution()
        {
            var solution = new Solution(NumbersGameViewModel.CurrentGamePlayer.History);

        }

        private bool CanSubmitSolution()
        {
            // TODO: 
            // We might want to verify we've actually generated the target here.
            // If that's the case, then the point of submitting the solution would be to register the time taken for some sort of competition, perhaps.
            // We could also allow for "giving up", whereby the solution is rendered by the server, on request.
            // We might also decide to check our random games are suitably "hard", or get "harder", in a competition scenarion.
            // All just ideas for where we could take this.

            return true;
        }

        
    }
}
