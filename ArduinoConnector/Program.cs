namespace fsimcockpit.serial_connector;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Available Serial devices:");
        foreach (var com in SerialClient.SerialPortList())
        {
            Console.WriteLine($"{com}");
        }

        var port = "COM3";

        if (args.Length > 0)
        {
            port = args.Last();
        }

        new ArduinoConnector(port);
    }
}
