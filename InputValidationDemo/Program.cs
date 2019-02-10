using System;

namespace InputValidationDemo
{
    /// <summary>
    /// This demo demonstrates Input Validation rules in WPF. 
    /// </summary>
    public class Program
    {
        //Declare this to be run in Single-Threaded Apartment since it makes calls on UI (Window) classes
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new App();
            var view = new InterfaceFeatureWindow();
            var viewModel = new InterfaceFeatureViewModel();
            view.DataContext = viewModel;
            app.Run(view);
            

        }
    }
}
