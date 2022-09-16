using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagementSystemWin
{
    class Input
    {
        ConsoleKey key;
        Display display;

        public Input()
        {
            display = new Display();
        }
        public string StringInput(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            string input = Console.ReadLine();
            return input;
        }

        public string PasswordInput(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            string password = "";
            do
            {
                var keyPressed = Console.ReadKey(true);
                key = keyPressed.Key;
                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password.Remove(password.Length - 1);
                }
                else if (!Char.IsControl(keyPressed.KeyChar))
                {
                    Console.Write("*");
                    password += keyPressed.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            return password;
        }

        public bool ValidateLength(string number, int length)
        {
            if (number.Length <= length)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ValidateEmail(string email)
        {
            for (int i = 0; i < email.Length; i++)
            {
                if ((i == 0 || i == email.Length) && (email[i] == '@' || email[i] == '.'))
                {
                    return false;
                }
            }
            return true;
        }

        public bool ValidateInt(string number)
        {
            int defaultValue = -1;
            bool result = int.TryParse(number, out defaultValue);
            if (!result)
            {
                /// Error Message
            }
            return result;
        }

        public bool ValidateDouble(string number)
        {
            double defaultValue = -1.00;
            bool result = double.TryParse(number, out defaultValue);
            if (!result)
            {
                /// Error Message
            }
            return result;
        }

    }


}
