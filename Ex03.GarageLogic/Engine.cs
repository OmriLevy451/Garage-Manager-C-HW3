using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public float RemainingEnergy { get; set; }

        public readonly float r_MaxAmountOfEnergy; //readonly - Changed from property

        public readonly eEngineType r_EngineType; //readonly - Changed from property

        protected Engine(float i_MaxAmountOfEnergy)
        {
            r_MaxAmountOfEnergy = i_MaxAmountOfEnergy;
        }

        protected void AddPower(float i_AmountOfPowerToAdd)
        {

        }

    }
}
