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
            Target = 911;
            CurrentValues = new [] { 100, 25, 10, 7, 5, 2 };
        }

        public int Target { get; private set; }


        public int[] CurrentValues
        {
            get { return _currentValues; }
            set { SetProperty(ref _currentValues, value); }
        }

        private int[] _currentValues;
    }
}
