using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {
        public ElectricEngine(float i_BatteryCapacity, float i_CurrentElectricityInBattery)
            : base(i_BatteryCapacity, i_CurrentElectricityInBattery) { }
       
        public void AddElectricity(float i_ElectricityAddition)
        {
            base.AddEnergy(i_ElectricityAddition);
        }
    }
}
