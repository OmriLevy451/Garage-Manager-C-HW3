using System;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        public ElectricMotorcycle(string i_LicenseNumber, string i_ModelName) : base(i_LicenseNumber, i_ModelName)
        {
            VehicleType = eVehicleType.FuelMotorcycle;
            VehicleEngine = new ElectricEngine(3.2f);
        }

    }
}
