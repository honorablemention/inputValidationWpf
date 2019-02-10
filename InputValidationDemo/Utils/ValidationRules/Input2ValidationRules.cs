// Input2ValidationRules.cs
//
// This is the standard validation rules class with no dependence on
// other variables for the valid range of values.

using System;
using System.Globalization;
using System.Windows.Controls;

namespace InputValidationDemo.Utils.ValidationRules
{
    public class Input2ValidationRules:ValidationRule
    {

        private readonly uint minInput2 = 0;

        private readonly uint maxInput2 = 10;

        private uint input2;


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                // Ignore if value is  null - this is to prevent null reference exceptions at start-up
                if (value != null)
                {
                    if (((string)value).Length > 0)
                    {
                        input2 = uint.Parse((String)value);
                    }
                }
                else
                {
                    return new ValidationResult(false, "Illegal input for Input2. Must be an integer.");
                }
                
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Illegal input for Input2. Must be an integer.");
            }

            if ( (input2 >= minInput2) && (input2 <= maxInput2) )
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, $"Input2 valid values: {minInput2} to {maxInput2}.");
            }
        }
    }

    
}
