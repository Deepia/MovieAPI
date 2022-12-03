using MovieAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Validations
{
    public class FirstLetterUpperCaseAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //Genre obj = (Genre)validationContext.ObjectInstance;
            if(value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var firstLetter = value.ToString()[0].ToString();
            if(firstLetter != firstLetter.ToUpper())
            {
                return new ValidationResult("First letter should be upper case.");
            }
            return ValidationResult.Success;
        }
    }
}
