using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle()
        {
            NumOfWheels = 2;
            MaxWheelsAirPressure = 31f;
            FuelType = eFuelType.Octane98;
            MaxFuelAmount = 6.4f;
            MaxChargeAmount = 2.6f;
            NumOfExtraInformation = 2;
        }

        private readonly int EngineVolume;

        private readonly string LicenseType;

        public override eVehicleType VehicleType
        {
            get
            {
                eVehicleType vehicleType;

                if (VehicleEngine.EngineType == eEngineType.Fuel)
                {
                    vehicleType = eVehicleType.FuelMotorcycle;
                }
                else
                {
                    vehicleType = eVehicleType.ElectricMotorcycle; ;
                }

                return vehicleType;
            }

            protected set { VehicleType = value; } //seems wrong!
        }

        public override string GetExtraInformation(int i_NumOfExtraInformation)
        {
            //write
            return "";
        }

        public bool CheckValidLicenseType(string i_LicenseType)
        {
            return (i_LicenseType == "A" || i_LicenseType == "A1" || i_LicenseType == "B1" || i_LicenseType == "BB");
        }

        public override void SetExtraInformation(int i_NumOfExtraInformation, string i_ExtraInformationValue)
        {
            //write
        }

        public override string ExtraInformationToString()
        {
            return string.Format(
                @"License type: {0}
                Engine volume: {1}",
                LicenseType,
                EngineVolume);
        }
    }

}

