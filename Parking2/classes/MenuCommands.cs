using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking2.classes
{
    class MenuCommands
    {
        private ParkLot parkLot;
        private Menu menu;

        public MenuCommands(Menu menu)
        {
            this.menu = menu;
            parkLot = new ParkLot(100);
        }

        public void MainMenuCommands(int command)
        {
            switch (command)
            {
                case -1:
                    ExitApplication();
                    break;
                case 0:
                    menu.AddMenu();
                    break;
                case 1:
                    menu.RemoveMenu();
                    break;
                case 2:
                    menu.MoveMenu();
                    break;
                case 3:
                    menu.ShowParkLotStatus();
                    break;
                case 4:
                    menu.Find();
                    break;
                default:
                    break;
            }
            Console.WriteLine("");
        }

        public void AddMenuCommands(int command)
        {
            string regNum;
            int parkSpotIx;
            string colour;
            Vehicle vehicle;

            if (RegNumPrompt(out regNum))
            {
                switch (command)
                {
                    case 0:
                        Console.Write("Enter the colour of the car: ");
                        colour = Console.ReadLine();
                        vehicle = new Car(regNum, colour);
                        break;
                    case 1:
                        Console.Write("Enter the colour of the motorcycle: ");
                        colour = Console.ReadLine();
                        vehicle = new Motorcycle(regNum, 2, colour);
                        break;
                    case 2:
                        Console.Write("Enter the colour of the trike: ");
                        colour = Console.ReadLine();
                        vehicle = new Trike(regNum, 3, colour);
                        break;
                    case 3:
                        Console.WriteLine("Enter the colour of the bicycle");
                        colour = Console.ReadLine();
                        vehicle = new Bicycle(regNum, colour);
                        break;
                    default:
                        Console.WriteLine("");
                        return;
                }
            }
            else
            {
                Console.WriteLine("");
                return;
            }
            if (parkLot.Add(vehicle, out parkSpotIx))
                Console.WriteLine("Park {0} {1} at parking spot {2}.", vehicle.VehicleType.ToLower(), vehicle.RegNum, parkSpotIx + 1);
            else
                Console.WriteLine("Error adding vehicle.");
        }

        public void RemoveMenuCommands(int command)
        {
            string regNum;
            Vehicle vehicle;

            switch (command)
            {
                case -1:       
                    break;
                case 1:
                    if (RegNumPrompt(out regNum))
                    {
                        if (!parkLot.GetVehicle(regNum, out vehicle))
                        {
                            Console.Write("Error!");
                            return;
                        }
                        parkLot.Remove(vehicle);
                        Console.WriteLine("Remove {0} {1} from parking slot {2}", vehicle.VehicleType.ToLower(), vehicle.RegNum, vehicle.ParkingSpot + 1);
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine("");
        }

        public void MoveMenuCommands(int command)
        {
            string regNum;
            int toParkSpotIx;
            Vehicle vehicle;

            switch (command)
            {
                case -1:
                    break;
                case 1:
                    if (RegNumPrompt(out regNum))
                    {
                        if (!parkLot.GetVehicle(regNum, out vehicle))
                        {
                            Console.Write("The vehicle doesn't exists in the parking lot.\n");
                            return;
                        }
                        parkLot.GetVehicle(regNum, out vehicle);

                        toParkSpotIx= GUI_IO.NumPrompt("To which parking spot do you want to move the " + vehicle.VehicleType.ToLower() + " " + vehicle.RegNum);
                        if (-1 == toParkSpotIx) return;
                        // TODO: check park spot exists
                        //                        Console.Write("To which parking lot do you want to move the {0} {1}: ", vehicle.VehicleType.ToLower(), vehicle.RegNum);
//                        toParkSpotIx = Convert.ToInt32(Console.ReadLine());
                        

                        if (parkLot.Move(vehicle, toParkSpotIx))
                            Console.WriteLine("Move {0} {1} parked at {2} to parking lot {3}.", vehicle.VehicleType.ToLower(), vehicle.RegNum, vehicle.ParkingSpot + 1, toParkSpotIx + 1);
                        else
                            Console.WriteLine("The {0} {1} cannot fit on parking spot: {2}", vehicle.VehicleType.ToLower(), vehicle.RegNum, toParkSpotIx + 1);
                    }
                    else
                        Console.WriteLine("There is no vehicle in the parking lot with that registration number!");
                    break;
                default:
                    break;
            }
        }

        public void ShowParkLotStatusCommands(int command)
        {
            int parkSpotIx;
            ParkSpot parkSpot;
            string parkSpotInfo = "";
            switch (command)
            {
                case -1:
                    
                    break;
                case 0:
                    parkSpotIx = GUI_IO.NumPrompt("Enter parking slot number");
                    if (parkSpotIx < 0) return;
                    if (parkSpotIx >= parkLot.ParkSpots.Length)
                    {
                        Console.WriteLine("The parking spot {0} doesn't exist.", parkSpotIx + 1);
                        return;
                    }
                    parkSpot = parkLot.ParkSpots[parkSpotIx];
                    if (0 == parkSpot.Vehicles.Count)
                    {
                        Console.WriteLine("The parking spot is empty.");
                        return;
                    }
                    for (int i = 0; i < parkSpot.Vehicles.Count; ++i)
                        parkSpotInfo += parkSpot.Vehicles[i].VehicleType + " " + parkSpot.Vehicles[i].RegNum + ", ";
                    Console.WriteLine(parkSpotInfo.Substring(0, parkSpotInfo.Length - 2));
                    break;
                case 1:
                    for (int i = 0; i < parkLot.ParkSpots.Length; ++i)
                    {
                        parkSpot = parkLot.ParkSpots[i];
                        if (0 < parkSpot.Vehicles.Count)
                        {
                            parkSpotInfo = (i + 1) + ": ";
                            for (int j = 0; j < parkSpot.Vehicles.Count; ++j)
                                parkSpotInfo += parkSpot.Vehicles[j].VehicleType + " " + parkSpot.Vehicles[j].RegNum + ", ";
                            Console.WriteLine(parkSpotInfo.Substring(0, parkSpotInfo.Length - 2));
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void FindCommands(int command)
        {
            string regNum;
            Vehicle vehicle;

            if (!RegNumPrompt(out regNum)) return;
            else if (0 == regNum.Length)
            {

            }
            else
            {
                if (!parkLot.GetVehicle(regNum, out vehicle))
                {
                    Console.Write("Error!");
                    return;
                }
                Console.WriteLine("The vehicle {0} {1} is parked at parking lot: {2}", vehicle.VehicleType, vehicle.RegNum, vehicle.ParkingSpot + 1);
            }
            Console.WriteLine("");
        }

        public void ExitApplication()
        {
            if (GUI_IO.YesNoPrompt("Do you want to quit the application?", "Application will not quit."))
            {
                Console.WriteLine("Parking lot application is now closed.");
                Environment.Exit(0);
            }
        }

        private static bool RegNumPrompt(out string regNum)
        {
            ConsoleKeyInfo keyInfo;
            string key;

            Console.Write("Enter registration number (or press Esc to cancel): ");
            regNum = "";
            while (true)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("");
                    return false;
                }
                if (keyInfo.Key == ConsoleKey.Enter) break;
                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    Console.Write("\b \b");
                    regNum = regNum.Substring(0, regNum.Length - 1);
                    continue;
                }
                key = keyInfo.KeyChar.ToString().ToUpper();
                Console.Write(key);
                regNum += key;
            }
            if (0 == regNum.Length)
            {
                Console.WriteLine("Registration number must not be empty.");
                return false;
            }
            Console.WriteLine("");
            return true;
        }
    }
}
