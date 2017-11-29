using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Graphique
{
    class DateTime2StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date;
            try
            {
                date = (DateTime)value;
            }
            catch (InvalidCastException e)
            {
                return e;
            }
            string dateTimeString = date.ToString("dd MMMM yyyy");
            return dateTimeString;
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string date;
            try
            {
                date= (string)value;
            }
            catch(InvalidCastException e)
            {
                return e;
            }

            DateTime da = DateTime.Parse(date);
            return date;
        }

    }
}
