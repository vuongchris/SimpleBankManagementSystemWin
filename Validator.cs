using System;
namespace SimpleBankManagementSystem
{
    public class Validator
    {
        public Validator()
        {

        }

        public bool ValidatePhoneNumber(string number)
        {
            if (!ValidateInt(number))
            {
                /// Error Message
                return false;
            }
            else
            {
                if (number.Length <= 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool ValidateEmail(string email)
        {
            for (int i = 0; i < email.Length; i++)
            {
                if ((i == 0 || i == email.Length) && (email[i] == '@' || email[i] == '.'))
                {
                    return false;
                }
            }
            return true;
        }

        public bool ValidateAccountNumber(string number)
        {
            if (!ValidateInt(number))
            {
                /// Error Message
                return false;
            }
            else
            {
                if (number.Length <= 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public bool ValidateInt(string number)
        {
            int defaultValue = 0;
            bool result = int.TryParse(number, out defaultValue);
            if (!result)
            {
                /// Error Message
            }
            return result;
        }

        public bool ValidateDouble(string number)
        {
            double defaultValue = 0.00;
            bool result = double.TryParse(number, out defaultValue);
            if (!result)
            {
                /// Error Message
            }
            return result;
        }
    }
}

