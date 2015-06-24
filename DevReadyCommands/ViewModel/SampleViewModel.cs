using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevReadyCommands.ViewModel
{
    public class SampleViewModel : ViewModelBase
    {
        public SampleViewModel()
        {
            InitializeViewModel();
        }
        
        protected override void InitializeViewModel()
        {


        }
        public override string ViewName
        {
            get { return "Thinking in MVVM"; }
        }

        public string LabelCaption { get { return "This is my content"; } }
        public string Color1Caption { get { return "Colour One"} }
        public string Color2Caption { get { return "Colour Two"} }
        public DelegateCommand<>
    }
}
