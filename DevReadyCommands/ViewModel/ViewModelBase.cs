using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace DevReadyCommands.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        bool _isDirty = false;

        public virtual bool IsDirty
        {
            get
            {
                return _isDirty;
            }
            set
            {
                if ( value != _isDirty )
                {
                    _isDirty = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void InitializeViewModel()
        {}

        
        public abstract string ViewName { get; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName=null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



    }
}
