using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking2.classes
{
    class Menu
    {
        private MenuCommands menuCommands;

        public Menu()
        {
            menuCommands = new MenuCommands(this);
        }

        private string[] commands = { "Add vehicle", "Remove vehicle", "Move vehicle", "Show parking lot status", "Find a vehicle" };
        private string[] commandsAdd = { "Add a car", "Add a motorcycle", "Add a trike", "Add a bicycle" };
        private string[] commandsShowParkLotStatus = { "Show status on a specific parking spot", "Show status on the entire parking lot" };
        private string[] commandsFind = { "Find a vehicle by its registration number" };

        public int MainMenu()
        {
            int command;
            while (true)
            {
                command = GUI_IO.CommandMenu("Main menu", commands, "to quit the application") -1;
                return command;
            }
        }

        public int AddMenu()
        {
            int command;
            command = GUI_IO.CommandMenu("Add a vehicle menu", commandsAdd, "to cancel") -1;
            if (command == -1) return -1;
            menuCommands.AddMenuCommands(command);
            return command;
        }

        public int RemoveMenu()
        {
            int command = 1;
            while (true)
            {
                menuCommands.RemoveMenuCommands(command);
                return command;
            }
        }

        public int MoveMenu()
        {
            int command = 1;
            while (true)
            {
                menuCommands.MoveMenuCommands(command);
                return command;
            }
        }

        public int ShowParkLotStatus()
        {
            int command;
            while (true)
            {
                command = GUI_IO.CommandMenu("Show parking lot status menu", commandsShowParkLotStatus, "to go back") - 1;
                if (command != -1) GUI_IO.WriteHeadLine(commandsShowParkLotStatus[command]);
                else GUI_IO.WriteHeadLine("");
                menuCommands.ShowParkLotStatusCommands(command);
                return command;
            }
        }

        public int Find()
        {
            int command = 1;
            while (true)
            {
                menuCommands.FindCommands(command);
                return command;
            }
        }
    }
}
