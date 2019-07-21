using System.IO.Ports;


namespace BalansGUI.core.Communication.Serial
{
    public class SerialComm : ISerialService
    {
        public SerialCommObject SerialObject { get; set; }

        private SerialPort SerialPort { get; set; }

        public bool IsConnected = false;

        public SerialComm(SerialCommObject serialParameters)
        {
            SerialObject.PortName = serialParameters.PortName;
            SerialObject.BaudRate = serialParameters.BaudRate;
            SerialObject.DataBits = serialParameters.DataBits;
            SerialObject.Parity = serialParameters.Parity;
            SerialObject.StopBits = serialParameters.StopBits;
            SerialPort.Encoding = serialParameters.Encoding;

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

            if (!GetConnectionStatus())
            {
                SerialPort.Open();
            }
            else
            {
                SerialPort.Close();
                Connect();
            }
        }

        public void DisConnect()
        {
            if (GetConnectionStatus()) SerialPort.Close(); 
        }

    }

    public class SerialCommObject
    {
        public string PortName { get; set; }

        public int BaudRate { get; set; }

        public int DataBits { get; set; }

        public byte Parity { get; set; }

        public byte StopBits { get; set; }

        public byte HandShake { get; set; }

        public System.Text.Encoding Encoding { get; set; }
    }

}
