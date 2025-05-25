using Ex03.GarageLogic.Enums;
using System;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        protected int EngineVolume { get; set; }

        protected string LicenseType { get; set; }

        protected Motorcycle(string i_LicenseNumber, string i_ModelName): base (i_LicenseNumber, i_ModelName)
        {
            NumOfWheels = 2;
            MaxWheelsAirPressure = 31f;
            NumOfExtraInformation = 2;
            Wheels = CreateWheels(NumOfWheels, "DefaultManufacturer", 0f, MaxWheelsAirPressure);
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

