using System;


namespace BlackBee.Toolkit.Controls
{

#if !NETFX_CORE
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// 
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
            // ReSharper disable once AccessToStaticMemberViaDerivedType
            Visibility.TryParse(value.ToString(), true, out visibility);
            if (visibility == Visibility.Visible)
                return true;
            return false;
        }   
    } 
#else
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;
    /// <summary>
    /// 
    /// </summary>
    public class ConvertBoolToVisibilite : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (bool.Parse(value.ToString()))
                return Visibility.Visible;
            return Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            Visibility visibility;
            // ReSharper disable once AccessToStaticMemberViaDerivedType
            Visibility.TryParse(value.ToString(), true, out visibility);
            if (visibility == Visibility.Visible)
                return true;
            return false;
        }

    }
#endif

}