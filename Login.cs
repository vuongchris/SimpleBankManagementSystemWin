using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace SimpleBankManagementSystem
{
    public class Login
    {
        string username, password;
        ConsoleKey key;

        public Login()
        {

        }

        public string EnterUsername()
        {
            Console.SetCursorPosition(16, 6);
            username = Console.ReadLine();
            return username;
        }

        public string EnterPassword()
        {
            Console.SetCursorPosition(16, 7);
            password = "";
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
