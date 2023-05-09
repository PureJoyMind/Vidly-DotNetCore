using System.ComponentModel.DataAnnotations;

namespace VidlyWeb.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        /*
         * If the user selects a membership type that is not pay as you go
         * they should also specify the birth date of the customer and this
         * customer should be at least 18 years old
         */
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                // Checking the selected membership type
                var customer = (Customer)validationContext.ObjectInstance;
                if (customer.MembershipTypeId is (byte)MembershipType.MemberShipNames.PayAsYouGo or 0) return ValidationResult.Success;

                if (customer.BirthDateTime == null) return new ValidationResult("Birthdate is required.");
                
                // We use .Value because this is a nullable date time.
                var age = DateTime.Today.Year - customer.BirthDateTime.Value.Year;

                return (age >= 18)
                    ? ValidationResult.Success
                    : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
            }
    }
}
