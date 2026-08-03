namespace fsimcockpit.serial_connector;

public enum DataType
{
    VSI, // vertical speed in ft/min
    VSI_CALIBR_ZERO, // in degrees (stepper)
    VSI_CALIBR_PLUS5, // in degrees (stepper)
    VSI_CALIBR_MINUS5, // in degrees (stepper)

    HI, // Heading Indicator in degrees
    HI_CALIBR_ZERO,

    SPEED, // airspeed in kt
    SPEED_CALIBR_ZERO, // in degrees (servo)
    SPEED_CALIBR_HUNDRED, // in degrees (servo)

    ALT, // altitude in ft
    ALT_CALIBR_HUNDREDS_ZERO, // in degrees (stepper)
    ALT_CALIBR_THOUSANDS_ZERO, // in degrees (stepper)
    ALT_CALIBR_TENTHOUSANDS_ZERO, // in degrees (stepper)

    TS_TURN, // turn indicator in turns / 2*minute
    TS_TURN_CALIBR_ZERO, // in degrees (servo)
    TS_TURN_CALIBR_LEFTTURN, // in degrees (servo)
    TS_TURN_CALIBR_RIGHTTURN, // in degrees (servo)

    
    TS_SLIP, // slip indicator (-1.0 left, 1.0 right)
    TS_SLIP_CALIBR_ZERO, // in degrees (servo)
    TS_SLIP_CALIBR_LEFT, // in degrees (servo)
    TS_SLIP_CALIBR_RIGHT, // in degrees (servo)

    AI_PITCH, // attitude indicator (degrees)
    AI_PITCH_CALIBR_20ZERO, // in degrees (stepper)
    AI_PITCH_CALIBR_20UP, // in degrees (stepper)
    AI_PITCH_CALIBR_20DOWN, // in degrees (stepper)

    AI_ROL, // attitude roll (degrees)
    AI_ROL_CALIBR_20ZERO, // in degrees (stepper)
    AI_ROL_CALIBR_20LEFT, // in degrees (stepper)
    AI_ROL_CALIBR_20RIGHT, // in degrees (stepper)
}

public class DataTypeHelper
{
    public static byte GetId(DataType type)
    {
        switch (type)
        {
        case DataType.VSI:
            return 0x10;
        case DataType.VSI_CALIBR_ZERO:
            return 0x11;
        case DataType.VSI_CALIBR_PLUS5:
            return 0x12;
        case DataType.VSI_CALIBR_MINUS5:
            return 0x13;
            
        case DataType.HI:
            return 0x20;
        case DataType.HI_CALIBR_ZERO:
            return 0x21;

        case DataType.SPEED:
            return 0x30;
        case DataType.SPEED_CALIBR_ZERO:
            return 0x31;
        case DataType.SPEED_CALIBR_HUNDRED:
            return 0x32;

        case DataType.ALT:
            return 0x40;
        case DataType.ALT_CALIBR_HUNDREDS_ZERO:
            return 0x41;
        case DataType.ALT_CALIBR_THOUSANDS_ZERO:
            return 0x42;
        case DataType.ALT_CALIBR_TENTHOUSANDS_ZERO:
            return 0x43;

        case DataType.TS_TURN:
            return 0x50;
        case DataType.TS_TURN_CALIBR_ZERO:
            return 0x51;
        case DataType.TS_TURN_CALIBR_LEFTTURN:
            return 0x52;
        case DataType.TS_TURN_CALIBR_RIGHTTURN:
            return 0x53;

        case DataType.TS_SLIP:
            return 0x54;
        case DataType.TS_SLIP_CALIBR_ZERO:
            return 0x55;
        case DataType.TS_SLIP_CALIBR_LEFT:
            return 0x56;
        case DataType.TS_SLIP_CALIBR_RIGHT:
            return 0x57;

        case DataType.AI_PITCH:
            return 0x60;
        case DataType.AI_PITCH_CALIBR_20ZERO:
            return 0x61;
        case DataType.AI_PITCH_CALIBR_20UP:
            return 0x62;
        case DataType.AI_PITCH_CALIBR_20DOWN:
            return 0x63;
        case DataType.AI_ROL:
            return 0x64;
        case DataType.AI_ROL_CALIBR_20ZERO:
            return 0x65;
        case DataType.AI_ROL_CALIBR_20LEFT:
            return 0x66;
        case DataType.AI_ROL_CALIBR_20RIGHT:
            return 0x67;
            
        default:
            return 0xff;
        }
    }
}
