using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;


namespace BalansGUI.core.Communication.Serial
{
    public class SerialComm
    {
        public SerialCommObject SerialObject { get; set; }

        private SerialPort SerialPort { get; set; }

        public bool IsConnected = false;

        public SerialComm(string PortName,int BaudRate, int DataBits, byte Parity, byte StopBits)
        {
            SerialObject.PortName = PortName;
            SerialObject.BaudRate = BaudRate;
            SerialObject.DataBits = DataBits;
            SerialObject.Parity = Parity;
            SerialObject.StopBits = StopBits;

            SerialPort = new SerialPort();

        }

        public bool GetConnectionStatus() => SerialPort.IsOpen;

        private void AssignSerialPortParameters()
        {
            SerialPort.PortName = SerialObject.PortName;
            SerialPort.BaudRate = SerialObject.BaudRate;
            SerialPort.DataBits = SerialObject.DataBits;
            SerialPort.Parity = (Parity)SerialObject.Parity;
        }
              public void Connect()
        {
            AssignSerialPortParameters();

            if (!SerialPort.IsOpen)
            {
                SerialPort.Open();
            }
        }

    }

    public class SerialCommObject
    {
        public string PortName { get; set; }

        public int BaudRate { get; set; }

        public int DataBits { get; set; }

        public byte Parity { get; set; }

        public byte StopBits { get; set; }

    }

}
