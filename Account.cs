using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace SimpleBankManagementSystem
{
    class Account
    {
        string firstName, lastName, address, phoneNumber, emailAddress;
        int accountNumber, counter;
        double balance;
        List<(DateTime, string, double, double)> transactionHistory;

        public Account()
        {

        }

        public Account(int accountNumber)
        {
            transactionHistory = new List<(DateTime date, string transactionType, double transactionAmount, double totalBalance)>();
            counter = 0;
            foreach (string line in System.IO.File.ReadLines($"/Accounts/{accountNumber}.txt"))
            {
                string[] elements = line.Split(new char[] { '|' }, StringSplitOptions.None);
                switch (counter)
                {
                    case 0:
                        this.firstName = elements[1];
                        break;
                    case 1:
                        this.lastName = elements[1];
                        break;
                    case 2:
                        this.address = elements[1];
                        break;
                    case 3:
                        this.phoneNumber = elements[1];
                        break;
                    case 4:
                        this.emailAddress = elements[1];
                        break;
                    case 5:
                        this.accountNumber = Convert.ToInt32(elements[1]);
                        break;
                    case 6:
                        this.balance = Convert.ToDouble(elements[1]);
                        break;
                    default:
                        transactionHistory.Add((Convert.ToDateTime(elements[0]), elements[1], Convert.ToDouble(elements[2]), Convert.ToDouble(elements[3])));
                        break;
                }
                counter++;
            }
        }

        // Deposit amount specified by user into customer's account
        public void Deposit(double amount)
        {
            balance += amount;
            WriteTransaction("Deposit", amount, balance);
        }

        // Withdraw amount specified by user into customer's account
        public void Withdraw(double amount)
        {
            if ((balance - amount) < 0)
            {
                /// Error Message
            }
            else
            {
                balance -= amount;
                WriteTransaction("Withdraw", amount, balance);
            }
        }

        // Write transaction details into transaction history array
        public void WriteTransaction(string transactionType, double amount, double balance)
        {
            DateTime currentDate = DateTime.Now;
            transactionHistory.Add((currentDate, transactionType, amount, balance));
        }
    }
}
