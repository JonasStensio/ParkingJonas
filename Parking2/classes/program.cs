using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking2.classes
{
    class Program
    {
        private Menu menu;
        private MenuCommands menuCommands;

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.StartAppp();
        }

        public void StartAppp()
        {
            menu = new Menu();
            menuCommands = new MenuCommands(menu);
            int command;

            GUI_IO.WriteHeadLine("Parking lot application");
            Console.WriteLine("");
            while (true)
            {
                command = menu.MainMenu();
                menuCommands.MainMenuCommands(command);
            }
        }
    }

    

    

        
    
}
