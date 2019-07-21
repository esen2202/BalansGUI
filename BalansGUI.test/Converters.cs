using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BalansGUI.test
{
    public class ParityByteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<byte> val = (List<byte>)value;
            List<string> ret = new List<string>();
            val.ForEach(x => {
                ret.Add(((Parity)x).ToString());
            });
            return ret; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = (string)value;
            return (byte)((Parity)Enum.Parse(typeof(Parity),val));
        }
    }
}
