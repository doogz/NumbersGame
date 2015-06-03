using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottLogic.NumbersGame.Bags
{
    public class CountdownPlusNumberBags : INumberBags
    {
        private class CountdownPlusHiBag : NumberBag
        {
            public CountdownPlusHiBag() : base(new []{50,50,100,100,500}) {}
            public override string Description { get { return "High Numbers: 25, 50, 75, 100"; } }
        }

        private class CountdownPlusLoBag : NumberBag
        {
            /// <summary>
            /// Number range is extended from 1-10 to 1-20. The prime numbers are favoured two-to-one
            /// </summary>
            public CountdownPlusLoBag() : base(new[]{1,1,2,2,3,3,4,5,5,6,7,7,8,9,10,11,11,12,13,13,14,15,16,17,17,18,19,19,20}) {}
            public override string Description { get { return "High Numbers: 25, 50, 75, 100"; } }
        }


        private readonly INumberBag[] _bags = {new CountdownPlusHiBag(), new CountdownPlusLoBag()};

        public int Bags
        {
            get { return _bags.Length; }
        }

        public INumberBag Bag(int bag)
        {
            return _bags[bag];
        }

    }
}
