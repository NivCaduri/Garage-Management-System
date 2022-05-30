using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, float i_PrecentOfEnergyRemaining, 
            string i_LicenseType, int i_EngineCapacity, float i_CurrentWheelAirPressure, string i_WheelManufacturer) :
            base(i_LicenseType, i_EngineCapacity, i_ModelName, i_LicenseNumber, i_PrecentOfEnergyRemaining
               , i_WheelManufacturer, i_CurrentWheelAirPressure)
        {
            VehicleEngine = new ElectricEngine(2.5f, i_PrecentOfEnergyRemaining * 2.5f / 100);
        }

        public ElectricMotorcycle() : base() { }

        public static Vehicle CreateVehicleFromUi(List<object> i_ConstracturParamaters)
        {
            try
            {
                string modelName = i_ConstracturParamaters[0] as string;
                string licenseNumber = i_ConstracturParamaters[1] as string;
                float precentOfEnergyRemaining = (float)Convert.ToSingle(i_ConstracturParamaters[2]);
                string licenseType = i_ConstracturParamaters[6] as string;
                int engineCapacity = (int)Convert.ToSingle(i_ConstracturParamaters[5]);
                float currentWheelAirPressure = (float)Convert.ToSingle(i_ConstracturParamaters[3]);
                string wheelManufacturer = i_ConstracturParamaters[4] as string;
                return new ElectricMotorcycle(modelName, licenseNumber, precentOfEnergyRemaining,
                    licenseType, engineCapacity, currentWheelAirPressure, wheelManufacturer);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
           
        }

        public override string ToString()
        {
            string output = base.ToString();
            output += "the vehicle is an electric motorCycle \n";
            return output;
        }
    }
}
