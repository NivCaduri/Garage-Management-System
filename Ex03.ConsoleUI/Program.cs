using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class Program
    {
        static Ex03.GarageLogic.Garage s_TheGarage = new Ex03.GarageLogic.Garage();
        public static void Main()
        {
                while (true)
                {
                    Console.WriteLine("hello. please enter the action you wish to do.\n" +
                        "press 1 for entering a new vehicle to the garage.\n" +
                        "press 2 for reading the licence plates.\n" +
                        "press 3 for reading the licence plates by state of vhiecle.\n" +
                        "press 4 for changing the state of a vehicle in the garage.\n" +
                        "press 5 for pumping a vehicles wheels.\n" +
                        "press 6 for refuling a gas vehicle in to the garage.\n" +
                        "press 7 for recharging a electrical vehicle in the garage.\n" +
                        "press 8 for reading the details of a vehicle in the garage.\n" +
                        "press 9 to end");
                    string ActionChoice = Console.ReadLine();
                    if (ActionChoice == "1")
                    {
                        entringToGarage();
                    }
                    else if (ActionChoice == "2")
                    {
                        printThePlates();
                    }
                    else if (ActionChoice == "3")
                    {
                        printSomePlates(getChoiseOfState());
                    }
                    else if (ActionChoice == "4")
                    {
                        changeVehicleState();
                    }
                    else if (ActionChoice == "4")
                    {
                        changeVehicleState();
                    }
                    else if (ActionChoice == "5")
                    {
                        pumpWheels();
                    }
                    else if (ActionChoice == "6")
                    {
                        reFuelGasVehicle();
                    }
                    else if (ActionChoice == "7")
                    {
                        chargeElectricalVehicle();
                    }
                    else if (ActionChoice == "8")
                    {
                        getVehicleDetails();
                    }
                    else if (ActionChoice == "9")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("invalid choise, please Choose again.");
                    }
                }
            }


            private static string getChoiseOfState()
            {
                string choise = "1";
                Boolean ProperChoise = false;
                while (!ProperChoise)
                {
                    Console.WriteLine("press 1 for all paid Vehicles, 2 for fixed and 3 for not fixed");
                    choise = Console.ReadLine();
                    if (choise == "1" || choise == "2" || choise == "3")
                    {
                        ProperChoise = true;
                    }
                    else
                    {
                        Console.WriteLine("not a proper choise. please try again");
                    }
                }
                string state = "";
                if (choise == "1")
                {
                    state = "Paid";
                }
                if (choise == "2")
                {
                    state = "Repaired";
                }
                if (choise == "3")
                {
                    state = "NeedOfRepair";
                }
                return state;
            }

            private static void entringToGarage()
            {
                Console.WriteLine("please enter the vehicle owners name.");
                string ownersName = Console.ReadLine();
                Console.WriteLine("please enter the vehicle owners phone number.");
                string ownersPhoneNumber = Console.ReadLine();
                Console.WriteLine("please enter the vehicle you wish to choose.");
                Console.WriteLine("the options are: ");
                s_TheGarage.GetOptions().ForEach(Console.WriteLine);
                string vehicleType = Console.ReadLine();
                Ex03.GarageLogic.Vehicle chosenVehicle = null;
                Boolean wrongInput = true;
                while (wrongInput)
                {
                    if (Ex03.GarageLogic.VehicleInGarage.s_SupportedVehicles.Keys.Contains(vehicleType))
                    {
                        chosenVehicle = (Ex03.GarageLogic.VehicleInGarage.s_SupportedVehicles[vehicleType]);
                        wrongInput = false;
                    }
                    else
                    {
                        Console.WriteLine("not a valid vehicle type.");
                        Console.WriteLine("please enter the vehicle you wish to choose.");
                        Console.WriteLine("the options are: ");
                        s_TheGarage.GetOptions().ForEach(Console.WriteLine);
                        vehicleType = Console.ReadLine();
                    }
                }
                List<string> questions = chosenVehicle.GetQuestions();
                List<object> inputAnswers = new List<object>();
                string answer;
                foreach (string question in questions)
                {
                    Console.WriteLine(question);
                    answer = Console.ReadLine();
                    inputAnswers.Add(answer);
                }
                try
                {
                Ex03.GarageLogic.VehicleInGarage newVehicle = new Ex03.GarageLogic.VehicleInGarage(ownersName, ownersPhoneNumber, vehicleType, inputAnswers);
                    s_TheGarage.GetVehicleInGarage(newVehicle);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    entringToGarage();
                }
            }
            private static void printThePlates()
            {
                s_TheGarage.GetListOfATlLicensesInGarage().ForEach(Console.WriteLine);
            }
            private static void printSomePlates(string i_state)
            {
                s_TheGarage.GetListOfTypeOfLicensesInGarage(i_state).ForEach(Console.WriteLine);
            }
            private static void changeVehicleState()
            {
                Boolean badChoise = true;
                while (badChoise)
                {
                    Console.WriteLine("plese the Vhiecles Licence number.");
                    string licenceNumber = Console.ReadLine();
                    Console.WriteLine("plese the desired state");
                    string newState = getChoiseOfState();
                    try
                    {
                        s_TheGarage.ChangeStateOfVehicle(licenceNumber, newState);
                        badChoise = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("not a proper choise. please try again");
                    }
                }
                Console.WriteLine("done.");
            }
            private static void pumpWheels()
            {
                Boolean badChoise = true;
                while (badChoise)
                {
                    Console.WriteLine("plese the Vhiecles Licence number.");
                    string LicenceNumber = Console.ReadLine();
                    try
                    {
                        s_TheGarage.PumpAirToWheelsOfCar(LicenceNumber);
                        badChoise = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("not a proper plate. please try again");
                    }
                }
                Console.WriteLine("done.");
            }
            private static void reFuelGasVehicle()
            {
                Boolean badChoise = true;
                while (badChoise)
                {
                    Console.WriteLine("plese the Vhiecles Licence number.");
                    string licenceNumber = Console.ReadLine();
                    Console.WriteLine("plese enter the amout of gas you wish to fill.");
                    string gasToBeFilled = Console.ReadLine();
                    Console.WriteLine("plese enter the amout of gas you wish to fill.");
                    string typeOfGas = Console.ReadLine();
                    try
                    {
                        float amoutOfgasToBeFilled = float.Parse(gasToBeFilled);
                        s_TheGarage.FillGasTank(licenceNumber, typeOfGas, amoutOfgasToBeFilled);
                        badChoise = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("an error happend. please try again");
                    }
                }
            }

            private static void chargeElectricalVehicle()
            {
                Boolean badChoice = true;
                while (badChoice)
                {
                    Console.WriteLine("please the Vehicles License number.");
                    string LicenceNumber = Console.ReadLine();
                    Console.WriteLine("plese enter the amout of electricity you wish to charge.");
                    string gasToBeFilled = Console.ReadLine();
                    try
                    {
                        float AmoutOfgasToBeFilled = float.Parse(gasToBeFilled);
                        s_TheGarage.FillBattrey(LicenceNumber, AmoutOfgasToBeFilled);
                        badChoice = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("an error happend. please try again");
                    }
                }
            }
            private static void getVehicleDetails()
            {
                string licenceNumber = "";
                Boolean badChoice = true;
                Ex03.GarageLogic.Vehicle desierdVehicle;
                while (badChoice)
                {
                    try
                    {
                        Console.WriteLine("plese the Vhiecles Licence number.");
                        licenceNumber = Console.ReadLine();
                        desierdVehicle = s_TheGarage.GetVehicleByLicenceNumber(licenceNumber).theVehicle;
                        badChoice = false;

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("an error happend. please try again");
                    }
                }
                Console.WriteLine(s_TheGarage.GetVehicleByLicenceNumber(licenceNumber).ToString());

            }
        }
    }

