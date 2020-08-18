using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_BookStore.Helpers
{
    public class BookValidationAttribute: ValidationAttribute
    {
        public string Value { get; set; }
        public string Context { get; set; }
        //
        // Summary:
        //     Gets or sets an error message to associate with a validation control if validation
        //     fails.
        //
        // Returns:
        //     The error message that is associated with the validation control.
        public BookValidationAttribute(string ErrorMessage) : base(ErrorMessage)
        {

        }

        public BookValidationAttribute(string ErrorMessage,string context) : base(ErrorMessage)
        {
            Context = context;
        }
       
        
        //
        // Summary:
        //     Validates the specified value with respect to the current validation attribute.
        //
        // Parameters:
        //   value:
        //     The value to validate.
        //
        //   validationContext:
        //     The context information about the validation operation.
        //
        // Returns:
        //     An instance of the System.ComponentModel.DataAnnotations.ValidationResult class.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The current attribute is malformed.
        //
        //   T:System.NotImplementedException:
        //     System.ComponentModel.DataAnnotations.ValidationAttribute.IsValid(System.Object,System.ComponentModel.DataAnnotations.ValidationContext)
        //     has not been implemented by a derived class.
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {           
            if (value != null)
            {
                
                Value = value.ToString();
                if(string.IsNullOrEmpty(Context))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    if (Value.Contains(Context))
                    {
                        return ValidationResult.Success;
                    }
                }
            
              
            }
        
                return new ValidationResult(ErrorMessage ?? "Value is null");
           
        }


    }
}
