using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class GasCar : Car
    {
        public GasCar(string i_ModelName, string i_LicenseNumber, float i_PresentOfEnergyRemaining, string i_Color,
         int i_NumOfDoors, String i_WheelManufacturer, float i_CurrentWheelAirPressure)
            : base(i_Color, i_NumOfDoors, i_ModelName, i_LicenseNumber, i_PresentOfEnergyRemaining, i_WheelManufacturer, i_CurrentWheelAirPressure)
        {
            VehicleEngine = new GasEngine(38f, 38f * i_PresentOfEnergyRemaining / 100f, "Octan95");
        }

        public GasCar() : base()
        {
        }

        public static GasCar CreateVehicleFromUi(List<object> i_ConstracturParamaters)
        {
            try
            {
                string modelName = i_ConstracturParamaters[0] as string;
                string licenseNumber = i_ConstracturParamaters[1] as string;
                float presentOfBattreyRemaning = Convert.ToSingle(i_ConstracturParamaters[2]);
                string color = i_ConstracturParamaters[5] as string;
                int numOfDoors = (int)Convert.ToSingle(i_ConstracturParamaters[6]);
                string wheelManufacturer = i_ConstracturParamaters[4] as string;
                float currentWheelAirPressure = (float)Convert.ToSingle(i_ConstracturParamaters[3]);
                return new GasCar(modelName, licenseNumber, presentOfBattreyRemaning,
                    color, numOfDoors, wheelManufacturer, currentWheelAirPressure);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                throw new ArgumentException("invalid input");
            }
        }

        public override string ToString()
        {
            string output = base.ToString();
            output += "the vehicle is an gas car, his gas type is Octan95\n";
            return output;
        }
    }
}


