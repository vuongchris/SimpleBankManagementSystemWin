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

        /// <summary>
        /// Used for inputting anything from the user
        /// </summary>
        /// <param name="x"> X Position of Cursor </param>
        /// <param name="y"> Y Position of Cursor </param>
        /// <param name="width"> Width of Box</param>
        /// <returns> string </returns>
        public string StringInput(int x, int y, int width)
        {
            display.ClearAt(x, y, width - x - 3);
            Console.SetCursorPosition(x, y);
            string input = Console.ReadLine();
            return input;
        }

        /// <summary>
        /// Used for inputting passwords from the user
        /// </summary>
        /// <param name="x"> X Position of Cursor </param>
        /// <param name="y"> Y Position of Cursor </param>
        /// <param name="width"> Width of Box</param>
        /// <returns> string </returns>
        public string PasswordInput(int x, int y, int width)
        {
            display.ClearAt(x, y, width - x - 3);
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

        /// <summary>
        /// Used to check the length of an input
        /// </summary>
        /// <param name="number"> Number input from user</param>
        /// <param name="length"> Maximum length required</param>
        /// <returns> bool </returns>
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

        /// <summary>
        /// Used to check if an email is the correct format
        /// </summary>
        /// <param name="email"> Email address input </param>
        /// <returns> bool </returns>
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
        
        /// <summary>
        /// Used to check if user input is an integer
        /// </summary>
        /// <param name="number"> Number input from user </param>
        /// <returns> bool </returns>
        public bool ValidateInt(string number)
        {
            int defaultValue = -1;
            bool result = int.TryParse(number, out defaultValue);
            return result;
        }

        /// <summary>
        /// Used to check if the user input is a double
        /// </summary>
        /// <param name="number"> Number input from user </param>
        /// <returns> bool </returns>
        public bool ValidateDouble(string number)
        {
            double defaultValue = -1.00;
            bool result = double.TryParse(number, out defaultValue);
            return result;
        }

    }


}
