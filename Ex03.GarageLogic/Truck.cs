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
        //need to use consts where?
        public Truck(string i_LicenseNumber, string i_ModelName): base(i_LicenseNumber, i_ModelName)
        {
            VehicleType= eVehicleType.Truck;
            NumOfWheels = 14;
            MaxWheelsAirPressure = 27f;
            VehicleEngine = new FuelEngine(i_MaxEnergyOfEngine: 135f, i_TypeOfFuel: eFuelType.Soler);
            NumOfExtraInformation = 2;
            Wheels = CreateWheels(NumOfWheels, "DefaultManufacturer", 0f, MaxWheelsAirPressure);
        }

        private bool DangerousMaterial { get; set; } //Should be readonly??

        private float TankVolume { get; set; }

        public override string GetExtraInformation(int i_ExtraDetailNum) //TO DO
        {
            //write
            return "";
        }

        public override void SetExtraInformation(int i_ExtraDetailNum, string i_ExtraDetailValue) //TO DO
        {

        }

        public override string ExtraInformationToString() //TO DO
        {
            return string.Format(
                @"Contains Dangerous Material: {0}
                Tank volume: {1}",
                DangerousMaterial,
                TankVolume);
        }

    }
}
