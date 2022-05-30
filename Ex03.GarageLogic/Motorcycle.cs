using System;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        public eTypesOfMotorcycleLicense LicenseType { get; }
        private int m_EngineSize;

        public Motorcycle(string i_eTypesOfMotorcycleLicense, int i_EngineCapacity,
            string i_ModelName, string i_LicenseNumber, float i_PrecentOfEnergyRemaining
            , string i_WheelManufacturer, float i_CurrentWheelAirPresure)
            : base(i_ModelName, i_LicenseNumber, i_PrecentOfEnergyRemaining, i_CurrentWheelAirPresure, i_WheelManufacturer, 2, 29f)
        {
            LicenseType = (eTypesOfMotorcycleLicense)Enum.Parse(typeof(eTypesOfMotorcycleLicense), i_eTypesOfMotorcycleLicense);
            EngineSize = i_EngineCapacity;
        }

        public Motorcycle() : base()
        {
            m_InputQustions.Add("please enter the capacity of the engine");
            m_InputQustions.Add("please enter the type of the licence");
        }

        public enum eTypesOfMotorcycleLicense
        {
            AA,
            A1,
            BB,
            B1
        }

        public int EngineSize
        {
            get { return m_EngineSize; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("the capacity of the Engine must be positive");
                }
                else
                {
                    m_EngineSize = value;
                }
            }
        }

        public override string ToString()
        {
            string outPut = base.ToString();
            outPut += String.Format("the size of the engine is {0} \n the type of the license is {1}. \n", EngineSize, LicenseType);
            return outPut;
        }
    }
}
