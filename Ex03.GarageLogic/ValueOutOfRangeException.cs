using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public float MaxValue
        {
            get { return m_MaxValue; }
        }

        public float MinVlue
        {
            get { return m_MinValue; }
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinVlue, string i_paramater)
            : base(String.Format("Error, The value is out of the " +
                "allowd range of {2} is between {0} and {1}", i_MaxValue, i_MinVlue, i_paramater))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinVlue;
        }
    }
}
