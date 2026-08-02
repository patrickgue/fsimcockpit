namespace fsimcockpit.serial_connector;

public class Program
{
    public static void Main(string[] args)
    {
        foreach (var com in SerialClient.SerialPortList())
        {
            Console.WriteLine($"{com}");
        }

        var port = "/dev/pts/3";

        if (args.Length > 0)
        {
            port = args.Last();
        }

        new ArduinoConnector(port);
    }
}
