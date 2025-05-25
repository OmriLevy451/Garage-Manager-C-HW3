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

        public readonly float r_MaxAmountOfChargeOrFuel; 

        public readonly eEngineType r_EngineType; 

        protected Engine(float i_MaxAmountOfChargeOrFuel, eEngineType i_EngineType)
        {
            r_EngineType = i_EngineType;
            r_MaxAmountOfChargeOrFuel = i_MaxAmountOfChargeOrFuel;
        }

        protected void AddPower(float i_AmountOfPowerToAdd)
        {
            float newAmountOfEnergy = RemainingEnergy + i_AmountOfPowerToAdd;

            if (newAmountOfEnergy > r_MaxAmountOfChargeOrFuel || newAmountOfEnergy < 0)
            {
                throw new ValueOutOfRangeException(0, r_MaxAmountOfChargeOrFuel);
            }

            RemainingEnergy += i_AmountOfPowerToAdd;

        }

    }
}
