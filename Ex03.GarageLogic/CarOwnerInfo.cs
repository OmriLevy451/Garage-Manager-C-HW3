using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class CarOwnerInfo
    {
        public readonly string CarOwnerName; //readonly - Changed from property

        public readonly string CarOwnerPhoneNumber;//readonly - Changed from property

        public eVehicleState VehicleState { get; set; } = eVehicleState.InRepair;

        public CarOwnerInfo(string i_Name, string i_PhoneNumber)
        {
            CarOwnerName = i_Name;
            CarOwnerPhoneNumber = i_PhoneNumber;
        }
    }
}
