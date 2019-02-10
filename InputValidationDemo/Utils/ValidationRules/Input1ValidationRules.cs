// Input1ValidationRules.cs
//
// This is the standard validation rules class with no dependence on
// other variables for the valid range of values.

using System;
using System.Globalization;
using System.Windows.Controls;

namespace InputValidationDemo.Utils.ValidationRules
{
    public class Input1ValidationRules:ValidationRule
    {

        private readonly uint minInput1 = 1;

        private readonly uint maxInput1 = 100;

        private uint input1;


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                // Ignore if value is  null - this is to prevent null reference exceptions at start-up
                if (value !=null)
                {
                    if (((string)value).Length > 0)
                    {
                        input1 = uint.Parse((String)value);
                    }
                }
                else
                {
                    return new ValidationResult(false, "Illegal input for Input1. Must be an integer.");
                }
                
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Illegal input for Input1. Must be an integer.");
            }

            if ( (input1 >= minInput1) && (input1 <= maxInput1) )
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, $"Input1 valid values: {minInput1} to {maxInput1}.");
            }
        }
    }

    
}
