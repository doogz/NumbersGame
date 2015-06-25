using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ScottLogic.NumbersGame.WebClient.ViewModels
{
    public class ViewModel : INotifyPropertyChanged // aka 'INPC'
    {
        /// <summary>
        /// The event called PropertyChanged of delegate type PropertyChangedEventHandler, demanded by INPC
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Helper method implemented to assist "property set" code; they should call this if they change a value.
        /// Doing so forces the WPF to check its bindings, including command enable/disable (raising CanExecuteChanged event).
        /// </summary>
        /// <param name="name"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if (PropertyChanged!=null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        protected void SetProperty<T>( T t, [CallerMemberName] string name = null)
        { }

    }
}
