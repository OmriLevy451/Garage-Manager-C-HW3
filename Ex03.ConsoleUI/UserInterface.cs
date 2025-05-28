using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ex03.ConsoleUI.Enums;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;

namespace Ex03.ConsoleUI
{
    internal class UserInterface
    {
        private readonly Garage r_LocalGarage = new Garage();
        internal void ManageGarage()
        {
            bool isExit=false;
           
            Console.WriteLine("Welcome To Our Garage!");
            while (!isExit)
            {
                ShowUserInterface();
                int userInput = GetUserInput();
                switch (userInput)
                {
                    case (int)eUserChoices.ReadFromVehiclesDb:
                    {
                        ReadFromVehiclesDb();
                        break;
                    }
                    case (int)eUserChoices.InsertVehicle:
                    {
                        insertVehicle();
                        break;
                    }
                    case (int)eUserChoices.DisplayLicenseNumbers:
                    {
                        DisplayLicenseNumbers();
                        break;
                    }
                    case (int)eUserChoices.ChangeVehicleState:
                    {
                        ChangeVehicleState();
                        break;
                    }
                    case (int)eUserChoices.InflateWheelsToMax:
                    {
                        InflateWheelsToMax();
                        break;
                    }
                    case (int)eUserChoices.RefuelVehicle:
                    {
                        RefuelVehicle();
                        break;
                    }
                    case (int)eUserChoices.ChargeVehicle:
                    {
                        ChargeVehicle();
                        break;
                    }
                    case (int)eUserChoices.DisplayVehicle:
                    {
                        DisplayVehicle();
                        break;
                    }
                    case (int)eUserChoices.Exit:
                    {
                        PrintToScreenOrganized("Goodbye!");
                      
                        isExit=true;
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
                Console.Clear();
            }
        }
        internal void ShowUserInterface()
        {
            Console.WriteLine(string.Format(
                @"The possible choices are:
1) Load vehicles from file: Vehicles.db.
2) Insert a vehicle.
3) Display a list of all licenses numbers currently avalible in the garage.
4) Change the vehicle's state.
5) Inflate tires to maximum.
6) Refuel vehicle (for fuel based vehicles).
7) Charge vehicle (for electric vehicles).
8) Display vehicle info.
9) Exit."));
        }

        internal int GetUserInput()
        {
            string inputMessage = "Please pick your desired option! Enter a number between 1 to 9.";
            int numberOfMinimumOption = 1;
            int numberOfMaximumOption = 9;
            int oUserInput = receiveValidIntInput(numberOfMinimumOption, numberOfMaximumOption, inputMessage);

            return oUserInput;
        }

        private int receiveValidIntInput(int i_MinimumNumber, int i_MaximumNumber, string i_InputMessage)
        {
            Console.WriteLine(i_InputMessage);
            return receiveValidIntInput(i_MinimumNumber, i_MaximumNumber);
        }

        private int receiveValidIntInput(int i_MinimumNumber, int i_MaximumNumber)
        {
            int oInputNumber = -1;
            bool isValidInputNumber = false;

            while (!isValidInputNumber)
            {
                string inputString = getNonEmptyInput();
                bool isInputANumber = int.TryParse(inputString, out oInputNumber);

                if (isInputANumber)
                {
                    bool isNumberInRange = (oInputNumber >= i_MinimumNumber) && (oInputNumber <= i_MaximumNumber);
                    isValidInputNumber = isNumberInRange;
                }
                if (!isValidInputNumber)
                {
                    Console.WriteLine("{0}Invalid input!{0}Please enter a number from {1} to {2}.",Environment.NewLine, i_MinimumNumber, i_MaximumNumber);
                }
            }
            return oInputNumber;
        }

        private string getNonEmptyInput()
        {
            string userInput = Console.ReadLine();

            while (userInput == string.Empty)
            {
                Console.WriteLine("{0}Invalid input!{0}Input can't be empty, please try again.", Environment.NewLine);
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        private void ReadFromVehiclesDb()
        {
            Console.Clear();
            string[] allVehicleDataInFile = File.ReadAllLines(@"..\..\..\Vehicles.db");

            foreach (string singleVehicleData in allVehicleDataInFile)
            {
                if (string.IsNullOrWhiteSpace(singleVehicleData) || singleVehicleData.StartsWith("*****") || singleVehicleData.StartsWith("THE"))
                {
                    break;
                }

                string[] VehicleDataInParts = singleVehicleData.Split(',');
                string vehicleType = VehicleDataInParts[0];
                string licensePlate = VehicleDataInParts[1];

                if (r_LocalGarage.IsLicenseNumberInGarage(licensePlate))
                {
                    Console.WriteLine("Vehicle of license place {1} already in the system.{0}Skipping input.{0}", Environment.NewLine, licensePlate);
                    continue;
                }

                string modelName = VehicleDataInParts[2];
                int energyPercentage = int.Parse(VehicleDataInParts[3]);
                string tireModel = VehicleDataInParts[4];
                int currentAirPressure = int.Parse(VehicleDataInParts[5]);
                string ownerName = VehicleDataInParts[6];
                string ownerPhone = VehicleDataInParts[7];

                Vehicle vehicle = VehicleCreator.CreateVehicle(vehicleType, licensePlate, modelName);

                // Determine if we have extra properties
                bool hasExtra1 = VehicleDataInParts.Length > 8;
                bool hasExtra2 = VehicleDataInParts.Length > 9;

                //Create Wheel.
                vehicle.Wheels = vehicle.CreateWheels(vehicle.NumOfWheels, tireModel, currentAirPressure, vehicle.MaxWheelsAirPressure);

                //set Extra Information
                if (hasExtra1) vehicle.SetExtraInformation(1, VehicleDataInParts[8]);
                if (hasExtra2) vehicle.SetExtraInformation(2, VehicleDataInParts[9]);

                // Create OwnerInfo
                OwnerInfo ownerInfo = new OwnerInfo(ownerName, ownerPhone);
                // Add to garage
                r_LocalGarage.AddVehicle(vehicle, ownerInfo);
            }
            //clears twice!
            PrintToScreenOrganized("Successfully read all vehicles from Vehicles.db!");
        }
        private void insertVehicle()
        {
            Console.Clear();
            Console.WriteLine("Hello!{0}Please enter the license number of the required vehicle: ", Environment.NewLine);
            string licenseNumber = getNonEmptyInput();

            if (r_LocalGarage.IsLicenseNumberInGarage(licenseNumber))
            {
                int changeStatus = 1;
                int cancelOption = 2;
                int inputNumber = receiveValidIntInput(changeStatus, cancelOption, string.Format(
                        @"Vehicle with license number '{0}' is of type {1}.
                        Please choose an option:
                        1) Change the state of this vehicle
                        2) Cancel", licenseNumber, r_LocalGarage.GetVehicleByLicenseNum(licenseNumber).LicenseNumber));

                if (inputNumber == changeStatus)
                {
                    r_LocalGarage.ChangeVehicleState(licenseNumber, (int)eVehicleState.InRepair);
                }
            }
            else
            {
                Console.Clear();
                int vehicleTypeNumber = GetTypeOfVehicleNumber();
                eVehicleType vehicleType = (eVehicleType)vehicleTypeNumber;
                
                Console.Clear();
                Console.WriteLine("{0}Please enter the model name of the vehicle model:", Environment.NewLine);
                string modelName = getNonEmptyInput();
                Vehicle newVehicle = VehicleCreator.CreateVehicle(vehicleType.ToString(), licenseNumber, modelName);

                Console.Clear();
                Console.WriteLine("{0}Please enter the wheels' manufacturer name:", Environment.NewLine);
                string wheelsManufacturer = getNonEmptyInput();

                Console.Clear();
                float currentAirPressure = receiveValidFloatInRange(0, newVehicle.MaxWheelsAirPressure,
                    "\nPlease enter the current air pressure of the wheels:");

                //Create wheels.
                newVehicle.Wheels=newVehicle.CreateWheels(newVehicle.NumOfWheels, wheelsManufacturer, (int)currentAirPressure, newVehicle.MaxWheelsAirPressure);
                //Fuel or Battery levels.
                Console.Clear();
                float currentEnergy = receiveValidFloatInRange(0, newVehicle.VehicleEngine.r_MaxAmountOfChargeOrFuel,
                    "\nPlease enter the current amount of fuel or charge:");
                newVehicle.VehicleEngine.RemainingEnergy = currentEnergy;

                if (newVehicle is Motorcycle motorcycle)
                {
                    Console.Clear();
                    Console.WriteLine("{0}Please enter the license type of the motorcycle (A, A2, AB, B2):",Environment.NewLine);
                    motorcycle.SetExtraInformation(1,getNonEmptyInput());
                    Console.Clear();
                    Console.WriteLine("Please enter the engine volume (int):");
                    motorcycle.SetExtraInformation(2,getNonEmptyInput());
                }
                else if (newVehicle is Car car)
                {
                    Console.Clear();
                    Console.WriteLine("{0}Please enter the car color (Silver, White, Black, Yellow):", Environment.NewLine);
                    car.SetExtraInformation(1,getNonEmptyInput());

                    Console.Clear();
                    Console.WriteLine("Please enter the number of doors:");
                    car.SetExtraInformation(2,getNonEmptyInput());
                }
                else if (newVehicle is Truck truck)
                {
                    Console.Clear();
                    Console.WriteLine("{0}Does the truck carry dangerous materials? (true/false):", Environment.NewLine);
                    truck.SetExtraInformation(1, getNonEmptyInput());

                    Console.Clear();
                    Console.WriteLine("Please enter the truck's tank volume (float):");
                    truck.SetExtraInformation(2,getNonEmptyInput());
                }

                Console.Clear();
                Console.WriteLine("{0}Please enter your name:", Environment.NewLine);
                string ownerName = getNonEmptyInput();

                Console.Clear();
                Console.WriteLine("{0}Please enter your phone number:", Environment.NewLine);
                string ownerPhone = getOnlyDigitsString();

                OwnerInfo ownerInfo = new OwnerInfo(ownerName, ownerPhone);
               

                r_LocalGarage.AddVehicle(newVehicle, ownerInfo);
            }
        }

        private int GetTypeOfVehicleNumber()
        {
            Console.WriteLine("{0}Please select the type of vehicle you would like to insert:",Environment.NewLine);

            
            foreach (int value in Enum.GetValues(typeof(eVehicleType)))
            {
                string name = Enum.GetName(typeof(eVehicleType), value);
                Console.WriteLine($"{value}) {name}");
            }

            int minOption = (int)Enum.GetValues(typeof(eVehicleType)).Cast<eVehicleType>().Min();
            int maxOption = (int)Enum.GetValues(typeof(eVehicleType)).Cast<eVehicleType>().Max();

           
            int vehicleTypeChoice = receiveValidIntInput(minOption, maxOption,
                $"\nPlease enter your choice (a number between {minOption} and {maxOption}):");

            return vehicleTypeChoice;
        }


        private float receiveValidFloatInRange(float i_MinNumber, float i_MaxNumber, string i_Message)
        {
            float o_InputNumber = -1;
            bool isValidInputNumber = false;
            bool isANumber;

            Console.WriteLine(i_Message);

            while (!isValidInputNumber)
            {
                string inputString = getNonEmptyInput();

                isANumber = float.TryParse(inputString, out o_InputNumber);

                if (isANumber)
                {
                    bool isNumberInRange = o_InputNumber >= i_MinNumber && o_InputNumber <= i_MaxNumber;
                    isValidInputNumber = isNumberInRange;
                }

                if (!isValidInputNumber)
                {
                    Console.WriteLine(string.Format("\nInvalid input\nPlease enter a number from {0} to {1}: ", i_MinNumber, i_MaxNumber));
                }
            }

            return o_InputNumber;
        }

        private string getOnlyDigitsString()
        {
            string userInput = getNonEmptyInput();

            while (!checkIfOnlyDigitsString(userInput))
            {
                
                Console.WriteLine("{0}Invalid input!{0}The input should only contain digits, please try again: ", Environment.NewLine);
                userInput = getNonEmptyInput();
            }

            return userInput;
        }

        private bool checkIfOnlyDigitsString(string i_UserInput)
        {
            foreach (char character in i_UserInput)
            {
                if (!char.IsDigit(character))
                {
                    return false;
                }
            }
            return true;
        }

        private void DisplayLicenseNumbers()
        {
            
            int maxPossibleInputValue = 4;
            int minPossibleInputValue = 1;
            string messageToPrint =
                @"Would you like to filter this information by car's state:
                1) Currenly in repair.
                2) Fixed. Awaiting payment.
                3) Paid.
                4) No filter. (View All)

                Please choose an option (1 to 4):";
            Console.Clear();
            int filterNumber = receiveValidIntInput(minPossibleInputValue, maxPossibleInputValue, messageToPrint);
            List<string> licenseNumbers;

            if (filterNumber >= maxPossibleInputValue)
            {
                licenseNumbers = r_LocalGarage.GetLicenseNumbersByState(-1);
            }
            else
            {
                licenseNumbers = r_LocalGarage.GetLicenseNumbersByState(filterNumber);
            }

            string licenseNumbersAsString = LicenseNumberToString(licenseNumbers);


            PrintToScreenOrganized(licenseNumbersAsString);
        }

        private string LicenseNumberToString(List<string> io_LicenseNumbers)
        {
            StringBuilder licenseNumbersToPrint = new StringBuilder();

            licenseNumbersToPrint.AppendLine("The current license numbers in the garage: ");

            if (io_LicenseNumbers.Count != 0)
            {
                foreach (string licenseNumber in io_LicenseNumbers)
                {
                    licenseNumbersToPrint.AppendLine(licenseNumber);
                }
            }
            else
            {
                licenseNumbersToPrint.Append("The Garage is empty! There are no license numbers to display currently.");
            }

            return licenseNumbersToPrint.ToString();
        }

        private void ChangeVehicleState()
        {
            Console.Clear();
            string licenseNumber = GetLicenseNumberInGarage();
            bool UserWantToExit;

            if (licenseNumber == string.Empty)
            {
                UserWantToExit = true;
            }
            else
            {
                UserWantToExit = false;
            }

            if (!UserWantToExit)
            {
                int maxInputValue = 3;
                int minInputValue = 1;
                string messageToPrint =
@"Choose the new state of the vehicle:
1) The vehicle is being repaired.
2) The vehicle repair is done. Awaiting payment.
3) Paid.

