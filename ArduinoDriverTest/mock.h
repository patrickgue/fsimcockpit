#ifndef mock_h
#define mock_h

#include <stdbool.h>

#define FOREVER 1==1

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
    void (*readBytes)(char *, int);
};

void delay(int);

void init_mock_serial(struct t_Serial *ser);
void init_mock_stepper(Stepper *stepper);
void init_mock_servo(Servo *servo);

#endif
