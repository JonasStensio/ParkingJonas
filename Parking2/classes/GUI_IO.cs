using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking2.classes
{
    class GUI_IO
    {
        public static void WriteHeadLine(string text)
        {
            Console.WriteLine(text);
            for (int i = 0; i < text.Length; ++i)
                Console.Write('-');
            Console.WriteLine("");
        }

        public static int CommandMenu(string menuName, string[] commands, string escMessage = "to go back")
        {
            ConsoleKeyInfo key;
            int command;

            WriteHeadLine(menuName);
            for (int i = 0; i < commands.Length; ++i)
                Console.WriteLine((i + 1) + ": " + commands[i]);
            Console.Write("Choose command (or press Esc " + escMessage + "): ");
            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("\n");
                    return 0;
                }
                if (int.TryParse(key.KeyChar.ToString(), out command))
                    if ((command > 0) && (command <= commands.Length))
                        break;
            }
            Console.WriteLine(key.KeyChar + "\n");
            return command;
        }

        public static bool YesNoPrompt(string message, string invalidMessage)
        {
            string input;

            Console.Write(message + " (y/n)?");
            input = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if (input == "y")
            {
                Console.WriteLine("\n");
                return true;
            }
            else
            {
                if (input != "n")
                    Console.WriteLine("\n\nInvalid answer. " + invalidMessage);
                else
                    Console.WriteLine("");
                return false;
            }
        }

        public static int NumPrompt(string message, string escMessage = "to cancel")
        {
            ConsoleKeyInfo key;
            int notUsed;
            string num = "";
            int res;

            Console.Write(message + " (or press Esc " + escMessage + "): ");
            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    res = -1;
                    break;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    if (0 == num.Length) res = -1;
                    else res = int.Parse(num) - 1;
                    break;
                }
                if (int.TryParse(key.KeyChar.ToString(), out notUsed))
                { 
                    num += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }
            Console.WriteLine("\n");
            return res;
        }
    }
}
