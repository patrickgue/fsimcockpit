using System.IO.Ports;

namespace fsimcockpit.serial_connector;

public class SerialClient
{
    private SerialPort serialPort;

    /* Serial Settings compatible with Arduino */
    private const int BAUD_RATE = 9600;
    private const Parity PARITY = Parity.None;
    private const StopBits STOP_BITS = StopBits.One;
    private const int DATA_BITS = 8;
    private const Handshake HANDSHAKE = Handshake.None;
    private const int TIMEOUT = 500;

    public SerialClient(string portName)
    {
        if (!SerialPortList().Contains(portName))
        {
            throw new Exception($"No Serial Port with name {portName} found");
        }

        serialPort = new SerialPort();
        serialPort.PortName = portName;
        serialPort.BaudRate = BAUD_RATE;
        serialPort.Parity = PARITY;
        serialPort.StopBits = STOP_BITS;
        serialPort.DataBits = DATA_BITS;
        serialPort.Handshake = HANDSHAKE;
        serialPort.ReadTimeout = TIMEOUT;
        serialPort.WriteTimeout = TIMEOUT;
    }

    public void SendBytes(byte[] bytes, int count)
    {
        serialPort.Write(bytes, 0, count);
    }

    public static string[] SerialPortList()
    {
        return SerialPort.GetPortNames();
    }
}
