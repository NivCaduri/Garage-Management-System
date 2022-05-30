using System;

namespace Ex03.GarageLogic
{
    internal class GasEngine : Engine
    {
        private eTypeOfGas m_TypeOfGas;

        public GasEngine(float i_engineCapacity, float i_CurrentGasInEngine,
            String i_TypeOfGas) : base(i_engineCapacity, i_CurrentGasInEngine)
        {
            try
            {
                m_TypeOfGas = (eTypeOfGas)Enum.Parse(typeof(eTypeOfGas), i_TypeOfGas);
            }
            catch (Exception e)
            {
                throw new ArgumentException("the input is not a valid gas type");
            }
        }

        public enum eTypeOfGas
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        public void AddGas(float i_GasAddition, string i_TypeOfGasAdded)
        {
            if (!m_TypeOfGas.Equals(m_TypeOfGas))
            {
                throw new ArgumentException("the gas entering does not match the gas within");
            }
            else
            {
                base.AddEnergy(i_GasAddition);
            }
        }
    }
}
