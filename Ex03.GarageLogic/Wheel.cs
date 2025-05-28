using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public readonly string r_Manufacturer; 

        public float CurrentAirPressure { get; private set; }

        public readonly float r_MaxAirPressure;

        public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_RecommendedMaxAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_RecommendedMaxAirPressure;
        }
        public void AddAir(float i_AmountOfAirToAdd)
        {
            float newAirPressure = CurrentAirPressure + i_AmountOfAirToAdd;

            if (newAirPressure > r_MaxAirPressure || newAirPressure < 0)
            {
                throw new ValueOutOfRangeException(0, r_MaxAirPressure);
            }

            CurrentAirPressure += i_AmountOfAirToAdd;
        }
    }
}
