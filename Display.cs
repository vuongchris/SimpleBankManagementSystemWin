using System;
using System.Collections.Generic;
using System.Data.Common;

namespace SimpleBankManagementSystemWin
{
    /// <summary>
    /// Console GUI for Application
    /// </summary>
    public class Display
    {   
        public Display()
        {

        }
        /// <summary>
        /// Login Interface
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void LoginScreen(int x, int y, int width)
        {
            ClearScreen();
            Header("USER LOGIN", x, y, 2, width);
            AddBox(x, y + 2, 7, width);
            CentreText("Enter username and password", x, y + 4, width);
            WriteAt("Username:", x + 2, y + 6);
            WriteAt("Password:", x + 2, y + 7);
        }

        public void LoginSuccessMessage(int x, int y, int width)
        {
            AddBox(x, y, 2, width);
            SuccessMessage("Login Success! Press any key to continue...", x + 2, y + 1, width);
            Console.ReadKey();
        }

        public void LoginFailError(int x, int y, int width)
        {
            AddBox(x, y, 2, width);
            ErrorMessage("Incorrect Credentials! Please enter details again...", x + 2, y + 1, width);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Menu Interface
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void MenuScreen(int x, int y, int width)
        {
            int margin = x + ((width / 2) - (26 / 2));
            ClearScreen();
            Header("MAIN MENU", x, y, 2, width);
            AddBox(x, y + 2, 12, width);
            WriteAt("1. Create a new account", margin, y+4);
            WriteAt("2. Search for an account", margin, y+5);
            WriteAt("3. Deposit", margin, y+6);
            WriteAt("4. Withdraw", margin, y+7);
            WriteAt("5. A/C statment", margin, y+8);
            WriteAt("6. Delete Account", margin, y+9);
            WriteAt("7. Exit", margin, y+10);
            WriteAt("Enter your choice (1-7):", margin, y+12);
        }

        /// <summary>
        /// Create Account Interface
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void CreateAccountScreen(int x, int y, int width)
        {
            ClearScreen();
            Header("CREATE NEW ACCOUNT", x, y, 2, width);
            AddBox(x, y + 2, 10, width);
            CentreText("Enter details", x, y + 4, width);
            WriteAt("First Name:", x + 2, y + 6);
            WriteAt("Last Name:", x + 2, y + 7);
            WriteAt("Address:", x + 2, y + 8);
            WriteAt("Phone:", x + 2, y + 9);
            WriteAt("Email:", x + 2, y + 10);
        } 
        
        public void CreateSuccessScreen(int accountNumber, int x, int y, int width)
        {
            AddBox(x, y, 6, width);
            SuccessMessage("Account Created! Details will be provided via email.", 2, y+1,width);
            Message($"Account Number: {accountNumber}", x+2, y+2, width);
        }

        public void SearchSuccessScreen(int x, int y, int width)
        {
            SuccessMessage("Account Found!", x + 2, y, width);
            SuccessMessage("Account details are shown below.", x + 2, y + 1, width);
        }

        /// <summary>
        /// Asks the user to press any key to continue with application
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void ContinueMessage(int x, int y, int width)
        {
            ClearAt(x, y, width - 3);
            WriteAt("Press any key to continue...", x, y);
            Console.ReadKey();
        }

        /// <summary>
        /// Displays Account Details
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void DisplayDetails(string accountNumber, int x, int y, int width)
        {
            Account account = new Account(accountNumber);
            Console.ForegroundColor = ConsoleColor.White;
            AddBox(x, y, 10, width);
            WriteAt($"Account No: {account.AccountNumber}", x + 2, y + 2);
            WriteAt($"Account Balance: ${account.Balance}", x + 2, y + 3);
            WriteAt($"First Name: {account.FirstName}", x + 2, y + 4);
            WriteAt($"Last Name: {account.LastName}", x + 2, y + 5);
            WriteAt($"Address: {account.Address}", x + 2, y + 6);
            WriteAt($"Phone: {account.PhoneNumber}", x + 2, y + 7);
            WriteAt($"Email: {account.EmailAddress}", x + 2, y + 8);
        }


        /// <summary>
        /// Displays Transactions for Account
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void DisplayTransactions(string accountNumber, int x, int y, int width)
        {
            int counter;
            Account account = new Account(accountNumber);
            Console.ForegroundColor = ConsoleColor.White;
            
            AddBox(x, y, 10, width);
            CentreText("Last 5 Transactions", x, y + 2, width);
            
            List<(DateTime, string, double, double)> transactionHistory = account.TransactionHistory;
            transactionHistory.Reverse();
            
            if (transactionHistory.Count < 5)
            {
                counter = transactionHistory.Count;
            } else
            {
                counter = 5;
            }
            
            for (int i = 0; i < counter; i++)
            {
                WriteAt($"{transactionHistory[i].Item1} {transactionHistory[i].Item2} {transactionHistory[i].Item3} {transactionHistory[i].Item4}", x + 2, y + 4 + i);
            }
        }
        
        /// <summary>
        /// Interface used to input an account number and amount
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void AmountInputScreen(string s, int x, int y, int width)
        {
            ClearScreen();
            Header(s, x, y, 2, width);
            AddBox(x, y + 2, 7, width);
            CentreText("Enter details", x, y + 4, width);
            WriteAt("Account Number:", x + 2, y + 6);
            WriteAt("Amount: $", x + 2, y + 7);
        }

        /// <summary>
        /// Interface used to input an account number
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void AccountInputScreen(string s, int x, int y, int width)
        {
            ClearScreen();
            Header(s, x, y, 2, width);
            AddBox(x, y + 2, 6, width);
            CentreText("Enter details", x, y + 4, width);
            WriteAt("Account Number:", x + 2, y + 6);
        }

        /// <summary>
        /// Exit Menu Interface
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void ExitScreen(int x, int y, int width)
        {
            int margin = x + ((width / 2) - (26 / 2));
            ClearScreen();
            Header("EXIT OPTIONS", x, y, 2, width);
            AddBox(x, y + 2, 8, width);
            WriteAt("1. Logout", margin, y + 4);
            WriteAt("2. Exit Application", margin, y + 5);
            WriteAt("3. Return to Main Menu", margin, y + 6);
            WriteAt("Enter your choice (1-3):", margin, y + 8);
        }

        /// <summary>
        /// Message when exiting application
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void ExitMessage(int x, int y, int width)
        {
            AddBox(x, y, 3, width);
            Message("Exiting Application...", x + 2, y + 1, width);
            ContinueMessage(x + 2, y + 2, width);
        }

        /// <summary>
        /// Creates a box with centred title
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public void Header(string s, int x, int y, int height, int width)
        {
            Box(x, y, height, width);
            CentreText(s, x, y + 1, width);
        }

        /// <summary>
        /// Centres text
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void CentreText(string s, int x, int y, int width)
        {
            WriteAt(s, x + ((width / 2) - (s.Length / 2)), y);
        }

        public void ClearScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Displays when a successful action has occurred
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void SuccessMessage(string s, int x, int y, int width)
        {
            ClearAt(x, y, width - 3);
            Console.ForegroundColor = ConsoleColor.Green;
            WriteAt(s, x, y);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Displays when an unsuccessful action has occurred
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void ErrorMessage(string s, int x, int y, int width)
        {
            ClearAt(x, y, width - 3);
            Console.ForegroundColor = ConsoleColor.Red;
            WriteAt(s, x, y);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Displays when the application requires a response from the user
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public bool PromptMessage(string s, int x, int y, int width)
        {
            bool valid = false;
            ClearAt(x, y, width - 3);
            Console.ForegroundColor = ConsoleColor.White;
            WriteAt($"{s} (y/n)? ", x, y);
            string selection = Console.ReadLine();
            
            while (!valid)
            {
                if (selection == "y" || selection == "n" || selection == "Y" || selection == "N")
                {
                    break;
                }
                else
                {
                    ErrorMessage("Invalid Character! Please input (y/n)", x, y + 1, width);
                    ClearAt(x, y, width - 3);
                    WriteAt($"{s} (y/n)? ", x, y);
                    selection = Console.ReadLine();
                }
            }
            
            ContinueMessage(x, y + 1, width);
            
            if (selection == "y" || selection == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Displays a message to the user
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void Message(string s, int x, int y, int width)
        {
            ClearAt(x, y, width - 3);
            Console.ForegroundColor = ConsoleColor.White;
            WriteAt(s, x, y);
        }

        /// <summary>
        /// Creates a box with at (x,y)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public void Box(int x, int y, int height, int width)
        {
            HorizontalLine(x + 1, y, width - 1);
            HorizontalLine(x + 1, y + height, width - 1);
            VerticalLine(x, y + 1, height - 1);
            VerticalLine(x + width, y + 1, height - 1);
            Corners(x, y, x+width, y+height);

        }

        /// <summary>
        /// Adds a box below another box
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public void AddBox(int x, int y, int height, int width)
        {
            Box(x, y, height, width);

            WriteAt("├", x, y);
            WriteAt("┤", x + width, y);
        }

        /// <summary>
        /// Draws a horizontal line at (x,y) 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void HorizontalLine(int x, int y, int width)
        {
            for (int i = x; i <= x + width; i++)
            {
                WriteAt("─", i, y);
            }
        }

        /// <summary>
        /// Draws a vertical line at (x,y)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="height"></param>
        public void VerticalLine(int x, int y, int height)
        {
            for (int i = y; i <= y + height; i++)
            {
                WriteAt("│", x, i);
            }
        }

        /// <summary>
        /// Draws corners of a box
        /// </summary>
        /// <param name="topLeftX"></param>
        /// <param name="topLeftY"></param>
        /// <param name="bottomRightX"></param>
        /// <param name="bottomRightY"></param>
        public void Corners(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
        {
            WriteAt("┌", topLeftX, topLeftY);
            WriteAt("└", topLeftX, bottomRightY);
            WriteAt("┐", bottomRightX, topLeftY);
            WriteAt("┘", bottomRightX, bottomRightY);
        }

        /// <summary>
        /// Clears a line at (x,y)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void ClearAt(int x, int y, int width)
        {
            for (int i = x; i <= x + width; i++)
            {
                WriteAt(" ", i, y);
            }
        }

        /// <summary>
        /// Writes a string at (x,y)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }


    }
}

