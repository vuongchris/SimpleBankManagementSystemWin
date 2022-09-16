using System;

namespace SimpleBankManagementSystemWin
{
    class Program
    {
        static void Main(string[] args)
        {
            Display display = new Display();
            Input input = new Input();
            Login login = new Login();
            Menu menu = new Menu();


            bool exitApp = false;
            while (!exitApp)
            {
                login.UserLogin();
                bool exitMenu = false;
                while (!exitMenu)
                {
                    display.MenuScreen();
                    string selection = input.StringInput(41, 12);
                    switch (selection)
                    {
                        case "1":
                            menu.CreateAccount();
                            break;
                        case "2":
                            menu.SearchAccount();
                            break;
                        case "3":
                            menu.AccountDeposit();
                            break;
                        case "4":
                            menu.AccountWithdraw();
                            break;
                        case "5":
                            menu.AccountStatement();
                            break;
                        case "6":
                            menu.DeleteAccount();
                            break;
                        case "7":
                            display.ExitScreen();
                            string exitSelection = input.StringInput(35, 8);
                            switch (exitSelection)
                            {
                                case "1":
                                    exitMenu = true;
                                    break;
                                case "2":
                                    exitMenu = true;
                                    exitApp = true;
                                    break;
                                case "3":
                                    break;
                                default:
                                    exitSelection = input.StringInput(35, 8);
                                    break;
                            }
                            break;
                        default:
                            selection = input.StringInput(35, 12);
                            break;
                    }
                }
            }
        }
    }
}
