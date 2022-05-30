using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public string NameOfManufacturer { get; set; }
        public float CurrentAirPressure { get; set; }
        public float MaxAirPressure { get; set; }

        public Wheel(string i_NameOfManufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            NameOfManufacturer = i_NameOfManufacturer;

            MaxAirPressure = i_MaxAirPressure;
            if (i_MaxAirPressure <= 0)
            {
                throw new ArgumentException("the capacity of the wheel must be positive");
            }
            else
            {
                MaxAirPressure = i_MaxAirPressure;
            }
            if (i_CurrentAirPressure < 0 || i_CurrentAirPressure > MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, MaxAirPressure, "wheel air pressure");
            }
            else
            {
                CurrentAirPressure = i_CurrentAirPressure;
            }
        }

        public void Pump(int i_AirPressureToAdd)
        {
            if (this.CurrentAirPressure + i_AirPressureToAdd > this.MaxAirPressure || i_AirPressureToAdd < 0)
            {
                throw new ValueOutOfRangeException(0, this.MaxAirPressure - this.CurrentAirPressure, "wheel air pressure addition");

            }
            else
            {
                this.CurrentAirPressure += i_AirPressureToAdd;
            }
        }

        public void PumpToMax()
        {
            CurrentAirPressure = MaxAirPressure;
        }

        public override string ToString()
        {
            return String.Format("the air pressure of the wheel is {0}, his manufacturer is {1}. \n",
                CurrentAirPressure.ToString(), NameOfManufacturer);
        }
    }
}