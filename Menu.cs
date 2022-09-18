using System;
using System.IO;

namespace SimpleBankManagementSystemWin
{
    public class Menu
    {
        Account account;
        Display display;
        Email email;
        Input input;
        string directory;
        string accountNumber, selection;
        bool retry, foundAccount, sendEmail, delete, correctInfo;

        public Menu()
        {
            display = new Display();
            email = new Email();
            input = new Input();
            directory = Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// Logic for Creating Account
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void CreateAccount(int x, int y, int width)
        {
            retry = true;
            while (retry)
            {
                display.CreateAccountScreen(x, y, width);

                string firstName = input.StringInput(x + 16, y + 6, width);
                string lastName = input.StringInput(x + 15, y + 7, width);
                string address = input.StringInput(x + 13, y + 8, width);
                string phoneNumber = input.StringInput(x + 11, y + 9, width);
                string emailAddress = input.StringInput(x + 11, y + 10, width);

                display.AddBox(x, y + 12, 6, width);
                correctInfo = display.PromptMessage("Is the information correct", x + 2, y + 13, width);

                if (correctInfo)
                {
                    if (firstName.Length > 0 && lastName.Length > 0 && address.Length > 0 && phoneNumber.Length > 0 && emailAddress.Length > 0)
                    {
                        if (!input.ValidateInt(phoneNumber))
                        {
                            display.ErrorMessage("Invalid Phone Number! Must be numbers only (0-9)", x + 2, y + 13, width);
                            retry = display.PromptMessage("Retry", x + 2, y + 14, width);
                        }
                        else
                        {
                            if (!input.ValidateLength(phoneNumber, 10))
                            {
                                display.ErrorMessage("Invalid Phone Length! Cannot exceed 10 digits", x + 2, y + 13, width);
                                retry = display.PromptMessage("Retry", x + 2, y + 14, width);
                            }
                            else
                            {
                                if (!input.ValidateEmailFormat(emailAddress))
                                {
                                    display.ErrorMessage("Invalid Email Format!", x + 2, y + 13, width);
                                    retry = display.PromptMessage("Retry", x + 2, y + 14, width);
                                } else
                                {
                                    if (!input.ValidateEmail(emailAddress))
                                    {
                                        display.ErrorMessage("Email Address Does Not Exist!", x + 2, y + 13, width);
                                        retry = display.PromptMessage("Retry", x + 2, y + 14, width);
                                    }
                                    else
                                    {
                                        CreateAccountFile(firstName, lastName, address, phoneNumber, emailAddress, x, y + 12, width);
                                        retry = display.PromptMessage("Create Another Account", x + 2, y + 16, width);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        display.ErrorMessage("All Fields Must Be Filled!", x + 2, y + 13, width);
                        retry = display.PromptMessage("Retry", x + 2, y + 14, width);
                    }
                } else
                {
                    retry = display.PromptMessage("Retry", x + 2, y + 14, width);
                }
            }
        }

        /// <summary>
        /// Combines all user inputs from CreateAccount() into a text file
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="emailAddress"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void CreateAccountFile(string firstName, string lastName, string address, string phoneNumber, string emailAddress, int x, int y, int width)
        {
            int accountNumber = NextAvailableNumber();
            
            string[] lines = {
                $"First Name|{firstName}", $"Last Name|{lastName}", $"Address|{address}", $"Phone|{phoneNumber}", $"Email|{emailAddress}", $"Account|{accountNumber}", $"Balance|0"
            };
            
            try
            {
                File.WriteAllLines($@"{directory}\\Accounts\\{accountNumber}.txt", lines);
                display.CreateSuccessScreen(accountNumber, x, y, width);
                email.SendEmail(accountNumber.ToString(), x + 2, y + 3, width);
            } 
            catch (FileNotFoundException)
            {
                display.ErrorMessage("Account File Could Not Be Created!", x, y, width);
            }
        }

        /// <summary>
        /// Find the next number that is not used as an account number
        /// </summary>
        /// <returns> int </returns>
        public int NextAvailableNumber()
        {
            for (int i = 100001; i < 100000000; i++)
            {
                if (!File.Exists($@"{directory}\\Accounts\\{i}.txt"))
                {
                    return i;
                }
            }
            return 0;
        }

        /// <summary>
        /// Logic for Search Account
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void SearchAccount(int x, int y, int width)
        {
            retry = true;
            while (retry)
            {
                display.AccountInputScreen("SEARCH FOR ACCOUNT", x, y, width);
                accountNumber = input.StringInput(x + 18, y + 6, width);
                foundAccount = FindAccount(accountNumber, x, y + 8, width);

                if (foundAccount)
                {
                    display.SearchSuccessScreen(x, y + 9, width);
                    display.DisplayDetails(accountNumber, x, y + 12, width);
                    display.AddBox(x, y + 22, 3, width);
                    retry = display.PromptMessage("Check another account", x + 2, y + 23, width);
                }
                else
                {
                    retry = display.PromptMessage("Retry", x + 2, y + 10, width);
                }
            }
        }

        /// <summary>
        /// Logic for Deposit Account
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void AccountDeposit(int x, int y, int width)
        {
            retry = true;
            while (retry)
            {
                display.AmountInputScreen("DEPOSIT", x, y, width);
                accountNumber = input.StringInput(x + 18, y + 6, width);
                foundAccount = FindAccount(accountNumber, x, y + 9, width);

                if (foundAccount)
                {
                    display.SuccessMessage("Account Found! Enter amount", x + 2, y + 10, width);
                    account = new Account(accountNumber);
                    string stringBalance = input.StringInput(x + 12, y + 7, width);
                    
                    if (!input.ValidateDouble(stringBalance))
                    {
                        display.ErrorMessage("Invalid Amount! Must be numbers only (0-9)", x + 2, y + 10, width);
                        retry = display.PromptMessage("Retry", x + 2, y + 11, width);
                    }
                    else
                    {
                       
                        double balance = Convert.ToDouble(stringBalance);
                        if (balance <= 0)
                        {
                            display.ErrorMessage("Deposit Amount Cannot Be 0 or Negative!", x + 2, y + 10, width);
                            retry = display.PromptMessage("Retry", x + 2, y + 11, width);
                        }
                        else
                        {
                            account.Deposit(balance);
                            display.SuccessMessage("Deposit Successful!", x + 2, y + 10, width);
                            retry = display.PromptMessage("Deposit another account", x + 2, y + 11, width);
                        }
                    }
                } else
                {
                    retry = display.PromptMessage("Retry", x + 2, y + 11, width);
                }
            }
        }
        /// <summary>
        /// Logic for Withdraw Account
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void AccountWithdraw(int x, int y, int width)
        {
            retry = true;
            while (retry)
            {
                display.AmountInputScreen("WITHDRAW", x, y, width);
                accountNumber = input.StringInput(x + 18, y + 6, width);
                foundAccount = FindAccount(accountNumber, x, y + 9, width);
                if (foundAccount)
                {
                    display.SuccessMessage("Account Found! Enter amount", x + 2, y + 10, width);
                    account = new Account(accountNumber);
                    string stringBalance = input.StringInput(x + 12, y + 7, width);
                    if (!input.ValidateDouble(stringBalance))
                    {
                        display.ErrorMessage("Invalid Amount! Must be numbers only (0-9)", x + 2, y + 10, width);
                        retry = display.PromptMessage("Retry", x + 2, y + 11, width);
                    }
                    else
                    {
                        double balance = Convert.ToDouble(stringBalance);
                        if (balance <= 0)
                        {
                            display.ErrorMessage("Withdraw Amount Cannot Be 0 or Negative!", x + 2, y + 10, width);
                            retry = display.PromptMessage("Retry", x + 2, y + 11, width);
                        }
                        else
                        {
                            if (account.Balance - balance < 0)
                            {
                                display.ErrorMessage("Withdraw Failed! Unsufficient Funds To Withdraw", x + 2, y + 10, width);
                                retry = display.PromptMessage("Retry", x + 2, y + 11, width);
                            }
                            else
                            {
                                account.Withdraw(balance);
                                display.SuccessMessage("Withdraw Successful!", x + 2, y + 10, width);
                                retry = display.PromptMessage("Withdraw another account", x + 2, y + 11, width);
                            }
                        }
                    }
                }
                else
                {
                    retry = display.PromptMessage("Retry", x + 2, y + 11, width);
                }
            }
        }
        /// <summary>
        /// Logic for Account Statement
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void AccountStatement(int x, int y, int width)
        {
            retry = true;
            while (retry)
            {
                display.AccountInputScreen("STATEMENT", x, y, width);
                accountNumber = input.StringInput(x + 18, y + 6, width);
                foundAccount = FindAccount(accountNumber, x, y + 8, width);

                if (foundAccount)
                {
                    display.SuccessMessage("Account Found!", x + 2, y + 9, width);
                    display.SuccessMessage("Statement is shown below.", x + 2, y + 10, width);
                    display.AddBox(x, y + 12, 2, width);
                    display.CentreText("ACCOUNT STATEMENT", x, y + 13, width);
                    display.DisplayDetails(accountNumber, x, y + 14, width);
                    display.DisplayTransactions(accountNumber, x, y + 24, width);
                    display.AddBox(x, y + 34, 4, width);
                    sendEmail = display.PromptMessage("Send statement to Email", x + 2, y + 35, width);
                    
                    if (sendEmail)
                    {
                        email.SendEmail(accountNumber, x + 2, y + 35, width);
                    }
                    retry = display.PromptMessage("Check another account", x + 2, y + 36, width);
                }
                else
                {
                    retry = display.PromptMessage("Retry", x + 2, y + 10, width);
                }
            }
        }
        /// <summary>
        /// Logic for Delete Account
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void DeleteAccount(int x, int y, int width)
        {
            retry = true;
            while (retry)
            {
                display.AccountInputScreen("DELETE ACCOUNT", x, y, width);
                accountNumber = input.StringInput(x + 18, y + 6, width);
                foundAccount = FindAccount(accountNumber, x, y + 8, width);
                
                if (foundAccount)
                {
                    display.SearchSuccessScreen(x, y + 9, width);
                    display.DisplayDetails(accountNumber, x, y + 12, width);
                    display.AddBox(x, y + 22, 4, width);
                    delete = display.PromptMessage("Delete", x + 2, y + 23, width);
                    
                    if (delete)
                    {
                        DeleteAccountFile(accountNumber, x + 2, y + 23, width);
                    }
                    
                    retry = display.PromptMessage("Delete another account", x + 2, y + 24, width);
                }
                else
                {
                    retry = display.PromptMessage("Retry", x + 2, y + 10, width);
                }
            }
        }
        /// <summary>
        /// Checks if an account file exists
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public bool FindAccount(string accountNumber, int x, int y, int width)
        {
            display.AddBox(x, y, 4, width);
            if (!input.ValidateInt(accountNumber))
            {
                display.ErrorMessage("Invalid Account Number! Must be an integer", x + 2, y + 1, width);
                return false;
            }
            else
            {
                if (!input.ValidateLength(accountNumber, 10))
                {
                    display.ErrorMessage("Invalid Account Length! Cannot exceed 10 digits", x + 2, y + 1, width);
                    return false;
                }
                else
                {
                    if (CheckAccountFile(accountNumber, x + 2, y + 1, width))
                    {
                        return true;
                    } else
                    {
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Check if Account File Exists
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public bool CheckAccountFile(string accountNumber, int x, int y, int width)
        {
            try
            {
                if (File.Exists($@"{directory}\\Accounts\\{accountNumber}.txt"))
                {
                    return true;
                }
                else
                {
                    display.ErrorMessage("Account File Not Found!", x, y, width);
                    return false;
                }
            } catch (FileNotFoundException)
            {
                display.ErrorMessage("Account File Not Found!", x, y, width);
                return false;
            }
        }

        /// <summary>
        /// Check if the file exists then delete it
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public void DeleteAccountFile(string accountNumber, int x, int y, int width)
        {
            try
            {
                if (File.Exists($@"{directory}\\Accounts\\{accountNumber}.txt"))
                {
                    File.Delete($@"{directory}\\Accounts\\{accountNumber}.txt");
                    display.SuccessMessage("Account Deleted!", x, y, width);
                }
                else
                {
                    display.ErrorMessage("Account Could Not Deleted!", x, y, width);
                }
            } catch (FileNotFoundException)
            {
                display.ErrorMessage("Account Could Not Deleted!", x, y, width);
            }
        }

        /// <summary>
        /// Menu Selection
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public string MenuSelection(int x, int y, int width)
        {
            bool retry = true;
            while (retry)
            {
                selection = input.StringInput(x + 43, y, width);
                if (selection == "1" || selection == "2" || selection == "3" || selection == "4" || selection == "5" || selection == "6" || selection == "7")
                {
                    retry = false;
                } else
                {
                    display.AddBox(x, y + 2, 2, width);
                    display.ErrorMessage("Must input integers between 1-7!", x + 2, y + 3, width);
                }
            }
            return selection;
        }

        public string ExitSelection(int x, int y, int width)
        {
            bool retry = true;
            while (retry)
            {
                selection = input.StringInput(x + 43, y, width);
                if (selection == "1" || selection == "2" || selection == "3")
                {
                    retry = false;
                }
                else
                {
                    display.AddBox(x, y + 2, 2, width);
                    display.ErrorMessage("Must input integers between 1-3!", x + 2, y + 3, width);
                }
            }
            return selection;
        }
    }
}

