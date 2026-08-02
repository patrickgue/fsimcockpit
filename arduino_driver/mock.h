#ifndef mock_h
#define mock_h

#include <stdbool.h>

typedef struct
{
    void (*attach)(int);
    void (*write)(int);
} Servo;

typedef struct
{
    void (*setSpeed)(int);
} Stepper;

enum e_SerialPrintMode
{
    DEC,
    HEX
};

struct t_Serial
{
    void (*begin)(int);
    int (*parseInt)();
    bool (*available)();
    void (*println)(int, enum e_SerialPrintMode);
};

void delay(int);


void init_mock_stepper(Stepper *stepper);
void init_mock_servo(Servo *servo);

#endif
