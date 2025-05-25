using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        public readonly eFuelType r_FuelType;

        public FuelEngine(float i_MaxAmountOfFuel, eFuelType i_TypeOfFuel)
            : base(i_MaxAmountOfFuel, eEngineType.Fuel)
        {
            r_FuelType = i_TypeOfFuel;
        }

        public void AddFuel(eFuelType i_TypeOfFuel, float i_FuelToAdd)
        {
            if (r_FuelType != i_TypeOfFuel)
            {
                throw new ArgumentException("\nIncorrect fuel type!");
            }

            AddPower(i_FuelToAdd);
        }


    }
}
