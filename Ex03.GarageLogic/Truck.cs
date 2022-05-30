using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        public Boolean RefrigeratedContents { get; set; }
        float m_TruckCapacity;

        public Truck() : base()
        {
            m_InputQustions.Add("please enter if there is refridgrated content. enter true or false.");
            m_InputQustions.Add("plese enter the capacity of the truck.");
        }

        public Truck(string i_ModelName, string i_LicenseNumber, float i_PrecentOfEnergyRemaining, Boolean i_RefrigeratedContents, float i_TruckCapacity,
            string i_WheelManufacturer, float i_CurrentWheelAirPresure)
            : base(i_ModelName, i_LicenseNumber, i_PrecentOfEnergyRemaining, i_CurrentWheelAirPresure, i_WheelManufacturer, 16, 24f)
        {
            RefrigeratedContents = i_RefrigeratedContents;
            TruckCapacity = i_TruckCapacity;
            VehicleEngine = new GasEngine(120f, 120f * i_PrecentOfEnergyRemaining / 100, "Soler");
        }

        public float TruckCapacity
        {
            get { return m_TruckCapacity; }
            set
            {
                if (m_TruckCapacity < 0)
                {
                    throw new ArgumentException("The capacity of the Truck must be positive");
                }
                else
                {
                    m_TruckCapacity = value;
                }
            }
        }

        public static Vehicle CreateVehicleFromUi(List<object> i_ConstracturParamaters)
        {
            try
            {
                string modelName = i_ConstracturParamaters[0] as string;
                string licenseNumber = i_ConstracturParamaters[1] as string;
                float presentOfBattreyRemaning = (float)Convert.ToSingle(i_ConstracturParamaters[2]);
                Boolean refrigeratedContents = (Boolean)Boolean.Parse(i_ConstracturParamaters[5] as string);
                int truckCapacity = (int)Convert.ToSingle(i_ConstracturParamaters[6]);
                string wheelManufacturer = i_ConstracturParamaters[4] as string;
                float currentWheelAirPressure = (float)Convert.ToSingle(i_ConstracturParamaters[3]);

                return new Truck(modelName, licenseNumber, presentOfBattreyRemaning,
                    refrigeratedContents, truckCapacity, wheelManufacturer, currentWheelAirPressure);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("invalid input");
            }
        }

        public override string ToString()
        {
            string outPut = base.ToString();
            outPut += String.Format("the type of vehicle is a truck. the type of gas is Soler.\n " +
                "the truck capacity is {1} \nthe truck has refrigerated contents:{0}. \n", RefrigeratedContents, TruckCapacity);
            return outPut;
        }
    }
}

