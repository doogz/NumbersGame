
namespace ScottLogic.NumbersGame.WebClient.ViewModels
{
    public class PickingGridCell : ViewModel
    {
        /// <summary>
        /// Default constructor for cell; no number tile at all.
        /// </summary>
        /// <param name="value"></param>
        public PickingGridCell()
        {
            _empty = true;
            _revealed = false;
            TileValue = 0;
        }

        /// <summary>
        /// Constructor for a typical cell; we end up with a hidden state tile (with a fixed value on it at this point)
        /// </summary>
        /// <param name="value"></param>
        public PickingGridCell(int value)
        {
            _empty = false;
            _revealed = false;
            TileValue = value;
        }


        /// <summary>
        /// IsEmpty - does the cell have a number tile in it or not?
        /// We make a cell empty once we use the number up
        /// </summary>
        private bool _empty;

        public bool IsEmpty
        {
            get { return _empty; }
            set
            {
                _empty = value;
                OnPropertyChanged();
            }
        }


        private bool _revealed;

        public bool IsRevealed
        {
            get { return _revealed; }
            set
            {
                _revealed = value;
                OnPropertyChanged();
            }
        }

        public int TileValue { get; private set; } // we'll only set tile value in ctor; thereafter - immutable
    }
}