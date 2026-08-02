#ifdef mock
#include "mock.h"
struct t_Serial Serial;
#else

#include <Servo.h>
#include <Stepper.h>

#endif

/* Stepper */
#define OUTPUT1   6                // Connected to the Blue coloured wire
#define OUTPUT2   7                // Connected to the Pink coloured wire
#define OUTPUT3   8                // Connected to the Yellow coloured wire
#define OUTPUT4   9                // Connected to the Orange coloured wire

const int stepsPerRotation = 2048;  // 28BYJ-48 has 2048 steps per rotation in full step mode as given in data sheet

#ifdef mock

Stepper myStepper;

#else

Stepper myStepper(stepsPerRotation, OUTPUT1, OUTPUT3, OUTPUT2, OUTPUT4);

#endif
/* Servo */
Servo myservo;  // create servo object to control a servo
// twelve servo objects can be created on most boards


int pos = 0;    // variable to store the servo position
const int del = 30;



void setup() {
  myservo.attach(3);  // attaches the servo on pin 7
  myStepper.setSpeed(15);
  Serial.begin(9600);
}

void loop()
{
  if (Serial.available())
  {
    pos = Serial.parseInt();
  Serial.println(pos, DEC);
  }
  myservo.write(pos);

}

void loop2() {
  // goes from 0 degrees to 180 degrees
  for (pos = 0; pos <= 180; pos += 1) {
    myservo.write(pos);    // tell servo to go to position in variable 'pos'
    delay(del);               // waits 15ms for the servo to reach the position
  }
  //  myStepper.step(stepsPerRotation);
  delay(500);
  // goes from 180 degrees to 0 degrees
  for (pos = 180; pos >= 0; pos -= 1) {
    myservo.write(pos);    // tell servo to go to position in variable 'pos'
    delay(del);               // waits 15ms for the servo to reach the position
  }
  //  myStepper.step(-stepsPerRotation);
    delay(500);
}


#ifdef mock
int main()
{
    init_mock_stepper(&myStepper);

    setup();
    while (1 == 1)
    {
        loop();
    }
}
#endif
