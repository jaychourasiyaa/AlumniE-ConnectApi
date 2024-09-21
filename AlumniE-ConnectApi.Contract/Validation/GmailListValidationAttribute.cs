using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Validation
{
    public class GmailListValidationAttribute : ValidationAttribute
    {
        private readonly Regex _regex = new Regex(@"^[\w\.-]+@[A-Za-z0-9\.-]+\.[A-Za-z]{2,}$", RegexOptions.Compiled);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var emails = value as List<string>;
            if (emails == null || emails.Count == 0)
            {
                return ValidationResult.Success; // Consider an empty list valid, or you can return a custom error for empty lists
            }

            foreach (var email in emails)
            {
                if (!_regex.IsMatch(email))
                {
                    return new ValidationResult("One or more emails are invalid according to the provided format.");
                }
            }

            return ValidationResult.Success;
        }
    }

}
