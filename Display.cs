using System;
using System.Data.Common;

namespace SimpleBankManagementSystem
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
            WriteAt("Username:", 6, 6);
            WriteAt("Password:", 6, 7);
        }

        public void LoginSuccessMessage()
        {
            AddBox(1, 60, 9);
            ClearAt(10, 1, 60);
            SuccessMessage("Login Success! Press any key to continue...", 6, 10);
            Console.ReadKey();
        }

        public void LoginFailError()
        {
            AddBox(1, 60, 9);
            ClearAt(6, 16, 60);
            ClearAt(7, 16, 60);
            ClearAt(10, 1, 60);
            ErrorMessage("Incorrect Credentials, Please enter details again...", 6, 10);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void MenuScreen()
        {
            ClearScreen();
            Header("MAIN MENU", 60);
            AddBox(11, 60, 2);
            WriteAt("1. Create a new account", 10, 4);
            WriteAt("2. Search for an account", 10, 5);
            WriteAt("3. Deposit", 10, 6);
            WriteAt("4. Withdraw", 10, 7);
            WriteAt("5. A/C statment", 10, 8);
            WriteAt("6. Delete Account", 10, 9);
            WriteAt("7. Exit", 10, 10);
            WriteAt("Enter your choice (1-7):", 10, 12);
        }

        public void CreateAccountScreen()
        {
            ClearScreen();
            Header("CREATE NEW ACCOUNT", 60);
            AddBox(9, 60, 2);
            CentreText("Enter details", 60, 4);
            WriteAt("First Name:", 6, 6);
            WriteAt("Last Name:", 6, 7);
            WriteAt("Address:", 6, 8);
            WriteAt("Phone:", 6, 9);
            WriteAt("Email:", 6, 10);
        }

        public void CreateAccountConfirmation()
        {
            AddBox(1, 60, 12);
            PromptMessage("Is the information correct", 6, 13);
        }

        public void CreateSuccessScreen()
        {
            AddBox(3, 60, 14);
            SuccessMessage("Account Created! Details will be provided via email.", 6, 15);
            SuccessMessage("Account Number:", 6, 16);
            SuccessMessage("Press any key to continue...", 6, 17);
            Console.ReadKey();
        }

        public void SearchScreen()
        {
            ClearScreen();
            Header("SEARCH FOR ACCOUNT", 60);
            AddBox(5, 60, 2);
            CentreText("Enter account number", 60, 4);
            WriteAt("Account Number:", 6, 6);

        }

        public void SearchFailError()
        {
            AddBox(2, 60, 8);
            ErrorMessage("Account Not Found!", 6, 9);
            PromptMessage("Check another account", 6, 10);
        }

        public void SearchSuccessScreen()
        {
            AddBox(2, 60, 8);
            SuccessMessage("Account Found!", 6, 9);
            SuccessMessage("Account details are shown below.", 6, 10);
        }

        public void DisplayDetails()
        {
            Console.ForegroundColor = ConsoleColor.White;
            AddBox(9, 60, 11);
            WriteAt("Account No:", 6, 13);
            WriteAt("Account Balance:", 6, 14);
            WriteAt("First Name:", 6, 15);
            WriteAt("Last Name:", 6, 16);
            WriteAt("Address:", 6, 17);
            WriteAt("Phone:", 6, 18);
            WriteAt("Email:", 6, 19);
        }

        public void DepositScreen()
        {
            ClearScreen();
            Header("DEPOSIT", 60);
            AddBox(6, 60, 2);
            CentreText("Enter details", 60, 4);
            WriteAt("Account Number:", 6, 6);
            WriteAt("Amount:", 6, 7);
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
            WriteAt("Account Number:", 6, 6);
            WriteAt("Amount: $", 6, 7);
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
            WriteAt("Account Number:", 6, 6);
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
            DisplayDetails();
            AddBox(1, 60, 21);
            PromptMessage("Email Statement", 6, 10);
        }

        public void DeleteAccountScreen()
        {
            ClearScreen();
            Header("DELETE ACCOUNT", 60);
            AddBox(5, 60, 2);
            CentreText("Enter details", 60, 4);
            WriteAt("Account Number:", 6, 6);
        }

        public void DeleteSuccessScreen()
        {
            AddBox(2, 60, 8);
            SuccessMessage("Account Found! Details are displayed below...", 2, 9);
            DisplayDetails();
            AddBox(1, 60, 21);
            PromptMessage("Delete", 6, 10);
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
            Console.ForegroundColor = ConsoleColor.Green;
            WriteAt(s, x, y);
        }

        public void ErrorMessage(string s, int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            WriteAt(s, x, y);
        }

        public void PromptMessage(string s, int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.White;
            WriteAt($"{s} (y/n)?", x, y);
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

