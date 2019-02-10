// InterfaceFeatureViewModel.cs

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using InputValidationDemo.Utils.UI;

namespace InputValidationDemo
{
    public enum ValueEnum { First, Second, Third, Fourth};
    public class InterfaceFeatureViewModel : PropertyObjectBase
    {
        // This is the top-level (independent) data item which Attribute and Input1 and Input2 are dependent upon.
        private ValueEnum m_SelectedValueEnum;

        private string m_SelectedValue;

        private string m_attributeUserValue;

        private string m_input1UserValue;

        private string m_input2UserValue;

        /// <summary>
        // Null out values when window is closed. This is only necessary if this ViewModel is used for a child window
        // in the main application and you don't want user-input values to persist after closing and re-opening
        // the window.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnClosed(EventArgs e)
        {
            m_attributeUserValue = null;
            m_input2UserValue = null;
            m_input1UserValue = null;
            m_SelectedValue = null;
        }
        /// <summary>
        /// Numerical values of the independent values that the user selects.
        /// </summary>
        private static List<UInt32> ValueNumValues = new List<UInt32>()
        {
                100, 200, 300, 400
        };

        /// <summary>
        /// Collection of independent variable values for the selector element.
        /// </summary>
        private static readonly ObservableCollection<string> m_valueValuesCollection = new ObservableCollection<string>();


        #region Data-binding
        
        public ObservableCollection<string> ValueValues
        {
            get
            {
                return m_valueValuesCollection;
            }
        }

        public string SelectedValue
        {
            get
            {
                return m_SelectedValue;
            }
            set
            {
                SetPropertyField(ref m_SelectedValue, value);                
            }
        }

        public string AttributeUserValue
        {
            get
            {
                return m_attributeUserValue;
            }

            set
            {
                SetPropertyField(ref m_attributeUserValue, value);
            }
        }

        public string Input1UserValue
        {
            get
            {
                return m_input1UserValue;
            }

            set
            {
                SetPropertyField(ref m_input1UserValue, value);
            }
        }

        public string Input2UserValue
        {
            get
            {
                return m_input2UserValue;
            }

            set
            {
                SetPropertyField(ref m_input2UserValue, value);
            }
        }        

        
        #endregion


        /// <summary>
        /// Iterates through list of the Independent numerical values and fills the collection with strings with a "unit" tag.
        /// This unit tag represents a unit of measure for the numerical value. This was done because there was no way of combining the 
        /// type without making a separate class (which you can do, but felt like overkill for this demo).
        /// </summary>
        public InterfaceFeatureViewModel()
        {   
            foreach(var i in ValueNumValues)
            {
                m_valueValuesCollection.Add(String.Concat(i.ToString(), "<Unit>"));
            }
            PropertyChanged += HandlePropertyChange;
        } 

        #region Private Methods
        

        /// <summary>
        /// Property change listener for observable collection.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        private void HandlePropertyChange(object source, PropertyChangedEventArgs args)
        {
            if (args.PropertyName.Equals(nameof(SelectedValue)))
            {

                if (m_valueValuesCollection.IndexOf(SelectedValue) == ValueNumValues.IndexOf(100))
                {
                    m_SelectedValueEnum = ValueEnum.First;
                }
                if (m_valueValuesCollection.IndexOf(SelectedValue) == ValueNumValues.IndexOf(200))
                {
                    m_SelectedValueEnum = ValueEnum.Second;
                }
                if (m_valueValuesCollection.IndexOf(SelectedValue) == ValueNumValues.IndexOf(300))
                {
                    m_SelectedValueEnum = ValueEnum.Third;
                }
                if (m_valueValuesCollection.IndexOf(SelectedValue) == ValueNumValues.IndexOf(400))
                {
                    m_SelectedValueEnum = ValueEnum.Fourth;
                }

            }
            else
            {
                // Do something when we don't get an expected value...
            }
        }

        #endregion
    }
}