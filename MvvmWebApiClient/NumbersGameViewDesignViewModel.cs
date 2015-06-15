using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmWebApiClient.ViewModels;

namespace MvvmWebApiClient
{
    public class NumbersGameViewDesignViewModel
    {
        public NumbersGameViewDesignViewModel()
        {
            NumbersGameViewModel = new NumbersGameViewModel(true); // Selects design mode constructor
        }
        public NumbersGameViewModel NumbersGameViewModel { get; set; }

    }
}
