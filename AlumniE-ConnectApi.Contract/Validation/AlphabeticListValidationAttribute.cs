using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Validation
{
    public class AlphabeticListValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var names = value as List<string>;
            if (names == null)
            {
                return ValidationResult.Success; // Null list is considered valid; handle null if needed.
            }

            // Regular expression for multiple words with spaces in between, only alphabetic characters
            var regex = new Regex(@"^([a-zA-Z]+( +)?)+$");

            foreach (var name in names)
            {
                if (!regex.IsMatch(name))
                {
                    return new ValidationResult("All names must contain only alphabetic characters and can consist of multiple words with optional spaces.");
                }
            }

            return ValidationResult.Success;
        }

    }
}
