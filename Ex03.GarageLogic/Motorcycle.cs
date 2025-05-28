using Ex03.GarageLogic.Enums;
using System;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        protected int EngineVolume { get; set; }

        protected string LicenseType { get; set; }

        protected Motorcycle(string i_LicenseNumber, string i_ModelName) 
            : base (i_LicenseNumber, i_ModelName)
        {
            NumOfWheels = 2;
            MaxWheelsAirPressure = 31f;
            NumOfExtraInformation = 2;
        }

        public override string GetExtraInformation(int i_NumOfExtraInformation)
        {
            string infoDescription=string.Empty;

            switch (i_NumOfExtraInformation)
            {
                case (int)eMotorcycleDetails.LicenseType:
                {
                    infoDescription = "License Type (A, A1, B1 or BB)";
                    break;
                }

                case (int)eMotorcycleDetails.EngineVolume:
                {
                    infoDescription = "Engine volume (as an integer)";
                    break;
                }

                default:
                {
                    throw new ArgumentException("\nInvalid extra detail identifier given");
                }
            }

            return infoDescription;
        }

        public bool CheckValidLicenseType(string i_LicenseType)
        {
            return (i_LicenseType == "A" || i_LicenseType == "A2" || i_LicenseType == "AB" || i_LicenseType == "B2");
        }

        public override void SetExtraInformation(int i_NumOfExtraInformation, string i_ExtraInformationValue)
        {
            switch (i_NumOfExtraInformation)
            {
                case (int)eMotorcycleDetails.LicenseType:
                {
                    if (CheckValidLicenseType(i_ExtraInformationValue))
                    {
                        LicenseType = i_ExtraInformationValue;
                    }
                    else
                    {
                        throw new ArgumentException("\nInvalid license type given");
                    }

                    break;
                }

                case (int)eMotorcycleDetails.EngineVolume:
                {
                    if (int.TryParse(i_ExtraInformationValue, out int oEngineVolume) && (oEngineVolume >= 0))
                    {
                        EngineVolume = oEngineVolume;
                    }
                    else
                    {
                        throw new ArgumentException("\nInvalid engine volume given");
                    }

                    break;
                }

                default:
                {
                    throw new ArgumentException("\nInvalid extra detail identifier given");
                }
            }
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

