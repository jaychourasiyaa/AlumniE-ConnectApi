using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Validation
{
    public class MobileNumberValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var mobileNumbers = value as List<string>;

            if (mobileNumbers == null)
            {
                return ValidationResult.Success; // Null list is considered valid (can be changed based on requirement)
            }
            foreach (var number in mobileNumbers)
            {
                if (string.IsNullOrWhiteSpace(number) || number.Length != 10 || !System.Text.RegularExpressions.Regex.IsMatch(number, @"^\d{10}$"))
                {
                    return new ValidationResult("Each mobile number must be exactly 10 digits.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
