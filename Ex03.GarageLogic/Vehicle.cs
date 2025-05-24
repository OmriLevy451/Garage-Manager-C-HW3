using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public string LicenseNumber { get; set; } //readonly
        public abstract eVehicleType VehicleType { get; protected set; } //readonly
        public string ModelName { get; set; } //readonly
        public float MaxFuelAmount { get; protected set; } //readonly
        public float MaxChargeAmount { get; protected set; } //readonly
        public float MaxWheelsAirPressure { get; protected set; } // NOT readonly - possible to change wheels?
        public int NumOfWheels { get; protected set; }
        public int NumOfExtraInformation { get; protected set; } //readonly

        public eFuelType FuelType { get; protected set; } //readonly - engines cant change their required fuel type

        public Engine VehicleEngine { get; set; } //readonly

        public List<Wheel> Wheels { get; set; }

        public abstract string GetExtraInformation(int i_ExtraDetailNum);

        public abstract void SetExtraInformation(int i_ExtraDetailNum, string i_ExtraDetailValue);

        public abstract string ExtraInformationToString();

        public override string ToString()
        {
            string vehicleInformation = string.Format(
                @"
                License number: {0}
                Model name: {1}
                {2}
                Wheels manufacturer: {3}
                Wheels air pressure: {4}
                {5}",
                LicenseNumber,
                ModelName,
                VehicleEngine.ToString(),
                Wheels[0].Manufacturer,
                Wheels[0].CurrentAirPressure,
                ExtraInformationToString());

            return vehicleInformation;
        }

    }
}
