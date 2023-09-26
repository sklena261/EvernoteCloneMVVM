using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EvernoteClone.ViewModel.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateTime = (DateTime)value;
            DateTime datetimeNow = DateTime.Now;
            TimeSpan ts = datetimeNow - dateTime;
            double minutes = ts.TotalMinutes;
            double hours = 0;
            string span = string.Empty;
            if (minutes > 60)
            {
                hours = minutes / 60;
                hours = Math.Round(hours, 0, MidpointRounding.AwayFromZero);
                span = $"Aktualizovano pred {hours} hod.";
                return span;
            }
            span = $"Aktualizovano pred {Math.Round(minutes, 0, MidpointRounding.AwayFromZero)} min.";
            return span;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
