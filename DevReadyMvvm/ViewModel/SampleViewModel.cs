using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DevReadyMvvm.Model;

namespace DevReadyMvvm.ViewModel
{
    public class SampleViewModel : INotifyPropertyChanged
    {
        public SampleViewModel()
        {
            _model = new SourceObject();
        }

        public SampleViewModel(SourceObject model)
        {
            _model = model;
        }

       
        SourceObject _model = null; // Quite like the convention of leaving off 'private'

        // INotifyPropertyChanged:
        public event PropertyChangedEventHandler PropertyChanged;

        // That is the interface completed! Except, we also need to raise events; that's our responsibility
        // Here's a helper for property-set accessors to use to that end:
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null) 
            {
                PropertyChanged(this, 
                    new PropertyChangedEventArgs(propertyName) );
            }
        }

        public string ViewTitle { get { return "This is SampleViewModel"; } }

        public string Name
        {
            get { return _model.Item.Name; }
            set
            {
                
                //if (value == _model.Item.Name)
                //    return;
                _model.Item.Name = value;
                OnPropertyChanged(); // Will automatically supply 'Name' here  :-)

            }
        }

    }
}
