using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor Color { get; set; }

        private int NumberOfDoors { get; set; }

        public Car()
        {
            NumOfWheels = 4;
            MaxWheelsAirPressure = 33f;
            FuelType = eFuelType.Octane95;
            MaxFuelAmount = 46f;
            MaxChargeAmount = 5.2f;
            NumOfExtraInformation = 2;
        }

        public override eVehicleType VehicleType
        {
            get
            {
                eVehicleType vehicleType;

                if (VehicleEngine.EngineType == eEngineType.Fuel)
                {
                    vehicleType = eVehicleType.ElectricCar;
                }
                else
                {
                    vehicleType = eVehicleType.FuelCar;
                }

                return vehicleType;
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
                @"Car's color: {0}
                Number of doors: {1}", Color, NumberOfDoors);
        }


    }
}
