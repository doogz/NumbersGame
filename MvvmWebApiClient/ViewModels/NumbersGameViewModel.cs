using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using ScottLogic.NumbersGame;
using ScottLogic.NumbersGame.Game;

namespace MvvmWebApiClient.ViewModels
{
    public class NumbersGameViewModel : BindableBase
    {
        public NumbersGameViewModel()
        {
            CurrentGame = new NumbersGame();
            //CurrentGame = new NumbersGame(new[] { 100, 25, 10, 7, 5, 2 }, 715);

            AdditionCommand = new DelegateCommand(OnAddition, CanDoAddition);
            SubtractionCommand = new DelegateCommand(OnSubtraction, CanDoSubtraction);
            MultiplicationCommand = new DelegateCommand(OnMultiplication, CanDoMultiplication);
            DivisionCommand = new DelegateCommand(OnDivision, CanDoDivision);
            UndoCommand = new DelegateCommand(UndoLastOperation);

            OperationHistory = new List<IOperation>();
            SelectedNumbers = new List<int>();
        }

        /// <summary>
        /// This constructor is specifically to support design-time data
        /// </summary>
        /// <param name="designMode"></param>
        public NumbersGameViewModel(bool designMode)
            : this()
        {
            CurrentGame = new NumbersGame(new[] {100, 25, 10, 7, 5, 2}, 715);
        }

        // Our commands (public properties)
        public ICommand AdditionCommand { get; private set; }
        public ICommand SubtractionCommand { get; private set; }
        public ICommand MultiplicationCommand { get; private set; }
        public ICommand DivisionCommand { get; private set; }
        public ICommand UndoCommand { get; private set; }


        // Properties
        public INumbersGame CurrentGame
        {
            get { return _game; }
            set { SetProperty(ref _game, value); }
        }

        public bool MultiplePossibleUndos
        {
            get { return false; } // Too hard for now ;)
        }

        public bool UndoPossible
        {
            get { return OperationHistory.Count > 0; }
        }

        public IList<int> SelectedNumbers
        {
            get { return _selectedNumbers; }
            set
            {
                _selectedNumbers.Clear();
                foreach (var v in value)
                    _selectedNumbers.Add(v);

                // So far, this ISN'T enough for things to just work.


                // And this doesn't do it...
                OnPropertyChanged("SelectedNumbers");

                // This is surely wrong, BUT it does force the UI work as expected for now!
                // TODO: Go through a simple working Prism example, compare & fix as necessary
                (AdditionCommand as DelegateCommand).RaiseCanExecuteChanged();
                (SubtractionCommand as DelegateCommand).RaiseCanExecuteChanged();
                (MultiplicationCommand as DelegateCommand).RaiseCanExecuteChanged();
                (DivisionCommand as DelegateCommand).RaiseCanExecuteChanged();

            }

        }
        public IList<IOperation> OperationHistory { get; set; }

        // Internal helpers
        private int Op1 { get { return SelectedNumbers[0]; } }
        private int Op2 { get { return SelectedNumbers[1]; } }

        
        // Enabling/disabling commands
        public bool OperationPossible
        {
            get { return SelectedNumbers.Count() == 2; }
        }

        private bool CanDoAddition()
        {
            return OperationPossible;
        }
        private bool CanDoSubtraction()
        {
            // We never care about the order of operands but we do care if they're the same - we aren't permitted to use zeros
            return (OperationPossible && Op1 != Op2);
        }

        private bool CanDoMultiplication()
        {
            return OperationPossible;
            // We *could* also forbid multiplication by 1 as it doesn't do anything "useful". (It replaces a '1' and an 'x' with just an 'x')
            // However, if we were looking for solutions where ALL the numbers must get used up, then it would indeed be useful...
        }
        private bool CanDoDivision()
        {
            if (!OperationPossible) return false;
            int lhs = Math.Max(SelectedNumbers[0], SelectedNumbers[1]);
            int rhs = Math.Min(SelectedNumbers[0], SelectedNumbers[1]);

            // Similarly, we could forbid division by 1 for same reason.
            return (lhs % rhs) == 0;
        }
        

        private INumbersGame _game;
        private readonly ObservableCollection<int> _selectedNumbers = new ObservableCollection<int>(); 

        // Command implementations (all private)

        private void ApplyOperation(IOperation op)
        {
            _game.DoOperation(op);
            SelectedNumbers = new int[] { };

            // OnPropertyChanged("CurrentGame");
            
            // Prism BindableBase also provides this, it's type-safer
            OnPropertyChanged(() => CurrentGame);
        }

        private void OnAddition()
        {
            ApplyOperation(new Operation(Op1, Op2, Operator.Addition));
        }


        private void OnSubtraction()
        {
            ApplyOperation(new Operation(Op1, Op2, Operator.Subtraction));
        }

        private void OnMultiplication()
        {
            ApplyOperation(new Operation(Op1, Op2, Operator.Multiplication));
        }

        private void OnDivision()
        {
            ApplyOperation(new Operation(Op1, Op2, Operator.Division));
        }

        private void UndoLastOperation()
        {
            _game.UndoOperation();
            OnPropertyChanged( () =>CurrentGame);
        }
        
        
    }
}
