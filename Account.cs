using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace SimpleBankManagementSystemWin
{
    class Account
    {
        string firstName, lastName, address, phoneNumber, emailAddress, accountNumber, directory;
        int counter;
        double balance;
        List<(DateTime, string, double, double)> transactionHistory;

        /// <summary>
        /// Loads all data from Account file and stores in variables
        /// </summary>
        /// <param name="account"></param>
        public Account(string account)
        {
            directory = Directory.GetCurrentDirectory();
            transactionHistory = new List<(DateTime date, string transactionType, double transactionAmount, double totalBalance)>();
            counter = 0;
            foreach (string line in File.ReadLines($@"{directory}\\Accounts\\{account}.txt"))
            {
                string[] elements = line.Split(new char[] { '|' }, StringSplitOptions.None);
                switch (counter)
                {
                    case 0:
                        firstName = elements[1];
                        break;
                    case 1:
                        lastName = elements[1];
                        break;
                    case 2:
                        address = elements[1];
                        break;
                    case 3:
                        phoneNumber = elements[1];
                        break;
                    case 4:
                        emailAddress = elements[1];
                        break;
                    case 5:
                        accountNumber = elements[1];
                        break;
                    case 6:
                        balance = Convert.ToDouble(elements[1]);
                        break;
                    default:
                        transactionHistory.Add((DateTime.Parse(elements[0]), elements[1], Convert.ToDouble(elements[2]), Convert.ToDouble(elements[3])));
                        break;
                }
                counter++;
            }
        }

        /// <summary>
        /// Deposit the amount inputted into user account
        /// </summary>
        /// <param name="amount"></param>
        public void Deposit(double amount)
        {
            balance += amount;
            WriteTransaction("Deposit", amount, balance);
            UpdateAccountFile();
        }

        /// <summary>
        /// Withdraw the amount inputted into user account
        /// </summary>
        /// <param name="amount"></param>
        public void Withdraw(double amount)
        {
            balance -= amount;
            WriteTransaction("Withdraw", amount, balance);
            UpdateAccountFile();
        }

        /// <summary>
        /// Store transaction details into array
        /// </summary>
        /// <param name="transactionType"></param>
        /// <param name="amount"></param>
        /// <param name="balance"></param>
        public void WriteTransaction(string transactionType, double amount, double balance)
        {
            DateTime currentDate = DateTime.Now;
            transactionHistory.Add((currentDate, transactionType, amount, balance));
        }

        /// <summary>
        /// Updates Account File with new information
        /// </summary>
        public void UpdateAccountFile()
        {
            string[] lines = {
                $"First Name|{firstName}", $"Last Name|{lastName}", $"Address|{address}", $"Phone|{phoneNumber}", $"Email|{emailAddress}", $"Account|{accountNumber}", $"Balance|{balance}"
            };

            File.WriteAllLines($@"{directory}\\Accounts\\{accountNumber}.txt", lines);

            using (StreamWriter sw = File.AppendText($@"{directory}\\Accounts\\{accountNumber}.txt"))
            {
                for (int i = 0; i < transactionHistory.Count; i++)
                {
                    sw.WriteLine($"{transactionHistory[i].Item1}|{transactionHistory[i].Item2}|{transactionHistory[i].Item3}|{transactionHistory[i].Item4}");
                }
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public List<(DateTime, string, double, double)> TransactionHistory
        {
            get { return transactionHistory; }
        }
    }
}
