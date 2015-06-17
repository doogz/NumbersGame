using System;
using System.Collections.Generic;
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
            AdditionCommand = new DelegateCommand<object>( OnAddition, 
                                                           CanDoAddition);

            SubtractionCommand = new DelegateCommand<object>( OnSubtraction, 
                                                              CanDoSubtraction);
            
            MultiplicationCommand = new DelegateCommand( OnMultiplication, 
                                                         CanDoMultiplication);
            
            DivisionCommand = new DelegateCommand( OnDivision, 
                                                   CanDoDivision);
            
            ////
            OperationHistory = new List<IOperation>();
            SelectedNumbers = new List<int>();


        }
        /// <summary>
        /// This constructor is specifically to support design-time data
        /// </summary>
        /// <param name="designMode"></param>
        public NumbersGameViewModel(bool designMode)
            :this()
        {
            CurrentGame = new NumbersGame(new[] { 100, 25, 10, 7, 5, 2 }, 715);
        }

        // Our commands (public properties)
        public ICommand AdditionCommand { get; private set; }
        public ICommand SubtractionCommand { get; private set; }
        public ICommand MultiplicationCommand { get; private set; }
        public ICommand DivisionCommand { get; private set; }

        // Properties
        public INumbersGame CurrentGame
        {
            get { return _game; }
            set { SetProperty( ref _game,value); }
        }

        public int Target
        {
            get { return CurrentGame.Target; }
        }

        public int[] CurrentValues
        {
            get { return CurrentGame.CurrentNumbers; }
        }

        public IList<int> SelectedNumbers { get; set; }
        public IList<IOperation> OperationHistory { get; set; }

        private INumbersGame _game;


        // Command implementations (all private)
        private void OnAddition(object ob)
        {
            IOperation op = new Operation(Op1, Op2, Operator.Addition);

        }
        private void OnSubtraction(object ob)
        {
            IOperation op = new Operation(Op1, Op2, Operator.Subtraction);

        }
        private void OnMultiplication()
        {
            IOperation op = new Operation(Op1, Op2, Operator.Subtraction);

        }
        private void OnDivision()
        {
            IOperation op = new Operation(Op1, Op2, Operator.Subtraction);


        }

        
        // Internal helpers
        private int Op1 { get { return SelectedNumbers[0]; } }
        private int Op2 { get { return SelectedNumbers[1]; } }

        private bool CanDoAddition(object ob)
        {
            bool canDo = SelectedNumbers.Count() == 2;
            Debug.WriteLine("CanDoAddition() - {0}", canDo);
            return canDo;
        }
        
        private bool CanDoSubtraction(object ob)
        {
            // We don't care about the order of selection; we do care if the numbers are the same though, we don't want to generate zeros
            return (SelectedNumbers.Count() == 2 &&
                    SelectedNumbers[0] != SelectedNumbers[1]);
        }

        private bool CanDoMultiplication()
        {
            return SelectedNumbers.Count() == 2;
            // We *could* also forbid multiplication by 1 as it doesn't do anything "useful". (It replaces a '1' and an 'x' with just an 'x')
            // However, if we were looking for solutions where ALL the numbers must get used up, then it would indeed be useful...
        }
        private bool CanDoDivision()
        {
            if (SelectedNumbers.Count() != 2) return false;

            int lhs = Math.Max(SelectedNumbers[0], SelectedNumbers[1]);
            int rhs = Math.Min(SelectedNumbers[0], SelectedNumbers[1]);
            
            // Similarly, we could forbid division by 1 for same reason.
            return (lhs%rhs) == 0;
        }
    
    }
}
