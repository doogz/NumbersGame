using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Diagnostics;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using ScottLogic.NumbersGame;
using ScottLogic.NumbersGame.Game;

namespace MvvmWebApiClient.ViewModels
{
    public class NumbersGameViewModel : BindableBase
    {
        private DelegateCommand _additionCommandImplementation;
        private DelegateCommand _subtractionCommandImplementation;
        private DelegateCommand _multiplicationCommandImplementation;
        private DelegateCommand _divisionCommandImplementation;
        private DelegateCommand _undoCommandImplementation;
        private readonly List<DelegateCommand> _commands=new List<DelegateCommand>(); 

        public NumbersGameViewModel()
        {
            CurrentGamePlayer = new NumbersGamePlayer();
            
            _additionCommandImplementation = new DelegateCommand(DoAddition, CanDoAddition);
            _subtractionCommandImplementation = new DelegateCommand(DoSubtraction, CanDoSubtraction);
            _multiplicationCommandImplementation = new DelegateCommand(DoMultiplication, CanDoMultiplication);
            _divisionCommandImplementation = new DelegateCommand(DoDivision, CanDoDivision);
            _undoCommandImplementation = new DelegateCommand(UndoLastOperation, CanUndo);

            _commands.Add(_additionCommandImplementation);
            _commands.Add(_subtractionCommandImplementation);
            _commands.Add(_multiplicationCommandImplementation);
            _commands.Add(_divisionCommandImplementation);
            _commands.Add(_undoCommandImplementation);
            

            AdditionCommand = _additionCommandImplementation;
            SubtractionCommand = _subtractionCommandImplementation;
            MultiplicationCommand = _multiplicationCommandImplementation;
            DivisionCommand = _divisionCommandImplementation;
            UndoCommand = _undoCommandImplementation;

            //SelectedNumbers = new List<int>(); // new ObservableCollection<int>());
            SelectedNumbers = new ObservableCollection<int>();
        }

        /// <summary>
        /// This constructor is specifically to support design-time data
        /// </summary>
        /// <param name="designMode"></param>
        public NumbersGameViewModel(bool designMode)
            : this()
        {
            CurrentGamePlayer = new NumbersGamePlayer(new[] {100, 25, 10, 7, 5, 2}, 715);
        }

        // Our commands (public properties)
        public ICommand AdditionCommand { get; private set; }
        public ICommand SubtractionCommand { get; private set; }
        public ICommand MultiplicationCommand { get; private set; }
        public ICommand DivisionCommand { get; private set; }
        public ICommand UndoCommand { get; private set; }

        // Properties
        public INumbersGamePlayer CurrentGamePlayer
        {
            get { return _gamePlayer; }
            set { SetProperty(ref _gamePlayer, value); }
        }
        public IList<int> SelectedNumbers
        {
            get { return _selectedNumbers; }
            set
            {
                SetProperty(ref _selectedNumbers, value);
                RedoCommands();
            }
        }

        public IEnumerable<IOperation> OperationHistory
        {
            get { return _gamePlayer.History; }
        }

        public bool UndoPossible
        {
            get { return OperationHistory.Any(); }
        }

        public bool MultiplePossibleUndos
        {
            get { return false; } // Too hard for now ;)
        }

        private void RedoCommands()
        {
            // Force all commands to re-evaluate CanExecute
            foreach (var c in _commands) 
                c.RaiseCanExecuteChanged();
        }

       


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
            Debug.WriteLine("Checking CanDoAddition...");
            return OperationPossible;
        }
        private bool CanDoSubtraction()
        {
            Debug.WriteLine("Checking CanDoSubtraction...");
            // We never care about the order of operands but we do care if they're the same - we aren't permitted to use zeros
            return (OperationPossible && Op1 != Op2);
        }

        private bool CanUndo()
        {
            Debug.WriteLine("Checking CanUndo (last operation)...");
            return UndoPossible;
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
        

        private INumbersGamePlayer _gamePlayer;
        private IList<int> _selectedNumbers;
        //private readonly ObservableCollection<int> _selectedNumbers = new ObservableCollection<int>(); 

        // Command implementations (all private)

        private void ApplyOperation(IOperation op)
        {

            _gamePlayer.DoOperation(op);
            OnPropertyChanged("CurrentGamePlayer");

            SelectedNumbers = new int[] { };
            OnPropertyChanged("SelectedNumbers");
        }

        private void DoAddition()
        {
            ApplyOperation(new Operation(Op1, Op2, Operator.Addition));
        }


        private void DoSubtraction()
        {
            ApplyOperation(new Operation(Op1, Op2, Operator.Subtraction));
        }

        private void DoMultiplication()
        {
            ApplyOperation(new Operation(Op1, Op2, Operator.Multiplication));
        }

        private void DoDivision()
        {
            ApplyOperation(new Operation(Op1, Op2, Operator.Division));
        }

        private void UndoLastOperation()
        {
            _gamePlayer.UndoOperation();
            OnPropertyChanged( () =>CurrentGamePlayer);
        }
        
        
    }
}
