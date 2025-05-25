using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        public FuelCar(string i_LicenseNumber, string i_ModelName) : base(i_LicenseNumber, i_ModelName)
        {
            VehicleType = eVehicleType.FuelCar;
            VehicleEngine = new FuelEngine(i_MaxEnergyOfEngine: 45f, i_TypeOfFuel: eFuelType.Octane95);
        }
    }

}
