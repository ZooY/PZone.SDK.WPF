using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;


namespace PZone.Wpf.Converters
{
    /// <summary>
    /// Преобразование значений типов <see cref="bool"/> и <see cref="Visibility"/> с инверсией результата.
    /// </summary>
    /// <remarks>
    /// Логическое значение <c>True</c> соответствует <see cref="Visibility.Collapsed"/>; значение <c>False</c> соответствует <see cref="Visibility.Visible"/>.
    /// </remarks>
    public class InvertedBooleanToVisibilityConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(Visibility))
                throw new InvalidOperationException("Converter can only convert to value of type Visibility.");
            var visible = System.Convert.ToBoolean(value, culture);
            return visible ? Visibility.Collapsed : Visibility.Visible;
        }


        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException("Converter can only convert to value of type Boolean.");
            var boolValue =  value != null && (Visibility)value == Visibility.Visible;
            return !boolValue;
        }
    }
}