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
                Console.WriteLine(ex);
                Console.ReadKey();
            }
            display.SuccessMessage("Email Successfully Sent", 2, 25);
        }

        public string emailTemplate(string accountNumber)
        {
            account = new Account(accountNumber);

            string messageBody = 
                $"<h1>Account Statement</h1><br>" + 
                $"<p>Account No: {account.AccountNumber}</p><br>" + 
                $"<p>Account Balance: ${account.Balance}</p><br>" + 
                $"<p>First Name: {account.FirstName}</p><br>" + 
                $"<p>Last Name: {account.LastName}</p><br>" + 
                $"<p>Address: {account.Address}</p><br>" + 
                $"<p>Phone: {account.PhoneNumber}</p><br>" + 
                $"<p>Email: {account.EmailAddress}</p><br>";
            return messageBody;
        }


    }
}
