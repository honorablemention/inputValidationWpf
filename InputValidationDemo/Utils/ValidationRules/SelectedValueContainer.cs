// SelectedValueContainer.cs
//
// This container class inherits from the Freezable class which is similar to the DependencyObject
// but has the advantage of providing change notifications for sub-properties.
// To take advantage of this feature this class exposes a public property that holds a reference
// to the `Value` property that we want to pass to a validation rule. 
// 

using System.Windows;

namespace InputValidationDemo.Utils.ValidationRules
{
    public class SelectedValueContainer : Freezable
    {

        protected override Freezable CreateInstanceCore()
        {
            return new SelectedValueContainer();
        }

        public object Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value);  }
        }


        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(object),
                typeof(SelectedValueContainer),
                new UIPropertyMetadata(null));
    }
}
