// SelectedValueDependency.cs
// This class holds the actual value (string type) of the selected value from the combo box.
// It inherits from the DependencyObject class and exposes the dependency property,
// `SelectedValueProperty`.
//
// The BindingToTrigger property is a dependency property that holds the info on the binding.
// When the SelectedValueProperty changes, the "OnValueChanged" method gets executed and retrieves
// the binding target property from the dependency object (SelectedValueDependency). 

// In InterfaceFeatureWindow.xaml, the BindingToTrigger property is set by the static resource
// `SourceProxy` which is the collection of values in the combo box. The `SelectedValue` property is
// set by the `SelectedValueProxy' which is the currently selected item of the combo box.
// Both `Source Proxy` and `SelectedValueProxy` are instances of the SelectedValueContainer class.
// 

using System.Windows;
using System.Windows.Data;

namespace InputValidationDemo.Utils.ValidationRules
{
    public class SelectedValueDependency : DependencyObject
    {

        public string SelectedValue
        {
            get { return (string)GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register(
            nameof(SelectedValue),
            typeof(string),
            typeof(SelectedValueDependency),
            new PropertyMetadata(default(string), OnValueChanged));


        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SelectedValueDependency selectedValueDependency = (SelectedValueDependency)d;
            BindingExpressionBase bindingExpressionBase = BindingOperations.GetBindingExpressionBase(selectedValueDependency, BindingToTriggerProperty);
        }

        public object BindingToTrigger
        {
            get { return GetValue(BindingToTriggerProperty); }
            set { SetValue(BindingToTriggerProperty, value);  }
        }

        public static readonly DependencyProperty BindingToTriggerProperty = DependencyProperty.Register(
            nameof(BindingToTrigger),
            typeof(object),
            typeof(SelectedValueDependency),
            new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}


