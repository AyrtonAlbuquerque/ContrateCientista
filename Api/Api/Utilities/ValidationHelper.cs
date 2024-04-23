using System.Security.Cryptography;
using System.Text;

namespace Api.Utilities
{
    public class ValidationHelper
    {
        public static string HashPassword(string password)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        public static bool ValidatePassword(string password)
        {
            return string.IsNullOrEmpty(password) ? false : password.Length >= 8 && password.Any(char.IsDigit) && password.Any(char.IsLetter);
        }

        public static bool ValidateCNPJ(string cnpj)
        {
            if (!string.IsNullOrEmpty(cnpj))
            {
                cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "").PadLeft(14, '0');

                if (!cnpj.All(char.IsDigit)) return false;

                if (GetVerifyingDigit(cnpj.Substring(0, 12), 1) == cnpj.Substring(12, 1))
                {
                    if (GetVerifyingDigit(cnpj.Substring(0, 13), 1) == cnpj.Substring(13, 1))
                        return !(cnpj.Distinct().Count() == 1);
                }
            }

            return false;
        }

        public static string FormatCNPJ(string cnpj)
        {
            return cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "").PadLeft(14, '0');
        }

        private static string GetVerifyingDigit(string value, int type)
        {
            var multiplyer = 1;
            var digit = 0;
            var inverse = value.Substring(0, value.Length).ToCharArray();
            Array.Reverse(inverse);
            var invertedValue = new string(inverse);

            for (int i = 0; i < value.Length; i++)
            {
                multiplyer++;

                if (multiplyer > 9 && type == 1)
                    multiplyer = 2;

                digit += multiplyer * int.Parse(invertedValue[i].ToString());
            }

            digit = 11 - (digit % 11);

            if (digit > 9)
                digit = 0;

            return digit.ToString();
        }
    }
}