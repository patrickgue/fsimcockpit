namespace fsimcockpit.serial_connector;

public class ArduinoConnector
{
    private SerialClient client;

    public ArduinoConnector(string serialPortName)
    {
        client = new SerialClient(serialPortName);
    }

    public void SetSerialPort(string serialPortName)
    {
        client = new SerialClient(serialPortName);
    }
    
    public void SendDataItem(DataType type, float value)
    {
        byte[] bytes = BitConverter.GetBytes(value);
        byte id = DataTypeHelper.GetId(type);

        byte[] payload = new byte[5];
        payload[0] = id;

        for (int i = 0; i < 4; i++)
            payload[i + 1] = bytes[i];

        client.SendBytes(payload, 5);
    }
}
