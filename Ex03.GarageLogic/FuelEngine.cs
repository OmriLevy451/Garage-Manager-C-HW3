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
        public readonly eFuelType FuelType;

        public FuelEngine(float i_MaxEnergyOfEngine, eFuelType i_TypeOfFuel)
            : base(i_MaxEnergyOfEngine)
        {
            FuelType = i_TypeOfFuel;
        }

        public void Refuel(eFuelType i_TypeOfFuel, float i_FuelToAdd)
        {
            if (FuelType != i_TypeOfFuel)
            {
                throw new ArgumentException("\nIncorrect fuel type!");
            }

            AddPower(i_FuelToAdd);
        }






    }
}