Please choose an option (1 to 3): ";
                Console.Clear();
                int userVehicleState = receiveValidIntInput(minInputValue, maxInputValue, messageToPrint);
                PrintToScreenOrganized("Changing the Vehicle's state...");
                
                r_LocalGarage.ChangeVehicleState(licenseNumber, userVehicleState);
            }
        }

        private string GetLicenseNumberInGarage()
        {
            Console.WriteLine("{0}Please enter the vehicle's license number: ",Environment.NewLine);

            string licenseNumber = getNonEmptyInput();
            bool isUserNotDone = true;
            bool isLicenseNumberInGarage = r_LocalGarage.IsLicenseNumberInGarage(licenseNumber);

            while (isUserNotDone && (!isLicenseNumberInGarage))
            {
                Console.WriteLine("{0}This vehicle is not in the garage currently",Environment.NewLine);

                isUserNotDone = isUserWantToCancel();

                if (isUserNotDone == false)
                {
                    licenseNumber = string.Empty;
                    break;
                }

                Console.WriteLine("Try again: ");
                licenseNumber = getNonEmptyInput();
                isLicenseNumberInGarage = r_LocalGarage.IsLicenseNumberInGarage(licenseNumber);
            }

            return licenseNumber;
        }


        private bool isUserWantToCancel()
        {
            bool isUserNotDone;
            int maxInputValue = 2;
            int minInputvalue = 1;

            string messageToPrint =
                @"Would you like to try again or go back to the main menu:
                1) Try again
                2) Go back";

            int userInputNumber = receiveValidIntInput(minInputvalue, maxInputValue, messageToPrint);

            if (userInputNumber == minInputvalue)
            {
                isUserNotDone = true;
            }
            else
            {
                isUserNotDone = false;
            }

            return isUserNotDone;
        }

        private void InflateWheelsToMax()
        {
            Console.Clear();
            string licenseNumber = GetLicenseNumberInGarage();
            bool isUserFinished=false;

            if (licenseNumber == string.Empty)
            {
                isUserFinished = true;
            }
            else
            {
                isUserFinished = false;
            }

            if (!isUserFinished)
            {
                PrintToScreenOrganized("Inflating Wheels to maximum air pressure.");
                r_LocalGarage.InflateWheelsToMax(licenseNumber);
            }
        }

        private void RefuelVehicle()
        {
            Console.Clear();
            string licenseNumber = GetLicenseNumberInGarage();
            int maxInputValue = 4;
            int minInputvalue = 1;
            bool userWantToQuit=false;
            Vehicle vehicle=r_LocalGarage.GetVehicleByLicenseNum(licenseNumber);

            if (vehicle.VehicleEngine.r_EngineType!=eEngineType.Fuel)
            {
                PrintToScreenOrganized(string.Format("Car is electric! Cannot be fueled!{0}Returning to main screen.", Environment.NewLine));
          
                userWantToQuit = true;
            }

            if (licenseNumber == string.Empty)
            {
                userWantToQuit = true;
            }

            if (!userWantToQuit)
            {
                string messageToPrint =
                    @"Please choose fuel type:
                    1) Soler
                    2) Octan 95
                    3) Octan 96
                    4) Octan 98

                    Please choose an option: ";

                try
                {
                    int fuelType = receiveValidIntInput(minInputvalue, maxInputValue, messageToPrint);

                    Console.WriteLine(@"How many liters of fuel would you want to add? ");

                    float amountOfFuel = GetValidFloatNumber();
                    PrintToScreenOrganized(string.Format("Fueling car with {0} liters...", amountOfFuel));
                  
                    r_LocalGarage.RefuelVehicle(licenseNumber, fuelType, amountOfFuel);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                    userWantToQuit = true;
                }
                catch (ValueOutOfRangeException valueOutOfRange)
                {
                    Console.WriteLine(valueOutOfRange.Message);
                    RefuelVehicle();
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    RefuelVehicle();
                }
            }
        }

        private float GetValidFloatNumber()
        {
            float oInputNumber=-1;
            bool isANumber=false;

            do
            {
                string input = getNonEmptyInput();

                isANumber = float.TryParse(input, out oInputNumber);
                if (!isANumber)
                {
                    Console.WriteLine("{0}Invalid input, please try again: ", Environment.NewLine);
                }
            }

            while (!isANumber);

            return oInputNumber;
        }


        private void ChargeVehicle()
        {
            Console.Clear();
            string licenseNumber = GetLicenseNumberInGarage();
            bool userWantToQuit=false;
            Vehicle vehicle = r_LocalGarage.GetVehicleByLicenseNum(licenseNumber);

            if (vehicle.VehicleEngine.r_EngineType != eEngineType.Electric)
            {
                PrintToScreenOrganized(string.Format("Car is Fuel based! Cannot be charged!{0}Returning to main screen.", Environment.NewLine));
               
                userWantToQuit=true;
            }


            if (licenseNumber == string.Empty)
            {
                userWantToQuit = true;
            }

            if (!userWantToQuit)
            {
                Console.WriteLine(@"For how long (in minutes) would you like to charge your car's battery? ");

                try
                {
                    float amountOfMinutesToCharge = GetValidFloatNumber();

                    PrintToScreenOrganized(string.Format("Charging car for {0} minutes...", amountOfMinutesToCharge));

                    r_LocalGarage.ChargeVehicle(licenseNumber, amountOfMinutesToCharge);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                    userWantToQuit = true;
                }
                catch (ValueOutOfRangeException valueOutOfRange)
                {
                    Console.WriteLine(valueOutOfRange.Message);
                    ChargeVehicle();
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    ChargeVehicle();
                }
            }
        }

        private void DisplayVehicle()
        {
            Console.Clear();
            string licenseNumber = GetLicenseNumberInGarage();
            bool isUserFinished=false;

            if (licenseNumber == string.Empty)
            {
                isUserFinished = true;
            }
            else
            {
                isUserFinished = false;
            }

            if (!isUserFinished)
            {
                PrintToScreenOrganized(r_LocalGarage.VehicleInfoToString(licenseNumber));
            }
        }

        private void PressEnterToContinue()
        {
            Console.WriteLine("{0}Press 'Enter' to continue",Environment.NewLine);
            Console.ReadLine();
            Console.Clear();
        }

        private void PrintToScreenOrganized(string i_MessageToPrint)
        {
            Console.Clear();
            Console.WriteLine(i_MessageToPrint);
            PressEnterToContinue();
        }

    }
}