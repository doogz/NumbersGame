using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevReadyMvvm.Model
{
    public class SourceObject
    {
        public string ViewTitle { get; set; }
        private ChildObject _item = new ChildObject();

        public ChildObject Item
        {
            get { return _item; }
        }
    }

    public class ChildObject
    {
        string _name = string.Empty;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                }
            }
        }
    }
}
