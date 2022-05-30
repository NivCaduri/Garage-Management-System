using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        public eColor Color { get; }
        private int m_NumOfDoors;

        public Car(string i_color, int i_NumOfDoors, string i_ModelName, string i_LicenseNumber, 
            float i_PrecentOfEnergyRemaining,string i_WheelManufacturer, float i_CurrentWheelAirPresure) 
            : base(i_ModelName,  i_LicenseNumber, i_PrecentOfEnergyRemaining, i_CurrentWheelAirPresure, i_WheelManufacturer, 4, 31f)
        {
            try
            {
                Color = (eColor)Enum.Parse(typeof(eColor), i_color);

            }
            catch(Exception ex)
            {
                throw new ArgumentException("Error, invalid car color, the colors are Red,White,Green,Blue.");
            }
            NumOfDoors = i_NumOfDoors;

        }

        public Car() :base ()
        {
            m_InputQustions.Add("plese enter the color of the car.");
            m_InputQustions.Add("please enter the amout of car doors.");
        }

        public int NumOfDoors
        {
            get { return m_NumOfDoors; }
            set
            {
                if (value < 2 || value > 5)
                {
                    throw new ValueOutOfRangeException(2, 5, "the number of doors");
                }
                else
                {
                    m_NumOfDoors = value;
                }
            }
        }

        public enum eColor
        {
            Red,
            White,
            Green,
            Blue
        }

        public override string ToString()
        {
            string outPut = base.ToString();
            outPut += String.Format("the color of the door is {0} \nthere are {1} doors. \n", Color, NumOfDoors);
            return outPut;
        }
    }
}
