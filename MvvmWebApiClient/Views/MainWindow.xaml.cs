using System.Windows;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism;

namespace MvvmWebApiClient.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumbersGameView_Loaded(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
