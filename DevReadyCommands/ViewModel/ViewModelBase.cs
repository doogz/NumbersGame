using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DevReadyCommands.ViewModel
{
    public class ViewModelBase
    {
        event PropertyChangedEventHandler PropertyChanged;

        protected virtual void InitializeViewModel()
        {}

        
        public abstract string ViewName { get; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
