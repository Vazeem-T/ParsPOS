using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Services
{
    public class ButtonColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return (Color)Application.Current.Resources["PrimaryColor"];

            // Check if the value matches the parameter and return the appropriate color
            string selectedButton = (string)value;
            string buttonName = (string)parameter;

            return selectedButton == buttonName ? Color.FromHex("#007BFF") : (Color)Application.Current.Resources["PrimaryColor"]; // Change to your desired color
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
