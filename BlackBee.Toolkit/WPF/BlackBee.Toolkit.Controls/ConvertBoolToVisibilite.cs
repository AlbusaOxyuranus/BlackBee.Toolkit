using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace XCS.BV.VM.BlackBee.Controls
{
    /// <summary>
    /// </summary>
    public class ConvertBoolToVisibilite : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (bool.Parse(value.ToString()))
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            Visibility visibility;
            Enum.TryParse(value.ToString(), true, out visibility);
            if (visibility == Visibility.Visible)
                return true;
            return false;
        }
    }
}