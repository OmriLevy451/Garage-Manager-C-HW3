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
        public Truck()
        {
            NumOfWheels = 14;
            MaxWheelsAirPressure = 26f;
            FuelType = eFuelType.Soler;
            MaxFuelAmount = 135f;
            MaxChargeAmount = 0f;
            NumOfExtraInformation = 2;
        }

        private bool DangerousMaterial { get; set; } //Should be readonly??

        private float TankVolume { get; set; }

        public override eVehicleType VehicleType
        {
            get
            {
                return eVehicleType.Truck;
            }

            protected set { VehicleType = value; }
        }

        public override string GetExtraInformation(int i_ExtraDetailNum)
        {
            //write
            return "";
        }

        public override void SetExtraInformation(int i_ExtraDetailNum, string i_ExtraDetailValue)
        {

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
