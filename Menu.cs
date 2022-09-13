using System;
using System.IO;

namespace SimpleBankManagementSystem
{
    public class Menu
    {
        string selection;
        Account account;
        Display display;
        Validator validate;

        public Menu()
        {
            display = new Display();
            validate = new Validator();
        }

        public string MenuSelection()
        {
            Console.SetCursorPosition(35, 12);
            selection = Console.ReadLine();
            return selection;
        }

        public string UserSelection()
        {
            return "0";
        }

        public void CreateAccount()
        {
            Console.SetCursorPosition(18, 6);
            string firstName = Console.ReadLine();
            Console.SetCursorPosition(17, 7);
            string lastName = Console.ReadLine();
            Console.SetCursorPosition(15, 8);
            string address = Console.ReadLine();
            Console.SetCursorPosition(13, 9);
            string phoneNumber = Console.ReadLine();
            Console.SetCursorPosition(13, 10);
            string emailAddress = Console.ReadLine();
        }

        public async void CreateAccountFile(string firstName, string lastName, string address, string phoneNumber, string emailAddress)
        {
            int accountNumber = NextAvailableNumber();
            string[] lines =
            {
                $"First Name|{firstName}", $"Last Name|{lastName}", $"Address|{address}", $"Phone|{phoneNumber}", $"Email|{emailAddress}", $"Account|{accountNumber}", "Balance|0"
            };
            //await File.WriteAllLinesAsync($"/Accounts/{accountNumber}.txt", lines);

        }


        public int NextAvailableNumber()
        {
            for (int i = 100001; i < 100000000; i++)
            {
                if (!File.Exists($"/Accounts/{i}.txt"))
                {
                    return i;
                }
            }
            return 0;
        }

        public void SearchAccount()
        {
            int accountNumber = 0;
            if (File.Exists($"/Accounts/{accountNumber}.txt"))
            {
                // Success Message
            }
            else
            {
                // Error Message
            }
        }

        public void AccountDeposit()
        {
            int accountNumber = 0;
            if (File.Exists($"/Accounts/{accountNumber}.txt"))
            {
                account = new Account(accountNumber);
                double balance = 0.00;
                account.Deposit(balance);
            }
            else
            {
                // Error Message
            }

        }

        public void AccountWithdraw()
        {
            int accountNumber = 0;
            if (File.Exists($"/Accounts/{accountNumber}.txt"))
            {
                account = new Account(accountNumber);
                double balance = 0.00;
                account.Withdraw(balance);
            }
            else
            {
                // Error Message
            }
        }

        public void AccountStatement()
        {
            int accountNumber = 0;
            if (File.Exists($"/Accounts/{accountNumber}.txt"))
            {
                account = new Account(accountNumber);


            }
            else
            {
                // Error Message
            }
        }

        public void DeleteAccount()
        {
            int accountNumber = 0;
            if (File.Exists($"/Accounts/{accountNumber}.txt"))
            {

            }
            else
            {
                // Error Message
            }
        }

        public void Exit()
        {

        }

    }
}

