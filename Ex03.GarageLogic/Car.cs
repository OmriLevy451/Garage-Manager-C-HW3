using System;
using Ex03.GarageLogic.Enums;
namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected eColor Color { get; set; }
        protected int NumberOfDoors { get; set; }

        protected Car(string i_LicenseNumber, string i_ModelName) : base(i_LicenseNumber, i_ModelName)
        {
            NumOfWheels = 4;
            MaxWheelsAirPressure = 32f;
            NumOfExtraInformation = 2;
            Wheels = CreateWheels(NumOfWheels, "DefaultManufacturer", 0f, MaxWheelsAirPressure);
        }

        public override string GetExtraInformation(int i_ExtraInfoNum)
        {
            string informationDescription;

            switch (i_ExtraInfoNum)
            {
                case (int)eCarDetails.Color:
                {
                    informationDescription = "Car color (Red, White, Black, Yellow)";
                    break;
                }

                case (int)eCarDetails.NumberOfDoors:
                {
                    informationDescription = "Number of doors (2,3,4 or 5)";
                    break;
                }

                default:
                {
                    throw new ArgumentException("\nInvalid extra detail identifier given");
                }
            }

            return informationDescription;
        }

        public override void SetExtraInformation(int i_ExtraInfoNum, string i_ExtraInfoValue)
        {
            switch (i_ExtraInfoNum)
            {
                case (int)eCarDetails.Color:
                {
                    if (tryParseToColor(i_ExtraInfoValue, out eColor oColorInput))
                    {
                        Color = oColorInput;
                    }
                    else
                    {
                        throw new ArgumentException("\nInvalid car color given");
                    }

                    break;
                }

                case (int)eCarDetails.NumberOfDoors:
                {
                    if (int.TryParse(i_ExtraInfoValue, out int oNumOfDoorsInput) && oNumOfDoorsInput >= 2 && oNumOfDoorsInput <= 5)
                    {
                        NumberOfDoors = oNumOfDoorsInput;
                    }
                    else
                    {
                        throw new ArgumentException("\nInvalid number of doors given");
                    }

                    break;
                }

                default:
                {
                    throw new ArgumentException("\nInvalid extra detail identifier given.");
                }
            }
        }

        public override string ExtraInformationToString()
        {
            return string.Format(
            @"Car's color: {0}
            Number of doors: {1}", Color, NumberOfDoors);
        }

        private bool tryParseToColor(string i_Value, out eColor o_OutputColor)
        {
            o_OutputColor = eColor.Red;
            bool isValidColor = true;

            switch (i_Value)
            {
                case "Red":
                {
                    o_OutputColor = eColor.Red;
                    break;
                }

                case "White":
                {
                    o_OutputColor = eColor.White;
                    break;
                }

                case "Black":
                {
                    o_OutputColor = eColor.Black;
                    break;
                }

                case "Yellow":
                {
                    o_OutputColor = eColor.Yellow;
                    break;
                }

                default:
                {
                    isValidColor = false;
                    break;
                }
            }

            return isValidColor;
        }
    }
}
