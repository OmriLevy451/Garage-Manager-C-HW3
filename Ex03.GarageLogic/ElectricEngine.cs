using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxAmountOfEnergy) : base(i_MaxAmountOfEnergy)
        {
        }
        public void Charge(float i_TotalChargeTimeInMinutes)
        {
            AddPower((float)(i_TotalChargeTimeInMinutes / 60));
        }
    }
}
