using GalaSoft.MvvmLight;
using LightWebClient.Model;

namespace LightWebClient.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="MainHeading" /> property's name.
        /// </summary>
        public const string MainHeadingPropertyName = "MainHeading";

        private string _mainHeading = string.Empty;
        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string MainHeading
        {
            get { return _mainHeading; }

            set
            {
                if (_mainHeading == value)
                {
                    return;
                }

                _mainHeading = value;
                RaisePropertyChanged(MainHeadingPropertyName);
            }
        }

        private string _strapLine = string.Empty;

        public string StrapLine
        {
            get { return _strapLine; }

            set
            {
                if (_strapLine == value)
                {
                    return;
                }

                _strapLine = value;
                RaisePropertyChanged(MainHeadingPropertyName);
            }
        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            MainHeading = "LightWebClient";
            StrapLine = "- An MVVM Light implementation of the NumbersGame Web Client -";
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    // Do nothing for nowWelcomeTitle = item.Title;
                });
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}