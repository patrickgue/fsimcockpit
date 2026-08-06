#include <stdio.h>
#include <unistd.h>

#include "mock.h"

/****************
 * MOCK STEPPER *
 ****************/

void stepper_setSpeed(int speed)
{
    printf("STEPPER setSpeed %d\n", speed);
}

void init_mock_stepper(Stepper *stepper)
{
    stepper->setSpeed = stepper_setSpeed;
}


/**************
 * MOCK SERVO *
 **************/

void servo_attach(int pin)
{
    printf("SERVO attach on Pin %d\n", pin);
}

void servo_write(int degr)
{
    printf("SERVO write %d degr\n", degr);
}

void init_mock_servo(Servo *servo)
{
    servo->attach = servo_attach;
    servo->write = servo_write;
}

/***************
 * MOCK SERIAL *
 ***************/

void serial_begin(int baud)
{
    printf("SERIAL begin with baud rate %d\n", baud);
}

int serial_parseInt()
{
    return 10;
}

bool serial_available()
{
    return true;
}

void serial_readBytes(char *buffer, int c)
{
    int i;
    for (i = 0; i < c; i++)
    {
        buffer[i] = i;
    }
}

void serial_println(int i, enum e_SerialPrintMode mode)
{
    switch (mode)
    {
    case HEX:
        printf("SERIAL %x\n", i);
        break;
    case DEC:
        printf("SERIAL %d\n", i);
        break;
    }
}


void init_mock_serial(struct t_Serial *ser)
{
    ser->available = serial_available;
    ser->begin = serial_begin;
    ser->parseInt = serial_parseInt;
    ser->println = serial_println;
    ser->readBytes = serial_readBytes;
}


void delay(int d)
{
    usleep(d * 1000);
}
