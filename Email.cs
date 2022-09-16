using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagementSystemWin
{
    class Email
    {
        Account account;
        Display display;
        MailMessage message;
        SmtpClient smtp;
        List<(DateTime, string, double, double)> transactionHistory;
        public Email()
        {
            display = new Display();
        }

        public void sendEmail(string accountNumber)
        {
            display.Message("Sending Email...", 2, 25);
            display.ClearAt(26, 1, 60);
            try
            {
                account = new Account(accountNumber);
                message = new MailMessage();
                smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential("chrisvuong2607@gmail.com", "opldpwmbyptehbxs");

                message.From = new MailAddress("chrisvuong2607@gmail.com");
                message.To.Add(new MailAddress(account.EmailAddress));
                message.Subject = "Account Statement";
                message.IsBodyHtml = true;
                message.Body = emailTemplate(accountNumber);
                smtp.Send(message);

            } catch (Exception ex)
            {
                display.ErrorMessage("Email Could Not Be Sent!", 2, 25);
            }
            display.SuccessMessage("Email Sent Successfully!", 2, 25);
        }

        public string emailTemplate(string accountNumber)
        {
            account = new Account(accountNumber);
            transactionHistory = account.TransactionHistory;
            string messageBody = 
                $"<h1>Account Statement</h1><br>" + 
                $"<p>Account No: {account.AccountNumber}</p>" + 
                $"<p>Account Balance: ${account.Balance}</p>" + 
                $"<p>First Name: {account.FirstName}</p>" + 
                $"<p>Last Name: {account.LastName}</p>" + 
                $"<p>Address: {account.Address}</p>" + 
                $"<p>Phone: {account.PhoneNumber}</p>" + 
                $"<p>Email: {account.EmailAddress}</p><br>" +
                $"<h2>Transaction History</h2>" + 
                $"<table><tr><th>Date</th><th>Type</th><th>Amount</th><th>Balance</th></tr>";

            foreach (var element in transactionHistory) 
            {
                messageBody += $"<tr><td>{element.Item1}</td><td>{element.Item2}</td><td>${element.Item3}</td><td>${element.Item4}</td></tr>";
            }

            messageBody += $"</table>";

            return messageBody;
        }


    }
}
