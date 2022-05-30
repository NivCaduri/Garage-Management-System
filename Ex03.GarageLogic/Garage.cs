using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        Dictionary<string, VehicleInGarage> m_VehiclesInGarage = new Dictionary<string, VehicleInGarage>();

        public void GetVehicleInGarage(VehicleInGarage i_vehicleEnteringGrage)
        {
            try
            {
                if (m_VehiclesInGarage.ContainsKey(i_vehicleEnteringGrage.theVehicle.LicenseNumber))
                {
                    throw new ArgumentException("The Vehicle is already in the garage");
                }
                else
                {
                    i_vehicleEnteringGrage.vehicleState = VehicleInGarage.eVehicleStatus.NeedOfRepair;
                    m_VehiclesInGarage[i_vehicleEnteringGrage.theVehicle.LicenseNumber] = i_vehicleEnteringGrage;
                }

            }
            catch (NullReferenceException ex)
            {
                throw new ArgumentException(ex.Message + "invalic inputs");
            }
        }

        public List<string> GetOptions()
        {
            return new List<string>(VehicleInGarage.s_SupportedVehicles.Keys);
        }

        private static VehicleInGarage.eVehicleStatus convertStringToCarState(string i_VehicleStatus)
        {
            VehicleInGarage.eVehicleStatus SearchedState = VehicleInGarage.eVehicleStatus.NeedOfRepair;
            try
            {
                SearchedState = (VehicleInGarage.eVehicleStatus)Enum.Parse
                                           (typeof(VehicleInGarage.eVehicleStatus), i_VehicleStatus);
            }
            catch (Exception e)
            {
                throw new FormatException("not a valid car state");
            }
            return SearchedState;
        }

        public List<string> GetListOfTypeOfLicensesInGarage(string i_VehicleStatus)
        {
            List<string> licenses = new List<string>();
            try
            {
                VehicleInGarage.eVehicleStatus SearchedState = convertStringToCarState(i_VehicleStatus); ;
                foreach (string key in m_VehiclesInGarage.Keys)
                {
                    if (m_VehiclesInGarage[key].vehicleState == SearchedState)
                    {
                        licenses.Add(key);
                    }
                }
            }
            catch (Exception e)
            {
                throw new FormatException("the input is not a valid Car State");
            }
            return licenses;
        }

        public List<string> GetListOfATlLicensesInGarage()
        {
            return new List<string>(m_VehiclesInGarage.Keys);
        }

        public void ChangeStateOfVehicle(string i_LicenceNumber, string i_NewState)
        {
            if (!m_VehiclesInGarage.ContainsKey(i_LicenceNumber))
            {
                throw new ArgumentException("you are trying to change the state of a vehicle that is not in the garage");
            }
            else
            {
                try
                {
                    VehicleInGarage.eVehicleStatus newState = convertStringToCarState(i_NewState);
                    m_VehiclesInGarage[i_LicenceNumber].vehicleState = newState;
                }
                catch (Exception e)
                {
                    throw new Exception("the input is not a valid Car State");
                }
            }
        }

        public void PumpAirToWheelsOfCar(string i_LicenceNumber)
        {
            if (!m_VehiclesInGarage.ContainsKey(i_LicenceNumber))
            {
                throw new ArgumentException("you are trying to pump air to a vehicle that is not in the garage");
            }
            else
            {
                foreach (Wheel wheel in m_VehiclesInGarage[i_LicenceNumber].theVehicle.Wheels)
                {
                    wheel.PumpToMax();
                }
            }
        }

        public void FillGasTank(string i_LicenceNumber, string i_TypeOfGas, float i_AmoutToFill)
        {
            if (!m_VehiclesInGarage.ContainsKey(i_LicenceNumber))
            {
                throw new ArgumentException("you are trying to pump gas to a vehicle that is not in the garage");
            }
            else
            {
                GasEngine ConvertedVehicle = m_VehiclesInGarage[i_LicenceNumber].theVehicle.VehicleEngine as GasEngine;
                if (ConvertedVehicle != null)
                {
                    (ConvertedVehicle).AddGas(i_AmoutToFill, i_TypeOfGas);
                }
                else
                {
                    throw new ArgumentException("you are trying to add gas to an non gas vehicle");
                }
            }
        }

        public void FillBattrey(string i_LicenceNumber, float i_AmoutToFill)
        {
            if (!m_VehiclesInGarage.ContainsKey(i_LicenceNumber))
            {
                throw new ArgumentException("you are trying to pump gas to a vehicle that is not in the garage");
            }
            else
            {
                if (m_VehiclesInGarage[i_LicenceNumber].theVehicle.VehicleEngine is ElectricEngine)
                {
                    (m_VehiclesInGarage[i_LicenceNumber].theVehicle.VehicleEngine as ElectricEngine).AddElectricity(i_AmoutToFill);
                }
                else
                {
                    throw new ArgumentException("you are trying to charge electricity to an non electric vehicle");
                }
            }
        }

        public VehicleInGarage GetVehicleByLicenceNumber(string i_LicenceNumber)
        {
            if (m_VehiclesInGarage.ContainsKey(i_LicenceNumber))
            {
                return m_VehiclesInGarage[i_LicenceNumber];
            }
            else
            {
                throw new ArgumentException("you are trying to get the details to a vehicle that is not in the garage");
            }
        }
    }
}
