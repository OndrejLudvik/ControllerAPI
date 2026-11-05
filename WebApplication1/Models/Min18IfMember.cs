using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Min18IfMember : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var customer = (Customer)validationContext.ObjectInstance;
        if (customer.MembershipTypeId == 0)
            return ValidationResult.Success;

        if (customer.BirthDate == null)
            return new ValidationResult("Birthdate is required");

        var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
        return age >= 18 ? ValidationResult.Success : new ValidationResult("Customer should be atleast 18.");
    }
}