using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : Car
    {
        public ElectricCar(string i_ModelName, string i_LicenseNumber, float i_PresentOfBattreyRemaning
            , string i_Color, int i_NumOfDoors, string i_WheelManufacturer, float i_CurrentWheelAirPressure)
            : base(i_Color, i_NumOfDoors, i_ModelName, i_LicenseNumber, i_PresentOfBattreyRemaning, i_WheelManufacturer, i_CurrentWheelAirPressure)
        {
            VehicleEngine = new ElectricEngine(3.3f, i_PresentOfBattreyRemaning * 3.3f / 100f);
        }

        public ElectricCar() : base() { }

        static ElectricCar() { }

        public static Vehicle createVehicleFromUi(List<object> i_ConstracturParamaters)
        {
            try
            {
                string modelName = i_ConstracturParamaters[0] as string;
                string licenseNumber = i_ConstracturParamaters[1] as string;
                float presentOfBattreyRemaning = Convert.ToSingle(i_ConstracturParamaters[2]);
                string color = i_ConstracturParamaters[5] as string;
                int numOfDoors = (int)Convert.ToSingle(i_ConstracturParamaters[6]);
                string WheelManufacturer = i_ConstracturParamaters[4] as string;
                float currentWheelAirPressure = (float)Convert.ToSingle(i_ConstracturParamaters[3]);
                return new GasCar(modelName, licenseNumber, presentOfBattreyRemaning,
                    color, numOfDoors, WheelManufacturer, currentWheelAirPressure);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("invalid input");
            }
        }

        public override string ToString()
        {
            string output = base.ToString();
            output += "the vehicle is an electric car\n";
            return output;
        }
    }
}

