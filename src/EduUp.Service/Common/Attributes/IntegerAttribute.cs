using System.ComponentModel.DataAnnotations;

namespace EduUp.Service.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IntegerAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not null)
            {
                var price = (double)value;
                if (price > 0)
                    return ValidationResult.Success;
                return new ValidationResult($"Amount of money is a positive number!");
            }
            return ValidationResult.Success;


        }
    }
}
