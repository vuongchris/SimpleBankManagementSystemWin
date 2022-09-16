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

        public void UserLogin()
        {
            display.LoginScreen();
            username = input.StringInput(12, 6);
            password = input.PasswordInput(12, 7);

            while (!CheckCredentials(username, password))
            {
                display.LoginFailError();
                username = input.StringInput(12, 6);
                password = input.PasswordInput(12, 7);
            }
            display.LoginSuccessMessage();
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
