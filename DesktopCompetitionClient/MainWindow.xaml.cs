using System.Windows;
using DesktopCompetitionClient.ViewModel;

namespace DesktopCompetitionClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }


        /// <summary>
        /// Yes, this is using traditional .net events at the moment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}