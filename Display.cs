using System;
using System.Data.Common;

namespace SimpleBankManagementSystemWin
{
    public class Display
    {
        public Display()
        {

        }

        public void LoginScreen()
        {
            ClearScreen();
            Header("USER LOGIN", 60);
            AddBox(6, 60, 2);
            CentreText("Enter username and password", 60, 4);
            WriteAt("Username:", 2, 6);
            WriteAt("Password:", 2, 7);
        }

        public void LoginSuccessMessage()
        {
            AddBox(1, 60, 9);
            ClearAt(10, 1, 60);
            SuccessMessage("Login Success! Press any key to continue...", 2, 10);
            Console.ReadKey();
        }

        public void LoginFailError()
        {
            AddBox(1, 60, 9);
            ClearAt(6, 12, 60);
            ClearAt(7, 12, 60);
            ClearAt(10, 1, 60);
            ErrorMessage("Incorrect Credentials! Please enter details again...", 2, 10);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void MenuScreen()
        {
            ClearScreen();
            Header("MAIN MENU", 60);
            AddBox(11, 60, 2);
            WriteAt("1. Create a new account", 16, 4);
            WriteAt("2. Search for an account", 16, 5);
            WriteAt("3. Deposit", 16, 6);
            WriteAt("4. Withdraw", 16, 7);
            WriteAt("5. A/C statment", 16, 8);
            WriteAt("6. Delete Account", 16, 9);
            WriteAt("7. Exit", 16, 10);
            WriteAt("Enter your choice (1-7):", 16, 12);
        }

        public void CreateAccountScreen()
        {
            ClearScreen();
            Header("CREATE NEW ACCOUNT", 60);
            AddBox(9, 60, 2);
            CentreText("Enter details", 60, 4);
            WriteAt("First Name:", 2, 6);
            WriteAt("Last Name:", 2, 7);
            WriteAt("Address:", 2, 8);
            WriteAt("Phone:", 2, 9);
            WriteAt("Email:", 2, 10);
        }

        public void CreateSuccessScreen(int accountNumber)
        {
            AddBox(3, 60, 12);
            ClearAt(13, 1, 60);
            ClearAt(14, 1, 60);
            ClearAt(15, 1, 60);
            SuccessMessage("Account Created! Details will be provided via email.", 2, 13);
            Message($"Account Number: {accountNumber}", 2, 14);
            Message("Press any key to return to Main Menu...", 2, 15);
            Console.ReadKey();
        }

        public void SearchScreen()
        {
            ClearScreen();
            Header("SEARCH FOR ACCOUNT", 60);
            AddBox(5, 60, 2);
            CentreText("Enter account number", 60, 4);
            WriteAt("Account Number:", 2, 6);

        }

        public void SearchSuccessScreen()
        {
            AddBox(3, 60, 8);
            SuccessMessage("Account Found!", 2, 9);
            SuccessMessage("Account details are shown below.", 2, 10);
        }

        public void ContinueMessage(int x, int y)
        {
            ClearAt(y, 1, 60);
            WriteAt("Press any key to continue...", x, y);
            Console.ReadKey();
        }

        public void DisplayDetails(string accountNumber, int y)
        {
            Account account = new Account(accountNumber);
            Console.ForegroundColor = ConsoleColor.White;
            AddBox(9, 60, y);
            WriteAt($"Account No: {account.AccountNumber}", 2, y + 2);
            WriteAt($"Account Balance: ${account.Balance}", 2, y + 3);
            WriteAt($"First Name: {account.FirstName}", 2, y + 4);
            WriteAt($"Last Name: {account.LastName}", 2, y + 5);
            WriteAt($"Address: {account.Address}", 2, y + 6);
            WriteAt($"Phone: {account.PhoneNumber}", 2, y + 7);
            WriteAt($"Email: {account.EmailAddress}", 2, y + 8);
        }


        public void DisplayTransactions(string accountNumber)
        {
            Account account = new Account(accountNumber);
            Console.ForegroundColor = ConsoleColor.White;

        }

        public void DepositScreen()
        {
            ClearScreen();
            Header("DEPOSIT", 60);
            AddBox(6, 60, 2);
            CentreText("Enter details", 60, 4);
            WriteAt("Account Number:", 2, 6);
            WriteAt("Amount: $", 2, 7);
        }

        public void EnterAmountMessage()
        {
            AddBox(2, 60, 9);
            SuccessMessage("Account Found! Enter the amount...", 2, 10);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DepositSuccessScreen()
        {
            SuccessMessage("Deposit Successful!", 2, 11);
        }

        public void DepositErrorMessage(string error)
        {
            ErrorMessage($"Deposit Failed! {error}", 2, 11);
        }

        public void WithdrawScreen()
        {
            ClearScreen();
            Header("WITHDRAW", 60);
            AddBox(6, 60, 2);
            CentreText("Enter details", 60, 4);
            WriteAt("Account Number:", 2, 6);
            WriteAt("Amount: $", 2, 7);
        }

        public void WithdrawSuccessScreen()
        {
            SuccessMessage("Withdraw Successful!", 2, 11);
        }

        public void WithdrawErrorMessage(string error)
        {
            ErrorMessage($"Withdrawal Failed! {error}", 2, 11);
        }

        public void StatementScreen()
        {
            ClearScreen();
            Header("STATEMENT", 60);
            AddBox(5, 60, 2);
            CentreText("Enter details", 60, 4);
            WriteAt("Account Number:", 2, 6);
        }

        public void StatementError(string error)
        {
            AddBox(2, 60, 8);
            ErrorMessage($"Account Not Found! {error}", 20, 9);
        }


        public void StatementSuccessScreen()
        {
            AddBox(2, 60, 8);
            SuccessMessage("Account Found! Statement is displayed below...", 2, 9);
            AddBox(1, 60, 21);
            PromptMessage("Email Statement", 6, 10);
        }

        public void DeleteAccountScreen()
        {
            ClearScreen();
            Header("DELETE ACCOUNT", 60);
            AddBox(5, 60, 2);
            CentreText("Enter details", 60, 4);
            WriteAt("Account Number:", 2, 6);
        }

        public void DeleteSuccessScreen()
        {
            AddBox(2, 60, 8);
            SuccessMessage("Account Found! Details are displayed below...", 2, 9);
            AddBox(1, 60, 21);
            PromptMessage("Delete", 2, 10);
        }

        public void ExitScreen()
        {
            ClearScreen();
            Header("EXIT OPTIONS", 60);
            WriteAt("1. Logout", 10, 4);
            WriteAt("2. Return to Main Menu", 10, 5);
            WriteAt("3. Exit Application", 10, 6);
            WriteAt("Enter your choice (1-3):", 10, 8);
        }

        public void Header(string s, int width)
        {
            Box(1, width);
            WriteAt(s, (width / 2) - (s.Length / 2), 1);
        }

        public void CentreText(string s, int width, int row)
        {
            WriteAt(s, (width / 2) - (s.Length / 2), row);
        }

        public void ClearScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void SuccessMessage(string s, int x, int y)
        {
            ClearAt(y, 1, 60);
            Console.ForegroundColor = ConsoleColor.Green;
            WriteAt(s, x, y);
        }

        public void ErrorMessage(string s, int x, int y)
        {
            ClearAt(y, 1, 60);
            Console.ForegroundColor = ConsoleColor.Red;
            WriteAt(s, x, y);
        }

        public bool PromptMessage(string s, int x, int y)
        {
            bool valid = false;
            ClearAt(y, 1, 60);
            Console.ForegroundColor = ConsoleColor.White;
            WriteAt($"{s} (y/n)? ", x, y);
            string selection = Console.ReadLine();
            while (!valid)
            {
                if (selection == "y" || selection == "n")
                {
                    break;
                }
                else
                {
                    ErrorMessage("Invalid Character! Please input (y/n)", x, y + 1);
                    ClearAt(y, 1, 60);
                    Console.ForegroundColor = ConsoleColor.White;
                    WriteAt($"{s} (y/n)? ", x, y);
                    selection = Console.ReadLine();
                }
            }
            ContinueMessage(x, y + 1);
            if (selection == "y")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void Message(string s, int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.White;
            WriteAt(s, x, y);
        }

        public void Box(int height, int width)
        {
            HorizontalLine(0, 1, width);
            HorizontalLine(height + 1, 1, width);
            VerticalLine(0, 1, height);
            VerticalLine(width + 1, 1, height);
            Corners(0, 0, width + 1, height + 1);

        }

        public void AddBox(int height, int width, int row)
        {
            HorizontalLine(row, 1, width);
            HorizontalLine(row + height + 1, 1, width);
            VerticalLine(0, row + 1, row + height);
            VerticalLine(width + 1, row + 1, row + height);

            WriteAt("├", 0, row);
            WriteAt("┤", width + 1, row);

            WriteAt("└", 0, height + row + 1);
            WriteAt("┘", width + 1, height + row + 1);
        }

        public void HorizontalLine(int row, int startCol, int endCol)
        {
            for (int i = startCol; i <= endCol; i++)
            {
                WriteAt("─", i, row);
            }
        }

        public void HorizontalLine(string s, int row, int startCol, int endCol)
        {
            for (int i = startCol; i <= endCol; i++)
            {
                WriteAt(s, i, row);
            }
        }

        public void VerticalLine(int column, int startRow, int endRow)
        {
            for (int i = startRow; i <= endRow; i++)
            {
                WriteAt("│", column, i);
            }
        }

        public void VerticalLine(string s, int column, int startRow, int endRow)
        {
            for (int i = startRow; i <= endRow; i++)
            {
                WriteAt(s, column, i);
            }
        }

        public void Corners(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
        {
            WriteAt("┌", topLeftX, topLeftY);
            WriteAt("└", topLeftX, bottomRightY);
            WriteAt("┐", bottomRightX, topLeftY);
            WriteAt("┘", bottomRightX, bottomRightY);
        }


        public void ClearAt(int row, int startCol, int endCol)
        {
            for (int i = startCol; i <= endCol; i++)
            {
                WriteAt(" ", i, row);
            }
        }

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

