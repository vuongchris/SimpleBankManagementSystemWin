using System;

namespace SimpleBankManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Display display = new Display();
            Login login = new Login();
            Menu menu = new Menu();
            Validator validator = new Validator();

            display.LoginScreen();
            string username = login.EnterUsername();
            string password = login.EnterPassword();

            while (!login.CheckCredentials(username, password))
            {
                display.LoginFailError();
                username = login.EnterUsername();
                password = login.EnterPassword();
            }
            display.LoginSuccessMessage();
            display.MenuScreen();
            bool exitMenu = false;
            while (!exitMenu)
            {
                display.MenuScreen();
                string selection = menu.MenuSelection();
                switch (selection)
                {
                    case "1":
                        display.CreateAccountScreen();
                        menu.CreateAccount();
                        display.CreateAccountConfirmation();
                        Console.ReadKey();
                        display.CreateSuccessScreen();
                        break;
                    case "2":
                        display.SearchScreen();
                        Console.ReadKey();
                        break;
                    case "3":
                        display.DepositScreen();
                        Console.ReadKey();
                        break;
                    case "4":
                        display.WithdrawScreen();
                        Console.ReadKey();
                        break;
                    case "5":
                        display.StatementScreen();
                        Console.ReadKey();
                        break;
                    case "6":
                        display.DeleteAccountScreen();
                        Console.ReadKey();
                        break;
                    default:
                        selection = menu.MenuSelection();
                        break;
                }
            }

        }
    }
}
