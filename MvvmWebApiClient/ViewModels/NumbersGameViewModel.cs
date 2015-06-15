using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace MvvmWebApiClient.ViewModels
{
    public class NumbersGameViewModel : BindableBase
    {
        public NumbersGameViewModel()
        {
            _target = 0;
            CurrentValues = new int[] {};
            AdditionCommand = new DelegateCommand<object>( OnAddition, 
                                                           CanDoAddition);

            SubtractionCommand = new DelegateCommand<object>( OnSubtraction, 
                                                              CanDoSubtraction);


        }
        public NumbersGameViewModel(bool designMode)
            :this()
        {
            Target = 715;
            CurrentValues = new[] { 100, 25, 10, 7, 5, 2 };
        }

        // Our commands
        public ICommand AdditionCommand { get; private set; }
        public ICommand SubtractionCommand { get; private set; }
        public ICommand MultiplicationCommand { get; private set; }
        public ICommand DivisionCommand { get; private set; }




        // Command implementations - in viewmodel?
        private void OnAddition(object ob)
        {
            
        }
        private void OnSubtraction(object ob)
        {

        }


        private bool CanDoAddition(object ob)
        {
            return true;
        }
        private bool CanDoSubtraction(object ob)
        {
            return false;
        }


        public int Target
        {
            get { return _target; }
            set { SetProperty(ref _target, value); }
        }

        public int[] CurrentValues
        {
            get { return _currentValues; }
            set { SetProperty(ref _currentValues, value); }
        }

        private int _target;
        private int[] _currentValues;
    }
}
