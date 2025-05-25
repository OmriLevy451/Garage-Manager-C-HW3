using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class OwnerInfo
    {
        public readonly string r_OwnerName;

        public readonly string r_OwnerPhoneNumber;

        public eVehicleState VehicleState { get; set; } = eVehicleState.InRepair;

        public OwnerInfo(string i_Name, string i_PhoneNumber)
        {
            r_OwnerName = i_Name;
            r_OwnerPhoneNumber = i_PhoneNumber;
        }
    }
}
