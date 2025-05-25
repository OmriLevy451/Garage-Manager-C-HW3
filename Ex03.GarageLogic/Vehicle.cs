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
        public string LicenseNumber { get; protected set; }
        public string ModelName { get; protected set; }

        protected Vehicle(string i_LicenseNumber, string i_ModelName)
        {
            LicenseNumber = i_LicenseNumber;
            ModelName = i_ModelName;
        }

        public eVehicleType VehicleType { get; protected set; } //readonly (no longer abstract)
        public float MaxWheelsAirPressure { get; protected set; } // NOT readonly - possible to change wheels?
        public int NumOfWheels { get; protected set; }
        public int NumOfExtraInformation { get; protected set; } //readonly

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

        public List<Wheel> CreateWheels(int i_NumOfWheels, string i_Manufacturer, float i_CurrentAirPressure, float i_RecommendedMaxAirPressure)
        {
            List<Wheel> wheelsList = new List<Wheel>();

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                wheelsList.Add(new Wheel(i_Manufacturer, i_CurrentAirPressure, i_RecommendedMaxAirPressure));
            }

            return wheelsList;
        }
    }
}
