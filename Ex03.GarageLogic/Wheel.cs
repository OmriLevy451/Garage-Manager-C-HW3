using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public readonly string Manufacturer; //readonly - Changed from property
        public float CurrentAirPressure { get; private set; }

        public readonly float MaxAirPressure; //readonly - Changed from property

        public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_RecommendedMaxAirPressure)
        {
            Manufacturer = i_Manufacturer;
            CurrentAirPressure = i_CurrentAirPressure;
            MaxAirPressure = i_RecommendedMaxAirPressure;
        }

        public void AddAir(float i_LitersOfAirToAdd)
        {
        }
    }
}
