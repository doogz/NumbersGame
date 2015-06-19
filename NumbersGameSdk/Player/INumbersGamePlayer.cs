using System.Collections.Generic;

namespace ScottLogic.NumbersGame.Game
{
    /// <summary>
    /// The INumbersGamePlayer interface defines an optional protocol for playing out a numbers gamePlayer, within the context of the NumbersGameSdk.
    /// Each gamePlayer is initialised with a fixed-length array of starting numbers, and a target, using the Initialise() method.
    /// The gamePlayer proceeds by applying discreet operations, using DoOperation(), until the gamePlayer is solved or exhausted. 
    /// Game playing strategies are provided with an "undo" capability (reversing the effect of the last operation), and
    /// a generational "spawning" capability.
    /// </summary>
    public interface INumbersGamePlayer
    {
        /// <summary>
        /// Initialise gamePlayer with a starting set of values and a target
        /// </summary>
        /// <param name="initialValues"></param>
        /// <param name="target"></param>
        void Initialise(int[] initialValues, int target);

        /// <summary>
        /// Applies a given operation to the current gamePlayer.
        /// If the operation is not valid, an InvalidOperationException is thrown.
        /// Operations can be checked for validity in advance - see the static Operation.IsValid() method
        /// </summary>
        void DoOperation(IOperation op);
        
        /// <summary>
        /// Undoes the last operation, restoring the gamePlayer state to what it was before the last DoOperation().
        /// If there are no prior operations (e.g. directly after Initialise() is called), an InvalidOperationException.
        /// The do/undo mechanism is provided to support gamePlayer playing strategies that try out operations in-place,
        /// and hence require a means of unwinding those changes.
        /// </summary>
        void UndoOperation();
        
        /// <summary>
        /// Creates a new gamePlayer instance from the current gamePlayer state and the given operation.
        /// This provides an alternative approach for gamePlayer playing strategies. Instead of attempting to modify and reverse-modify
        /// gamePlayer state, we do a deep copy of the current gamePlayer and then mutate that.
        /// If the operation is not valid, an InvalidOperationException is thrown.
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        INumbersGamePlayer CreateDescendent(IOperation op);

        List<INumbersGamePlayer> CreateAllDescendents();

        bool IsSolved { get; }

        IEnumerable<IOperation> History { get; }
        
        bool IsComplete { get; }

        bool IsExhausted { get; }

        int NumberCount { get; }

        int[] CurrentNumbers { get; }
        /// <summary>
        /// The target number to be generated.
        /// </summary>
        int Target { get; }


    }
}
