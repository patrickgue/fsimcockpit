namespace fsimcockpit.serial_connector;

public enum DataType
{
    VSI // vertical speed in ft/min
}

public class DataTypeHelper
{
    public static byte GetId(DataType type)
    {
        switch (type)
        {
        case DataType.VSI:
            return 0x10;
        default:
            return 0xff;
        }
    }
}
