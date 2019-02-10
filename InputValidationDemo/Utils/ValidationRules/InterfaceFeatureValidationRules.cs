// InterfaceFeatureValidationRules.cs
//
// This is the validation rules class for the `Attribute' variable, the value 
// of which is dependent on the selected value from the `Value` combo box.
// There is a `SelectedValueDependency` property exposed to allow for the proper
// set of ranges to be chosen to do the input validation. This is what allows us
// to get around the restriction of the inability of a DependencyObject to
// inherit from the ValidationRules class.
//

using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Markup;

namespace InputValidationDemo.Utils.ValidationRules
{
    [ContentProperty("SelectedValueDependency")]
    public class InterfaceFeatureValidationRules : ValidationRule
    {

        //These are the boundaries that are used to check values.
        private readonly uint minValAttribute1 = 0;
        private readonly uint maxValAttribute1 = 100;

        private readonly uint minValAttribute2 = 0;
        private readonly uint maxValAttribute2 = 50;
        private readonly uint minValAttribute3 = 60;
        private readonly uint maxValAttribute3 = 100;

        private readonly uint minValAttribute4 = 1000;
        private readonly uint maxValAttribute4 = 2000;

        private readonly uint minValAttribute5 = 3000;
        private readonly uint maxValAttribute5 = 4000;


        public SelectedValueDependency SelectedValueDependency { get; set; }       


        public InterfaceFeatureValidationRules()
        {
        }


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            uint candidateAttribute;
            try
            {
                // Ignore if value is  null - this is to prevent null reference exceptions at start-up
                if (value != null)
                {
                    candidateAttribute = uint.Parse(value.ToString());
                }
                else
                {
                    return new ValidationResult(false, "Must select a value");
                }
                
            }
            catch(Exception e)
            {
                if (SelectedValueDependency.SelectedValue == null)
                {
                    return new ValidationResult(false, "Must select a value.");
                }
                else
                {
                    return new ValidationResult(false, "Illegal input for attribute. Must be integers.");
                }
                
            }

            switch(SelectedValueDependency.SelectedValue)
            {
                //If the user selects "100" - Attribute must be between minValAttribute1 and maxValAttribute1
                case ("100<Unit>"):
                    if (candidateAttribute >= minValAttribute1 && candidateAttribute <= maxValAttribute1 )
                    {
                        return new ValidationResult(true, null);
                    }
                    else
                    {
                        return new ValidationResult(false, $"Valid Attributes: {minValAttribute1} - {maxValAttribute1}");
                    }
                //If the user selects "200" - Attribute must be between minValAttribute2 and maxValAttribute2 OR between
                // minValAttribute3 and maxValAttribute 3.
                case ("200<Unit>"):
                    if ( (candidateAttribute >= minValAttribute2 && candidateAttribute <= maxValAttribute2) ||
                        (candidateAttribute >= minValAttribute3 && candidateAttribute <= maxValAttribute3))
                    {
                        return new ValidationResult(true, null);
                    }
                    else
                    {
                        return new ValidationResult(false, $"Valid Attributes: {minValAttribute2} - {maxValAttribute2}, {minValAttribute3} - {maxValAttribute3}");
                    }
                //If the user selects "300" - Attribute must be between minValAttribute4 and maxValAttribute4
                case ("300<Unit>"):
                    if (candidateAttribute >= minValAttribute4 && candidateAttribute <= maxValAttribute4)
                    {
                        return new ValidationResult(true, null);
                    }
                    else
                    {
                        return new ValidationResult(false, $"Valid Attributes: {minValAttribute4} - {maxValAttribute4}");
                    }
                //If the user selects "400" - Attribute must be between minValAttribute5 and maxValAttribute5
                case ("400<Unit>"):
                    if (candidateAttribute >= minValAttribute5 && candidateAttribute <= maxValAttribute5)
                    {
                        return new ValidationResult(true, null);
                    }
                    else
                    {
                        return new ValidationResult(false, $"Valid Attributes: {minValAttribute5} - {maxValAttribute5}");
                    }
                default:
                    return new ValidationResult(false, "Must select a value.");
            }           

        }

    }
}
