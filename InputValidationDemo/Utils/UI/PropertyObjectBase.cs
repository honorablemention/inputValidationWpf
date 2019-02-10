using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InputValidationDemo.Utils.UI
{
    //
    // Summary: Taken from:
    //     http://stackoverflow.com/a/2247584/4708255
    public class PropertyObjectBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected void SetPropertyField<T>(ref T field, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
