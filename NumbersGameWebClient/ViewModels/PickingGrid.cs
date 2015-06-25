using System.Collections.ObjectModel;

namespace ScottLogic.NumbersGame.WebClient.ViewModels
{
    /// <summary>
    /// Encapsulates the behaviour and state of a numbers game's "picking grid".
    /// The user uses the picking grid to determine their random numbers; they are arranged into rows,
    /// each of which comes from a "number bag" (see SDK) of a certain sort.
    /// 
    /// The exacting rules for the C4 Countdown game are embodied in the SDK too.
    /// A set of rules called CountdownPlus is under development too; 
    /// it's the same generic problem with a greater computational complexity, focused at taxing machine solutions rather than humans.
    /// 
    /// We therefore use a CountdownPickingGrid viewmodel, derived from this one.
    /// </summary>
    public class PickingGrid : ViewModel
    {
        /// <summary>
        /// Default constructor; sets up observable collection of grid cells
        /// </summary>
        public PickingGrid()
        {
            Cells = new ObservableCollection<PickingGridCell>();    
        }
        public ObservableCollection<PickingGridCell> Cells { get; private set; }

    }
}
