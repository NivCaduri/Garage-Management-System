using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        public string OwnerName { get; set; }
        public string TelephoneNumber { get; set; }
        public eVehicleStatus vehicleState { get; set; }
        public Vehicle theVehicle { get; set; }
        public static Dictionary<string, Vehicle> s_SupportedVehicles;

        public enum eVehicleStatus
        {
            NeedOfRepair,
            Repaired,
            Paid,
        }

        public VehicleInGarage(string i_OwnerName, string i_TelephoneNumber, string i_WhichVehicle, List<object> i_ConstracturParamaters)
        {
            OwnerName = i_OwnerName;
            if (int.TryParse(i_TelephoneNumber, out _))
            {
                TelephoneNumber = i_TelephoneNumber;
            }
            else
            {
                throw new ArgumentException("not a valid phone number");
            }
            vehicleState = eVehicleStatus.NeedOfRepair;
            theVehicle = CreateNewVehicle(i_WhichVehicle, i_ConstracturParamaters);
        }

        static VehicleInGarage()
        {
            s_SupportedVehicles = new Dictionary<string, Vehicle>()
            {
                {"Electric Car", new Car()},
                {"Gas Car",new Car()},
                {"Electric Motorcycle", new Motorcycle()},
                {"Gas Motorcycle", new Motorcycle()},
                {"Truck", new Truck()},
            };
        }

        public static Vehicle CreateNewVehicle(string i_WhichVehicle, List<object> i_ConstracturParamaters)
        {
            Vehicle o_NewVehicle = null;
            if (i_WhichVehicle == "Electric Motorcycle")
            {
                o_NewVehicle = ElectricMotorcycle.CreateVehicleFromUi(i_ConstracturParamaters);
            }
            else if (i_WhichVehicle == "Gas Motorcycle")
            {
                o_NewVehicle = GasMotorcycle.CreateVehicleFromUi(i_ConstracturParamaters);

            }
            else if (i_WhichVehicle == "Electric Car")
            {
                o_NewVehicle = ElectricCar.createVehicleFromUi(i_ConstracturParamaters);
            }
            else if (i_WhichVehicle == "Gas Car")
            {
                o_NewVehicle = GasCar.CreateVehicleFromUi(i_ConstracturParamaters);
            }
            else if (i_WhichVehicle == "Truck")
            {
                o_NewVehicle = Truck.CreateVehicleFromUi(i_ConstracturParamaters);
            }
            return o_NewVehicle;
        }

        public override string ToString()
        {
            string output = theVehicle.ToString();
            output += String.Format("the name of the owner is {0} \nhis number is {1} \nthe state of the vehicle is {2}. \n", OwnerName, TelephoneNumber, vehicleState);
            return output;
        }
    }
}
