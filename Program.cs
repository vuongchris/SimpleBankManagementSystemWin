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

            int topLeftX = 0;
            int topLeftY = 0;
            int width = 62;

            bool exitApp = false;
            while (!exitApp)
            {
                login.UserLogin(topLeftX, topLeftY, width);
                bool exitMenu = false;
                
                while (!exitMenu)
                {
                    display.MenuScreen(topLeftX, topLeftY, width);

                    string selection = menu.MenuSelection(topLeftX, topLeftY + 12, width);
                    switch (selection)
                    {
                        case "1":
                            menu.CreateAccount(topLeftX, topLeftY, width);
                            break;
                        case "2":
                            menu.SearchAccount(topLeftX, topLeftY, width);
                            break;
                        case "3":
                            menu.AccountDeposit(topLeftX, topLeftY, width);
                            break;
                        case "4":
                            menu.AccountWithdraw(topLeftX, topLeftY, width);
                            break;
                        case "5":
                            menu.AccountStatement(topLeftX, topLeftY, width);
                            break;
                        case "6":
                            menu.DeleteAccount(topLeftX, topLeftY, width);
                            break;
                        case "7":
                            display.ExitScreen(topLeftX, topLeftY, width);
                            string exitSelection = menu.ExitSelection(topLeftX, topLeftY + 8, width);
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
                                    exitMenu = false;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            display.ExitMessage(topLeftX, topLeftY + 10, width);
        }
    }
}
