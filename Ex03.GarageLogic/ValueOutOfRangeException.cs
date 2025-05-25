using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException: Exception
    {
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base (string.Format("Value out of range! {0} The valid values are {1} to {2}", Environment.NewLine
                , i_MinValue, i_MaxValue))
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }

        public float MinValue { get; }

        public float MaxValue { get; }
    }
}
