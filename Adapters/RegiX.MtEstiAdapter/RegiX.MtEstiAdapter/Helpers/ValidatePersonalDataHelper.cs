using System;
using System.Configuration;

namespace TechnoLogica.RegiX.MtEstiAdapter.Helpers
{
    public static class ValidatePersonalDataHelper
    {
        private static readonly byte[] Egn = new byte[10];
        private static readonly byte[] Weights = new byte[9] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
        private static readonly string ValidatePersonDataKey = "ValidatePersonData";

        public static bool ValidatePersonNumber(string identityNumber)
        {
            // Понеже не е ясно дали подаденият номер е ЕГН или ЛНЧ
            var isValidEgn = ValidateEgnNumber(identityNumber);
            var isValidLnch = ValidateForeignNumber(identityNumber);
            var result = isValidEgn || isValidLnch;
            return result;
        }

        private static bool ValidateEgnNumber(string egnNumber)
        {
            if (!ShouldValidatePersonData())
            {
                return true;
            }

            if (egnNumber.Length != 10)
            {
                return false;
            }

            foreach (char digit in egnNumber)
            {
                if (!char.IsDigit(digit))
                {
                    return false;
                }
            }

            ulong egn = Convert.ToUInt64(egnNumber);
            if (egn < 9952319999)
            {
                for (int i = 9; i >= 0; i--)
                {
                    Egn[i] = (byte)(egn % 10);
                    egn /= 10;
                }
            }

            DateTime testDate;
            try
            {
                testDate = new DateTime(GetYear(), GetMonth(), GetDay());
            }
            catch
            {
                return false;
            }

            if (testDate > DateTime.Now)
            {
                return false;
            }

            int checksum = 0;
            for (int i = 0; i < 9; i++)
            {
                checksum += Egn[i] * Weights[i];
            }

            int remainder = checksum % 11;
            if (remainder == 10)
            {
                remainder = 0;
            }

            if (remainder != Egn[9])
            {
                return false;
            }

            return true;

        }

        private static bool ValidateForeignNumber(string foreignNumber)
        {
            if (!ShouldValidatePersonData())
            {
                return true;
            }

            if (foreignNumber.Length != 10)
            {
                return false;
            }

            foreach (char digit in foreignNumber)
            {
                if (!char.IsDigit(digit))
                {
                    return false;
                }
            }

            int[] weights = new int[] { 21, 19, 17, 13, 11, 9, 7, 3, 1 };
            int totalControlSum = 0;

            for (int i = 0; i < 9; i++)
            {
                totalControlSum += weights[i] * (foreignNumber[i] - '0');
            }

            int controlDigit = totalControlSum % 10;

            int lastDigitFromIDNumber = int.Parse(foreignNumber.Substring(9));
            if (lastDigitFromIDNumber != controlDigit)
            {
                return false;
            }

            return true;
        }

        private static bool ShouldValidatePersonData()
        {
            var result = false;
            var shouldValidateString = ConfigurationManager.AppSettings[ValidatePersonDataKey];
            if (shouldValidateString != null)
            {
                bool.TryParse(shouldValidateString, out result);
            }

            return result;
        }

        private static int GetYear()
        {
            int year = Egn[0] * 10 + Egn[1];
            int month = Egn[2] * 10 + Egn[3];
            if (month > 40)
            {
                return year += 2000;
            }
            else if (month > 20)
            {
                return year += 1800;
            }

            return year += 1900;
        }

        private static int GetMonth()
        {
            int month = Egn[2] * 10 + Egn[3];
            if (month > 40)
            {
                return month -= 40;
            }
            else if (month > 20)
            {
                return month -= 20;
            }

            return month;
        }

        private static int GetDay()
        {
            var result = Egn[4] * 10 + Egn[5];
            return result;
        }
    }
}
