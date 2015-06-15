using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        /// <summary>
        /// Our commands - "New Game", and "Submit Solution"
        /// </summary>
        public ICommand NewGameCommand { get; private set; }
        public ICommand SubmitSolutionCommand { get; private set; }
        public NumbersGameViewModel NumbersGameViewModel { get; set; }

        private void OnNewGame()
        {

            
        }

        private void OnSubmitSolution()
        {
            
        }

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
    }
}
