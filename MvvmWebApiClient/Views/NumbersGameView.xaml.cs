using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Practices.Prism.Mvvm;
using MvvmWebApiClient.ViewModels;

namespace MvvmWebApiClient.Views
{
    /// <summary>
    /// Interaction logic for NumbersGameView.xaml
    /// </summary>
    public partial class NumbersGameView : UserControl, IView
    {
        public NumbersGameView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Maintains the ViewModel's collection of selected numbers by listening to this event.
        /// 
        /// Note: The SDK's INumbersGamePlayer has no concept of ordereding; Numbers.CurrentValues returns arrays with *no* fixed order.
        /// We should make this API definition explicit, using IEnumerable rather than IList.
        /// The ViewModel model will be able to support the undoing of operations through its NumbersGamePlayer, although if we try to restore
        /// the selection that corresponds with a past operation, selected from a list of past operations, we would not be able to
        /// distinguish one 'X' from another, without some additional work.
        /// Note that, by the time we get to the SDK's (optional) Game.NumbersGames implementation, it tries to optimise operations on List<int>, 
        /// and needs indices for its OperationDetail class, used during Undo. We'd need something similar to replicate "Undo-with-mimicked-selection"
        /// 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumbersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // We maintain the ViewModel's collection of selected numbers by listening to this event.
            var selItems = NumbersList.SelectedItems;
            var context = NumbersList.DataContext;
            var viewModel = context as NumbersGameViewModel;
            if (viewModel != null)
            {
                List<int> selectedInts = selItems.Cast<int>().ToList();
                viewModel.SelectedNumbers = selectedInts;
            }
        }
    }
}
