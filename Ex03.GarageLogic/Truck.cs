using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        public Truck(string i_LicenseNumber, string i_ModelName):
            base(i_LicenseNumber, i_ModelName)
        {
            VehicleType= eVehicleType.Truck;
            NumOfWheels = 12;
            MaxWheelsAirPressure = 27f;
            VehicleEngine = new FuelEngine(i_MaxAmountOfFuel: 135f, i_TypeOfFuel: eFuelType.Soler);
            NumOfExtraInformation = 2;
        }

        private bool DangerousMaterial { get; set; }

        private float TankVolume { get; set; }

        public override string GetExtraInformation(int i_ExtraInfoNum) 
        {
            string infoDescription=string.Empty;

            switch (i_ExtraInfoNum)
            {
                case (int)eTruckDetails.DangerousMaterial:
                {
                    infoDescription = "Contains dangerous material (True/False)";
                    break;
                }

                case (int)eTruckDetails.TankVolume:
                {
                    infoDescription = "Tank volume (as a float)";
                    break;
                }

                default:
                {
                    throw new ArgumentException("\nInvalid extra detail identifier given");
                }
            }

            return infoDescription;
        }

        public override void SetExtraInformation(int i_ExtraInfoNum, string i_ExtraInfolValue) 
        {
            switch (i_ExtraInfoNum)
            {
                case (int)eTruckDetails.DangerousMaterial:
                    {
                        if (bool.TryParse(i_ExtraInfolValue, out bool oDangerousMaterial))
                        {
                            DangerousMaterial = oDangerousMaterial;
                        }
                        else
                        {
                            throw new ArgumentException("\nInvalid dangerous material value given");
                        }

                        break;
                    }

                case (int)eTruckDetails.TankVolume:
                    {
                        if (float.TryParse(i_ExtraInfolValue, out float oTankVolume) && (oTankVolume > 0))
                        {
                            TankVolume = oTankVolume;
                        }
                        else
                        {
                            throw new ArgumentException("\nInvalid tank volume given");
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
@"Contains Dangerous Material: {0}
Tank volume: {1}",
                DangerousMaterial,
                TankVolume);
        }
    }
}
