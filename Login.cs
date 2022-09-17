using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace SimpleBankManagementSystemWin
{
    public class Login
    {
        string username, password;
        Display display;
        Input input;

        public Login()
        {
            display = new Display();
            input = new Input();
        }

        public void UserLogin(int x, int y, int width)
        {
            display.LoginScreen(x, y, width);
            username = input.StringInput(x + 12, y + 6, width);
            password = input.PasswordInput(x + 12, y + 7, width);

            while (!CheckCredentials(username, password))
            {
                display.LoginFailError(x, y + 9, width);
                display.ClearAt(x + 12, y + 6, width - x - 13);
                display.ClearAt(x + 12, y + 7, width - x - 13);
                username = input.StringInput(x + 12, y + 6, width);
                password = input.PasswordInput(x + 12, y + 7, width);
            }
            display.LoginSuccessMessage(x, y + 9, width);
        }

        public bool CheckCredentials(string inputUsername, string inputPassword)
        {
            foreach (string line in System.IO.File.ReadLines($"login.txt"))
            {
                string[] elements = line.Split(new char[] { '|' }, StringSplitOptions.None);
                if (inputUsername == elements[0])
                {
                    if (inputPassword == elements[1])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
