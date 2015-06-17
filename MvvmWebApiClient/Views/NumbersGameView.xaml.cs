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

        private void NumbersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // We need to maintain the ViewModel's collection of selected numbers by listening to this event
            var selItems = NumbersList.SelectedItems;
            Debug.WriteLine("There are {0} selected items", selItems.Count);
            //TODO: Finish this. The view will need to talk directly to the viewmodel to set the property.
            
            // Also, although the solving algorithms and the SDK needn't care about individual instances of particular values,
            // the user would be very dissatisifed to click e.g. the fifth number along, of value 10, and witness e.g. the second number
            // along - also of value 10 - being 'selected' instead.

            // Q. Where to get the viewmodel from?
            var context = NumbersList.DataContext;
            var viewModel = context as NumbersGameViewModel;
            if (viewModel != null)
            {
                /* So far so good.
                 * Is there a nicer way to do this?:
                
                List<int> selectedInts = new List<int>();
                foreach (var i in selItems)
                {
                    selectedInts.Add((int)i);
                }
                
                 */
                
                // YES! Thank you resharper:
                List<int> selectedInts = selItems.Cast<int>().ToList();
                viewModel.SelectedNumbers = selectedInts;

                // Force CanExecute requeries
               // CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}
