#include <unistd.h>

#include "mock.h"


void init_mock_stepper(Stepper *stepper)
{

}

void init_mock_servo(Servo *servo)
{

}


void delay(int d)
{
    usleep(d * 1000);
}
