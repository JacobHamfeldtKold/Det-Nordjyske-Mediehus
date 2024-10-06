using Microsoft.AspNetCore.Http;
using System;
using System.Text.RegularExpressions;

namespace NordjyskeMediehus.API.HelperClasses
{
    public static class PhoneNumber
    {
        // Regular expression used to validate a phone number.
        public const string phonenumberPatterns = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        public const string danishPhoneNumberPattern = @"^(?:\+45)?[2-9]\d{7}$";

        public static bool IsPhoneNbr(string number)
        {
            if (number != null)
                return Regex.IsMatch(number, phonenumberPatterns) || Regex.IsMatch(number, danishPhoneNumberPattern);
            else
                return false;
        }
    }
}
