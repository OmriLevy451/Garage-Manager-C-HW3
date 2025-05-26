using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Vehicle> r_Vehicles = new Dictionary<string, Vehicle>();
        private readonly Dictionary<Vehicle, OwnerInfo> r_OwnerInfo = new Dictionary<Vehicle, OwnerInfo>();

        public bool IsLicenseNumberInGarage(string i_LicenseNumber)
        { 
            return r_Vehicles.ContainsKey(i_LicenseNumber);
        }

        public void AddVehicle(Vehicle i_Vehicle, OwnerInfo i_OwnerInfo)
        {
            r_Vehicles.Add(i_Vehicle.LicenseNumber, i_Vehicle);
            r_OwnerInfo.Add(i_Vehicle, i_OwnerInfo);
        }

        public void RefuelVehicle(string i_LicenseNumber, int i_FuelType, float i_AmountOfFuel)
        {
            if (!r_Vehicles.TryGetValue(i_LicenseNumber, out Vehicle vehicle))
            {
                throw new ArgumentException("\nNo vehicle with this license number was found in the garage.");
            }

            if (!(vehicle.VehicleEngine is FuelEngine fuelEngine))
            {
                throw new ArgumentException("\nThis vehicle isn't fuel based.");
            }

            eFuelType requestedFuelType = (eFuelType)i_FuelType;

            fuelEngine.AddFuel(requestedFuelType, i_AmountOfFuel);
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_NumberOfMinutesToCharge)
        {
            if (!r_Vehicles.TryGetValue(i_LicenseNumber, out Vehicle vehicle))
            {
                throw new ArgumentException("\nNo vehicle with this license number was found in the garage.");
            }

            if (!(vehicle.VehicleEngine is ElectricEngine electricEngine))
            {
                throw new ArgumentException("\nThis vehicle isn't electric.");
            }

            electricEngine.Charge(i_NumberOfMinutesToCharge / 60f);
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            if (!r_Vehicles.TryGetValue(i_LicenseNumber, out Vehicle vehicle))
            {
                throw new ArgumentException("\nNo vehicle with this license number was found in the garage.");
            }

            foreach (Wheel wheel in vehicle.Wheels)
            {
                float airToAdd = wheel.r_MaxAirPressure - wheel.CurrentAirPressure;
                wheel.AddAir(airToAdd);
            }
        }

        public void ChangeVehicleState(string i_LicenseNumber, int i_State)
        {
            if (!r_Vehicles.TryGetValue(i_LicenseNumber, out Vehicle vehicle))
            {
                throw new ArgumentException("\nNo vehicle with this license number was found in the garage.");
            }

            r_OwnerInfo[vehicle].VehicleState = (eVehicleState)i_State;
        }

        public string VehicleInfoToString(string i_LicenseNumber)
        {
            if (!r_Vehicles.TryGetValue(i_LicenseNumber, out Vehicle vehicle))
            {
                throw new ArgumentException("\nNo vehicle with this license number was found in the garage.");
            }

            OwnerInfo currentOwnerInfo = r_OwnerInfo[vehicle];
            StringBuilder displayVehicleInformation = new StringBuilder();

            displayVehicleInformation.AppendLine("Vehicle Full Information:");
            displayVehicleInformation.AppendLine(string.Format("Owner Name: {0}", currentOwnerInfo.r_OwnerName));
            displayVehicleInformation.AppendLine(string.Format("Vehicle State: {0}", currentOwnerInfo.VehicleState));
            displayVehicleInformation.AppendLine(vehicle.ToString());

            return displayVehicleInformation.ToString();
        }

        public string[] GetPossibleVehicleTypes()
        {
             return Enum.GetNames(typeof(eVehicleType));
        }

        public List<string> GetLicenseNumbersByState(int i_State) 
        {
             List<string> licenseNumbersList = new List<string>();

            foreach (string licenseNumber in r_Vehicles.Keys)
            {
                Vehicle vehicle = r_Vehicles[licenseNumber];

                if ((int)r_OwnerInfo[vehicle].VehicleState == i_State || i_State == -1)
                {
                    licenseNumbersList.Add(licenseNumber);
                }
            }

            return licenseNumbersList;
        }

        public Vehicle GetVehicleByLicenseNum(string i_LicenseNumber)
        {
            if (!r_Vehicles.TryGetValue(i_LicenseNumber, out Vehicle vehicle))
            {
                throw new ArgumentException("\nNo vehicle with this license number was found in the garage.");
            }

            return vehicle;
        }

    }
}
