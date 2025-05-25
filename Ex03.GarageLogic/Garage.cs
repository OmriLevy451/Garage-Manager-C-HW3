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

        private readonly Dictionary<Vehicle, OwnerInfo> r_ClientInfo = new Dictionary<Vehicle, OwnerInfo>();
        public VehicleCreator Creator { get; } = new VehicleCreator();  //they changed vehicleCreator to be a non-abstract class
        public bool IsLicenseNumberInGarage(string i_LicenseNumber)
        { 
            return r_Vehicles.ContainsKey(i_LicenseNumber);
        }

        public void RefuelVehicle(string i_LicenseNumber, int i_FuelType, float i_AmountOfFuel)
        { 
            //write
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_NumberOfMinutesToCharge)
        {
           //write
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            //write
        }
        public void ChangeVehicleState(string i_LicenseNumber, int i_State)
        {
           //write
        }

        public void AddVehicle(Vehicle i_Vehicle, OwnerInfo i_ClientInfo)
        { 
            //write
        }

        public string VehicleInfoToString(string i_LicenseNumber)
        { 
            //write
           return "";
        }

        public string[] GetPossibleVehicleTypes()
        {
             return Enum.GetNames(typeof(eVehicleType));
        }

        public List<string> GetLicenseNumsByState(int i_State) 
        {
             List<string> licenseNumbersList = new List<string>();

            //write

            return licenseNumbersList;
        }

        public Vehicle GetVehicleByLicenseNum(string i_LicenseNumber) //change
        {
            if (!IsLicenseNumberInGarage(i_LicenseNumber))
            {
                 throw new ArgumentException("\nNo vehicle with this license number was found in the garage.");
            }

            return r_Vehicles[i_LicenseNumber];
        }

    }
}
