﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DesktopUI.ValueConverters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            if (parameter == null)
            {
                return (bool) value ? Visibility.Hidden : Visibility.Visible;
            }
            else
            {
                return (bool) value ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}