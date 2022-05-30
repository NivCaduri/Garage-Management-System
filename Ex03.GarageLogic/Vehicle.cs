using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public string ModelName { get; set; }
        public string LicenseNumber { get; set; }
        protected float m_PrecentOfEnergyRemaining;
        public Engine VehicleEngine { get; protected set; }
        public List<Wheel> Wheels { get; protected set; }
        protected List<string> m_InputQustions;

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_PrecentOfEnergyRemaining,
            float i_CurrentWheelAirPresure, String I_WheelManufacturer, int i_NumOfWheels, float i_MaxWheelAirPressure)
        {
            ModelName = i_ModelName;
            LicenseNumber = i_LicenseNumber;
            PrecentOfEnergyRemaining = i_PrecentOfEnergyRemaining;
            Wheels = MakeCustomWheelsForAVehicle(i_NumOfWheels, i_CurrentWheelAirPresure, I_WheelManufacturer, i_MaxWheelAirPressure);
        }

        public List<string> GetQuestions()
        {
            return m_InputQustions;
        }

        public Vehicle()
        {
            m_InputQustions = new List<string>();
            m_InputQustions.Add("please enter the model name.");
            m_InputQustions.Add("please enter your licence number.");
            m_InputQustions.Add("please enter the precent of energy that remains in the engine");
            m_InputQustions.Add("please enter the current air pressure of the wheels");
            m_InputQustions.Add("please enter the wheels Manufacturer");

        }

        public float PrecentOfEnergyRemaining
        {
            get { return m_PrecentOfEnergyRemaining; }
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new ValueOutOfRangeException(0, 100, "wheel air pressure");
                }
                else
                {
                    m_PrecentOfEnergyRemaining = value;
                }
            }
        }

        public Boolean Equals(Vehicle i_Vehicle)
        {
            return i_Vehicle.LicenseNumber.Equals(this.LicenseNumber);
        }

        public static List<Wheel> MakeCustomWheelsForAVehicle(int i_NumOfWheels, float i_CurrentAirPressure,
            string i_NameOfManufacturer, float i_MaxWheelAirPressure)
        {
            List<Wheel> Wheels = new List<Wheel>();
            if (i_NumOfWheels < 0 || i_CurrentAirPressure < 0)
            {
                throw new ArgumentException("The number of wheels and the air pressure must be posotive");
            }
            else
            {
                for (int i = 0; i < i_NumOfWheels; i++)
                {
                    Wheels.Add(new Wheel(i_NameOfManufacturer, i_CurrentAirPressure, i_MaxWheelAirPressure));
                }
            }
            return Wheels;
        }

        public override string ToString()
        {
            string OutPut = string.Format("Licence number: {0} \nmodel name: {1} \nthere is {2} precent of enrgy remaining in the engine. \n", LicenseNumber, ModelName, PrecentOfEnergyRemaining);
            foreach (Wheel wheel in Wheels)
            {
                OutPut += wheel.ToString();
            }
            return OutPut;
        }
    }
}
