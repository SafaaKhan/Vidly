using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsOldIfAMermber: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           var cutomer= (Customer) validationContext.ObjectInstance;

            if (cutomer.MembershipTypeID== MembershipType.Unknown || 
                cutomer.MembershipTypeID == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (cutomer.Birthdate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - cutomer.Birthdate.Value.Year;

            return (age >= 18) ? ValidationResult.Success :
                new ValidationResult("Customer age must be at leat 18 years old to go on a membership.");
        }
    }
}