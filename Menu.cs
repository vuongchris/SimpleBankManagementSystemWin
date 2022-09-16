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
        string accountNumber;

        public Menu()
        {
            display = new Display();
            email = new Email();
            input = new Input();
            directory = Directory.GetCurrentDirectory();
        }

        public void CreateAccount()
        {
            bool retry = true;
            while (retry)
            {
                display.CreateAccountScreen();

                string firstName = input.StringInput(16, 6);
                string lastName = input.StringInput(15, 7);
                string address = input.StringInput(13, 8);
                string phoneNumber = input.StringInput(11, 9);
                string emailAddress = input.StringInput(11, 10);

                display.AddBox(3, 60, 12);
                bool correctInfo = display.PromptMessage("Is the information correct", 2, 13);
                
                if (correctInfo)
                {
                    if (firstName.Length > 0 && lastName.Length > 0 && address.Length > 0 && phoneNumber.Length > 0 && emailAddress.Length > 0)
                    {
                        if (!input.ValidateInt(phoneNumber))
                        {
                            display.ErrorMessage("Invalid Phone Number! Must be numbers only (0-9)", 2, 13);
                            retry = display.PromptMessage("Retry", 2, 14);
                        }
                        else
                        {
                            if (!input.ValidateLength(phoneNumber, 10))
                            {
                                display.ErrorMessage("Invalid Phone Length! Cannot exceed 10 digits", 2, 13);
                                retry = display.PromptMessage("Retry", 2, 14);
                            }
                            else
                            {
                                if (!input.ValidateEmail(emailAddress))
                                {
                                    display.ErrorMessage("Invalid Email Address!", 2, 13);
                                    retry = display.PromptMessage("Retry", 2, 14);
                                }
                                else
                                {
                                    CreateAccountFile(firstName, lastName, address, phoneNumber, emailAddress);
                                    retry = false;
                                }
                            }
                        }
                    } else
                    {
                        display.ErrorMessage("All Fields Must Be Filled!", 2, 13);
                        retry = display.PromptMessage("Retry", 2, 14);
                    }
                }
                else
                {
                    retry = display.PromptMessage("Retry", 2, 14);
                }
            }
        }

        // Combines all user inputs from CreateAccount() into a new text file
        public void CreateAccountFile(string firstName, string lastName, string address, string phoneNumber, string emailAddress)
        {
            int accountNumber = NextAvailableNumber();
            string[] lines = {
                $"First Name|{firstName}", $"Last Name|{lastName}", $"Address|{address}", $"Phone|{phoneNumber}", $"Email|{emailAddress}", $"Account|{accountNumber}", $"Balance|0"
            };

            File.WriteAllLines($@"{directory}\\Accounts\\{accountNumber}.txt", lines);

            display.CreateSuccessScreen(accountNumber);
        }

        // Finds the next account number that is not in use
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

        public void SearchAccount()
        {
            bool retry = true;
            while (retry)
            {
                display.SearchScreen();
                accountNumber = input.StringInput(22, 6);
                display.AddBox(3, 60, 8);
                if (!input.ValidateInt(accountNumber))
                {
                    display.ErrorMessage("Invalid Account Number! Must be numbers only (0-9)", 2, 9);
                    retry = display.PromptMessage("Retry", 2, 10);
                } 
                else
                {
                    if (!input.ValidateLength(accountNumber, 10))
                    {
                        display.ErrorMessage("Invalid Account Length! Cannot exceed 10 digits", 2, 9);
                        retry = display.PromptMessage("Retry", 2, 10);
                    }
                    else
                    {
                        if (File.Exists($@"{directory}\\Accounts\\{accountNumber}.txt"))
                        {
                            display.SearchSuccessScreen();
                            display.DisplayDetails(accountNumber, 12);
                            display.AddBox(2, 60, 22);
                            retry = display.PromptMessage("Check another account", 2, 23);
                        }
                        else
                        {
                            display.ErrorMessage("Account File Not Found!", 2, 9);
                            retry = display.PromptMessage("Retry", 2, 10);
                        }
                    }
                }
            }
        }

        public void AccountDeposit()
        {
            bool retry = true;
            while (retry)
            {
                display.DepositScreen();
                accountNumber = input.StringInput(22, 6);
                display.AddBox(3, 60, 9);
                if (!input.ValidateInt(accountNumber))
                {
                    display.ErrorMessage("Invalid Account Number! Must be numbers only (0-9)", 2, 10);
                    retry = display.PromptMessage("Retry", 2, 11);
                } else
                {
                    if (!input.ValidateLength(accountNumber,10))
                    {
                        display.ErrorMessage("Invalid Account Length! Cannot exceed 10 digits", 2, 10);
                        retry = display.PromptMessage("Retry", 2, 11);
                    } else
                    {
                        if (File.Exists($@"{directory}\\Accounts\\{accountNumber}.txt"))
                        {
                            display.SuccessMessage("Account Found! Enter amount", 2, 10);
                            Console.ForegroundColor = ConsoleColor.White;
                            account = new Account(accountNumber);
                            string stringBalance = input.StringInput(22, 7);
                            if (!input.ValidateDouble(stringBalance))
                            {
                                display.ErrorMessage("Invalid Amount! Must be numbers only (0-9)", 2, 10);
                                retry = display.PromptMessage("Retry", 2, 11);
                            } else
                            {
                                double balance = Convert.ToDouble(stringBalance);
                                if (balance <= 0)
                                {
                                    display.ErrorMessage("Deposit Amount Cannot Be 0 or Negative!", 2, 10);
                                    retry = display.PromptMessage("Retry", 2, 11);
                                } else
                                {
                                    account.Deposit(balance);
                                    display.SuccessMessage("Deposit Successful!", 2, 10);
                                    retry = display.PromptMessage("Deposit another account", 2, 11);
                                }
                            }
                        }
                        else
                        {
                            display.ErrorMessage("Account File Not Found!", 2, 10);
                            retry = display.PromptMessage("Retry", 2, 11);
                        }
                    }
                }
            }
        }

        public void AccountWithdraw()
        {
            bool retry = true;
            while (retry)
            {
                display.DepositScreen();
                accountNumber = input.StringInput(22, 6);
                display.AddBox(3, 60, 9);
                if (!input.ValidateInt(accountNumber))
                {
                    display.ErrorMessage("Invalid Account Number! Must be numbers only (0-9)", 2, 10);
                    retry = display.PromptMessage("Retry", 2, 11);
                }
                else
                {
                    if (!input.ValidateLength(accountNumber, 10))
                    {
                        display.ErrorMessage("Invalid Account Length! Cannot exceed 10 digits", 2, 10);
                        retry = display.PromptMessage("Retry", 2, 11);
                    }
                    else
                    {
                        if (File.Exists($@"{directory}\\Accounts\\{accountNumber}.txt"))
                        {
                            display.SuccessMessage("Account Found! Enter amount", 2, 10);
                            Console.ForegroundColor = ConsoleColor.White;
                            account = new Account(accountNumber);
                            string stringBalance = input.StringInput(22, 7);
                            if (!input.ValidateDouble(stringBalance))
                            {
                                display.ErrorMessage("Invalid Amount! Must be numbers only (0-9)", 2, 10);
                                retry = display.PromptMessage("Retry", 2, 11);
                            }
                            else
                            {
                                double balance = Convert.ToDouble(stringBalance);
                                if (balance <= 0)
                                {
                                    display.ErrorMessage("Withdraw Amount Cannot Be 0 or Negative!", 2, 10);
                                    retry = display.PromptMessage("Retry", 2, 11);
                                }
                                else
                                {
                                    if (account.Balance - balance < 0)
                                    {
                                        display.ErrorMessage("Withdraw Failed! Unsufficient Funds To Withdraw", 2, 10);
                                        retry = display.PromptMessage("Retry", 2, 11);
                                    } else
                                    {
                                        account.Withdraw(balance);
                                        display.SuccessMessage("Withdraw Successful!", 2, 10);
                                        retry = display.PromptMessage("Withdraw another account", 2, 11);
                                    }
                                }
                            }
                        }
                        else
                        {
                            display.ErrorMessage("Account File Not Found!", 2, 10);
                            retry = display.PromptMessage("Retry", 2, 11);
                        }
                    }
                }
            }
        }

        public void AccountStatement()
        {
            bool retry = true;
            while (retry)
            {
                display.StatementScreen();
                accountNumber = input.StringInput(22, 6);
                display.AddBox(3, 60, 8);
                bool foundAccount = FindAccount(accountNumber, 2, 9);
                if (foundAccount)
                {
                    display.SuccessMessage("Account Found!", 2, 9);
                    display.SuccessMessage("Statement is shown below.", 2, 10);
                    Console.ForegroundColor = ConsoleColor.White;
                    display.AddBox(1, 60, 12);
                    display.CentreText("ACCOUNT STATEMENT", 60, 13);
                    display.DisplayDetails(accountNumber, 14);
                    display.DisplayTransactions(accountNumber, 24);
                    display.AddBox(3, 60, 34);
                    bool sendEmail = display.PromptMessage("Send statement to Email", 2, 35);
                    if (sendEmail)
                    {
                        email.sendEmail(accountNumber);
                    }
                    retry = display.PromptMessage("Check another account", 2, 36);
                }
                else
                {
                    retry = display.PromptMessage("Retry", 2, 10);
                }
            }
        }

        public void DeleteAccount()
        {
            bool retry = true;
            while (retry)
            {
                display.DeleteAccountScreen();
                accountNumber = input.StringInput(22, 6);
                display.AddBox(3, 60, 8);
                bool foundAccount = FindAccount(accountNumber, 2, 9);
                if (foundAccount)
                {
                    display.SearchSuccessScreen();
                    display.DisplayDetails(accountNumber, 12);
                    display.AddBox(3, 60, 22);
                    bool delete = display.PromptMessage("Delete", 2, 23);
                    if (delete)
                    {
                        File.Delete($@"{directory}\\Accounts\\{accountNumber}.txt");
                        display.SuccessMessage("Account Deleted!", 2, 23);
                    }
                    retry = display.PromptMessage("Delete another account", 2, 24);
                } else
                {
                    retry = display.PromptMessage("Retry", 2, 10);
                }
            }
        }

        public bool FindAccount(string accountNumber, int x, int y)
        {
            if (!input.ValidateInt(accountNumber))
            {
                display.ErrorMessage("Invalid Account Number! Must be numbers only (0-9)", x, y);
                return false;
            }
            else
            {
                if (!input.ValidateLength(accountNumber, 10))
                {
                    display.ErrorMessage("Invalid Account Length! Cannot exceed 10 digits", x, y);
                    return false;
                }
                else
                {
                    if (File.Exists($@"{directory}\\Accounts\\{accountNumber}.txt"))
                    {
                        return true;
                    }
                    else
                    {
                        display.ErrorMessage("Account File Not Found!", x, y);
                        return false;
                    }
                }
            }
        }
    }
}

