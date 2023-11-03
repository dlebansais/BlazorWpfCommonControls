namespace CustomControls.BlazorWpfCommon;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

/// <summary>
/// Converter to and from enum to int.
/// </summary>
[ValueConversion(typeof(Enum), typeof(Visibility))]
public class EyeCircleTypeToVisibilityConverter : IValueConverter
{
    /// <summary>
    /// Converter from an enum to an int.
    /// </summary>
    /// <param name="value">The value produced by the binding source.</param>
    /// <param name="targetType">The type of the binding target property.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>A converted value.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        EyeCircleType TypeValue = (EyeCircleType)value;
        string StringParameter = (string)parameter;

        if (TypeValue.ToString() == StringParameter)
            return Visibility.Visible;
        else
            return Visibility.Collapsed;
    }

    /// <summary>
    /// Converter from an int to an enum.
    /// </summary>
    /// <param name="value">The value that is produced by the binding target.</param>
    /// <param name="targetType">The type to convert to.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>A converted value.</returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }
}
