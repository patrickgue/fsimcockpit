#ifndef mock_h
#define mock_h

#include <stdbool.h>

#define FOREVER 1==1

class Servo
{
public:
    Servo(const char *name);
    void write(int degr);
    void attach(int pin);
private:
    const char *name;
};


class Stepper
{
public:
    Stepper(const char *name);
    void setSpeed(int);
private:
    const char *name;
};


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

#endif
