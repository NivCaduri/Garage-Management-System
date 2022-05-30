using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Engine
    {
        protected float m_EngineCapacity;
        protected float m_CurrentEnergy;

        public Engine(float i_EngineCapacity, float i_CurrentEnergy)
        {
            m_EngineCapacity = i_EngineCapacity;
            if (i_EngineCapacity <= 0)
            {
                throw new ArgumentException("the capacity of the Engine must be positive");
            }
            else
            {
                m_EngineCapacity = i_EngineCapacity;
            }
            if (m_CurrentEnergy < 0)
            {
                throw new ArgumentException("the remaindr of the engine time cannot be negitave");
            }
            else
            {
                m_CurrentEnergy = i_CurrentEnergy;
            }            
        }

        protected virtual void AddEnergy(float i_IncreseInEnergy)
        {
            if(m_CurrentEnergy +  i_IncreseInEnergy > m_EngineCapacity || i_IncreseInEnergy < 0)
            {
                throw new ValueOutOfRangeException(0, m_EngineCapacity - i_IncreseInEnergy, "Energy addition");
            }
            else
            {
                m_CurrentEnergy += i_IncreseInEnergy;
            }
        }
    }
}
