using System;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        public FuelMotorcycle(string i_LicenseNumber, string i_ModelName) : base(i_LicenseNumber, i_ModelName)
        {
            VehicleType = eVehicleType.FuelMotorcycle;
            VehicleEngine = new FuelEngine(i_MaxAmountOfFuel: 5.8f, i_TypeOfFuel: eFuelType.Octane98);
        }

    }
}
