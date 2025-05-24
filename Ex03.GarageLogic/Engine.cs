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

        public readonly float MaxAmountOfEnergy; //readonly - Changed from property

        public readonly eEngineType EngineType; //readonly - Changed from property

        protected Engine(float i_MaxAmountOfEnergy)
        {
            MaxAmountOfEnergy = i_MaxAmountOfEnergy;
        }

        protected void AddPower(float i_AmountOfPowerToAdd)
        {

        }

    }
}
