

#ifdef mock
#include <string.h>
#include "mock.h"
struct t_Serial Serial;
#else
#include <Servo.h>
#include <Stepper.h>
#endif

#include "codes.h"

/* Stepper */
#define OUTPUT1   6                // Connected to the Blue coloured wire
#define OUTPUT2   7                // Connected to the Pink coloured wire
#define OUTPUT3   8                // Connected to the Yellow coloured wire
#define OUTPUT4   9                // Connected to the Orange coloured wire

const int stepsPerRotation = 2048;  // 28BYJ-48 has 2048 steps per rotation in full step mode as given in data sheet

#ifdef mock

Stepper myStepper;

Stepper HI_Step,
    SPEED_Step,
    ALT100_Step,
    ALT1000_Step,
    ALT10000_Step,
    AI_PITCH_Step,
    AI_ROLL_Step;

#else

Stepper myStepper(stepsPerRotation, OUTPUT1, OUTPUT3, OUTPUT2, OUTPUT4);

#endif
/* Servo */
Servo VSI_Servo, TS_TURN_Servo, TS_SLIP_Servo;
// twelve servo objects can be created on most boards


int pos = 0;    // variable to store the servo position
const int del = 30;


typedef unsigned char byte;



typedef union
{
    byte float_parts[4];
    float f;
} float_parts;

byte buffer[5];
float_parts float_buffer;
byte code;

typedef struct
{
    float vsi;
    float hi;
    float speed;
    float alt_100, alt_1000, alt_10000;
    float ts_turn, ts_slip;
    float ai_pitch, ai_roll;
} ServoState;

typedef struct
{
    bool vsi;
    bool hi;
    bool speed;
    bool alt_100, alt_1000, alt_10000;
    bool ts_turn, ts_slip;
    bool ai_pitch, ai_roll;
} ServoCalibration;

ServoState State;
ServoCalibration Calibration;

void setup() {
    VSI_Servo.attach(3);  // attaches the servo on pin 7
    myStepper.setSpeed(15);
    Serial.begin(9600);
}

void loop()
{

    if (Serial.available())
    {
        Serial.readBytes((char*)buffer, 5);
        code = buffer[0];
        memcpy(float_buffer.float_parts, buffer + 1, 4);

        switch (code)
        {
        case VSI:

        }

    }
    VSI_Servo.write(pos);
}

void loop2() {
    // goes from 0 degrees to 180 degrees
    for (pos = 0; pos <= 180; pos += 1) {
        VSI_Servo.write(pos);    // tell servo to go to position in variable 'pos'
        delay(del);               // waits 15ms for the servo to reach the position
    }
    //  myStepper.step(stepsPerRotation);
    delay(500);
    // goes from 180 degrees to 0 degrees
    for (pos = 180; pos >= 0; pos -= 1) {
        VSI_Servo.write(pos);    // tell servo to go to position in variable 'pos'
        delay(del);               // waits 15ms for the servo to reach the position
    }
    //  myStepper.step(-stepsPerRotation);
    delay(500);
}



#ifdef mock
int main()
{
    init_mock_serial(&Serial);
    init_mock_stepper(&myStepper);
    init_mock_servo(&VSI_Servo);
    setup();
    while (FOREVER)
    {
        loop();
    }
}
#endif
