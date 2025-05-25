using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxAmountOfCharge) : base(i_MaxAmountOfCharge, eEngineType.Electric)
        {
        }

        public void Charge(float i_TotalChargeTimeInHours)
        {
            AddPower(i_TotalChargeTimeInHours);
        }
    }
}
