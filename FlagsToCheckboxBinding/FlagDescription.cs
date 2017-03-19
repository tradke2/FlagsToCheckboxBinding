using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsToCheckboxBinding
{
    public class FlagDescription
    {
        private readonly int iValue;
        private readonly string iDescription;

        private FlagDescription(int value, string description)
        {
            iValue = value;
            iDescription = description;
        }

        public int Value
        {
            get { return iValue; }
        }

        public string Description
        {
            get { return iDescription; }
        }

        public static readonly FlagDescription FlagOne = new FlagDescription(1, "Flag one");
        public static readonly FlagDescription FlagTwo = new FlagDescription(2, "Flag two");
        public static readonly FlagDescription FlagThree = new FlagDescription(4, "Flag three");
        public static readonly FlagDescription FlagFour = new FlagDescription(8, "Flag four");
    }

}
