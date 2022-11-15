using Parking.Domain.Enums;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Parking.Converters
{
    public class StatusToTextCommandConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is ParkingStatus parkingStatus)
            {
                switch (parkingStatus)
                {
                    case ParkingStatus.Enabled:
                        return "Disable";
                    case ParkingStatus.Disabled:
                        return "Enable";
                    default:
                        break;
                }
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
