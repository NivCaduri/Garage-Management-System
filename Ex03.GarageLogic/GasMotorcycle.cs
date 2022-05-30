using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class GasMotorcycle : Motorcycle
    {
        public GasMotorcycle(string i_ModelName, string i_LicenseNumber, float i_PrecentOfEnergyRemaining,
            string i_LicenseType, int i_EngineCapacity, string i_WheelManufacturer, float i_CurrentWheelAirPressure) :
            base(i_LicenseType, i_EngineCapacity, i_ModelName, i_LicenseNumber, i_PrecentOfEnergyRemaining
               , i_WheelManufacturer, i_CurrentWheelAirPressure)
        {
            VehicleEngine = new GasEngine(6.2f, 6.2f * i_PrecentOfEnergyRemaining / 100, "Octan98");
        }

        public GasMotorcycle() : base() { }

        public static GasMotorcycle CreateVehicleFromUi(List<object> i_ConstracturParamaters)
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
                return new GasMotorcycle(modelName, licenseNumber, precentOfEnergyRemaining,
                    licenseType, engineCapacity, wheelManufacturer, currentWheelAirPressure);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("invalid input");
            }
        }

        public override string ToString()
        {
            string output = base.ToString();
            output += "the vehicle is an gas car, his gas type is Octan98\n";
            return output;
        }
    }
}
