using ScottLogic.NumbersGame.Web;

namespace ScottLogic.NumbersGame.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NumbersGameService" in both code and config file together.
    public class NumbersGameService : INumbersGameService
    {
        public bool GetStandardGame(int numBigValues, out int[] initialValues, out int target)
        {
            return GameGenerator.GenerateCountdownGame(numBigValues, out initialValues, out target);
        }

        public bool GetAdvancedGame(int numBigValues, out int[] initialValues, out int target)
        {
            return GameGenerator.GenerateCountdownPlusGame(numBigValues, out initialValues, out target);
        }

    }
}


/*
 * Left over example of CompositeType - to be removed
 * 
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
*/

