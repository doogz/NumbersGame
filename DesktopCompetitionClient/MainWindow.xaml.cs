using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using DesktopCompetitionClient.ViewModel;


namespace DesktopCompetitionClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int _nextGameId;
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
        private async void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            ++_nextGameId;
            string uri = string.Format("api/games/{0}", _nextGameId);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:40477/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    ScottLogic.NumbersGame.Game.Definition game = await response.Content.ReadAsAsync<ScottLogic.NumbersGame.Game.Definition>();
                    var sb = new StringBuilder();
                    sb.Append("{");
                    int count = game.StartingValues.Length;
                    for (int n = 0; n < count; ++n)
                    {
                        sb.Append(String.Format("{0}{1}",
                            game.StartingValues[n],
                            (n < count - 1) ? ", " : "}"));
                    }
                    NumbersLabel.Content = sb.ToString();

                }
            }
            
        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}