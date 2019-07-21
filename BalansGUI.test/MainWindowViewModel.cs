using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalansGUI.test
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private SerialPortCom SerialPortCom { get; set; }

        private List<string> _portNameList;
        public List<string> PortNameList
        {
            get { 
                return SerialPortCom.PortNameList; }
            set
            {
                _portNameList = value;
                OnPropertyChanged("PortNameList");
            }
        }

        public  List<int> BaudRateList => SerialPortCom.GetBaudRates();
        public  List<byte> ParityList => SerialPortCom.GetParities();
        public  List<byte> DataBitList => SerialPortCom.GetDataBits();

        public MainWindowViewModel()
        {
            SerialPortCom = new SerialPortCom();

        }

        public void UpdatePortNameList()
        {
            PortNameList = SerialPortCom.PortNameList;
        }

        #region Interface Implemenets

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }


    public class SerialPortCom : ISerialPortCom
    {
        public static List<string> PortNameList { get { return UpdatePortNameList(); } }

        public SerialPort SerialPort { get; set; }

        public static List<int> GetBaudRates() => new List<int>{
            300,
            600,
            1200,
            2400,
            4800,
            9600,
            19200,
            38400,
            57600,
            115200,
            230400,
            460800,
            921600
        };

        public static List<byte> GetParities() => new List<byte> { 0, 1, 2, 3, 4 };

        public static List<byte> GetDataBits() => new List<byte> { 5, 6, 7, 8 };

        public SerialPortCom() => SerialPort = new SerialPort();

        public static List<string> UpdatePortNameList() => SerialPort.GetPortNames().ToList();

    }

    public interface ISerialPortCom
    {
        SerialPort SerialPort { get; set; }
    }
}
