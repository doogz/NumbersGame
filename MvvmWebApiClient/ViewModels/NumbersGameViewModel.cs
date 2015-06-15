using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;

namespace MvvmWebApiClient.ViewModels
{
    public class NumbersGameViewModel : BindableBase
    {
        public NumbersGameViewModel()
        {
            _target = 0;
            CurrentValues = new int[] {};
        }
        public NumbersGameViewModel(bool designMode)
        {
            Target = 715;
            CurrentValues = new[] { 100, 25, 10, 7, 5, 2 };
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
