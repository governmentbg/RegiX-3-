using System;
using System.Configuration;
using System.Linq;

namespace TechnoLogica.RegiX.MtEstiAdapter.Helpers
{
    public static class ValidateCompanyDataHelper
    {
        private static readonly int[] FirstSumNineDigitWeights = { 1, 2, 3, 4, 5, 6, 7, 8 };
        private static readonly int[] SecondSumNineDigitWeights = { 3, 4, 5, 6, 7, 8, 9, 10 };
        private static readonly int[] FirstSumThirteenDigitWeights = { 2, 7, 3, 5 };
        private static readonly int[] SecondSumThirteenDigitWeights = { 4, 9, 5, 7 };
        private static readonly string ValidateCompanyDataKey = "ValidateCompanyData";

        public static bool ValidateCompanyNumber(string companyNumber)
        {
            if (!ShouldValidateCompanyData())
            {
                return true;
            }

            var hasNonDigit = companyNumber.ToCharArray().Any(x => !char.IsDigit(x));
            if (hasNonDigit)
            {
                return false;
            }

            if (companyNumber.Length != 9 && companyNumber.Length != 13)
            {
                return false;
            }

            int[] digits = CheckInput(companyNumber);
            if (companyNumber.Length == 9)
            {
                var result = CalculateChecksumForNineDigitsEIK(digits);
                return result;
            }
            else
            {
                var result = CalculateChecksumForThirteenDigitsEIK(digits);
                return result;
            }
        }

        private static bool ShouldValidateCompanyData()
        {
            var result = false;
            var shouldValidateString = ConfigurationManager.AppSettings[ValidateCompanyDataKey];
            if (shouldValidateString != null)
            {
                bool.TryParse(shouldValidateString, out result);
            }

            return result;
        }

        private static bool CalculateChecksumForNineDigitsEIK(int[] digits)
        {
            var ninthDigit = CalculateNinthDigitInEIK(digits);
            var result = ninthDigit == digits[8];
            return result;
        }

        private static bool CalculateChecksumForThirteenDigitsEIK(int[] digits)
        {
            int ninthDigit = CalculateNinthDigitInEIK(digits);
            if (ninthDigit != digits[8])
            {
                return false;
            }

            int thirteenDigit = CalculateThirteenthDigitInEIK(digits);
            var result = thirteenDigit == digits[12];
            return result;
        }

        private static int CalculateNinthDigitInEIK(int[] digits)
        {
            int sum = 0;
            for (int i = 0; i < 8; i++)
            {
                sum = sum + (digits[i] * FirstSumNineDigitWeights[i]);
            }

            int remainder = sum % 11;
            if (remainder != 10)
            {
                return remainder;
            }

            // remainder = 10
            int secondSum = 0;
            for (int i = 0; i < 8; i++)
            {
                secondSum = secondSum + (digits[i] * SecondSumNineDigitWeights[i]);
            }

            int secondRem = secondSum % 11;
            if (secondRem != 10)
            {
                return secondRem;
            }

            // secondRemainder = 10
            return 0;
        }

        private static int CalculateThirteenthDigitInEIK(int[] digits)
        {
            // 9thDigit is a correct checkSum. Continue with 13thDigit
            int sum = 0;
            for (int i = 8, j = 0; j < 4; i++, j++)
            {
                sum = sum + (digits[i] * FirstSumThirteenDigitWeights[j]);
            }

            int remainder = sum % 11;
            if (remainder != 10)
            {
                return remainder;
            }

            // remainder = 10
            int secondSum = 0;
            for (int i = 8, j = 0; j < 4; i++, j++)
            {
                secondSum = secondSum + (digits[i] * SecondSumThirteenDigitWeights[j]);
            }

            int secondRem = secondSum % 11;
            if (secondRem != 10)
            {
                return secondRem;
            }

            // secondRemainder = 10
            return 0;
        }

        private static int[] CheckInput(string eik)
        {
            char[] charDigits = eik.ToCharArray();
            int[] digits = new int[charDigits.Length];
            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = Convert.ToInt32(charDigits[i].ToString(), 10);
            }

            return digits;
        }
    }
}
