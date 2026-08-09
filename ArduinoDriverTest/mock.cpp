#include <stdio.h>
#include <unistd.h>
#include <string.h>

#include "mock.h"

/****************
 * MOCK STEPPER *
 ****************/

Stepper::Stepper(const char *name) : name(name)
{}

void Stepper::setSpeed(int speed)
{
    printf("STEPPER SET SPEED %s: %i\n", name, speed);
}


/**************
 * MOCK SERVO *
 **************/

Servo::Servo(const char *name) : name(name)
{}

void Servo::write(int degr)
{
    printf("SERVO WRITE %s: %i\n", name, degr);
}

void Servo::attach(int pin)
{
    printf("SERVO ATTACH %s: PIN %i\n", name, pin);
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
