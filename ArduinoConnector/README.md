

Data Table

| **Indication**               | **Code** | **Description**                       |
|------------------------------|---------:|---------------------------------------|
| VSI                          |     0x10 | vertical speed in ft/min              |
| VSI_CALIBR_ZERO              |     0x11 | in degrees (stepper)                  |
| VSI_CALIBR_PLUS5             |     0x12 | in degrees (stepper)                  |
| VSI_CALIBR_MINUS5            |     0x13 | in degrees (stepper)                  |
| HI                           |     0x20 | Heading Indicator in degrees          |
| HI_CALIBR_ZERO,              |     0x21 | in degrees (servo)                    |
| SPEED                        |     0x30 | airspeed in kt                        |
| SPEED_CALIBR_ZERO            |     0x31 | in degrees (servo)                    |
| SPEED_CALIBR_HUNDRED         |     0x32 | in degrees (servo)                    |
| ALT                          |     0x40 | altitude in ft                        |
| ALT_CALIBR_HUNDREDS_ZERO     |     0x41 | in degrees (stepper)                  |
| ALT_CALIBR_THOUSANDS_ZERO    |     0x42 | in degrees (stepper)                  |
| ALT_CALIBR_TENTHOUSANDS_ZERO |     0x43 | in degrees (stepper)                  |
| TS_TURN                      |     0x50 | turn indicator in turns / 2*minute    |
| TS_TURN_CALIBR_ZERO          |     0x51 | in degrees (servo)                    |
| TS_TURN_CALIBR_LEFTTURN      |     0x52 | in degrees (servo)                    |
| TS_TURN_CALIBR_RIGHTTURN     |     0x53 | in degrees (servo)                    |
| TS_SLIP                      |     0x54 | slip indicator (-1.0 left, 1.0 right) |
| TS_SLIP_CALIBR_ZERO          |     0x55 | in degrees (servo)                    |
| TS_SLIP_CALIBR_LEFT          |     0x56 | in degrees (servo)                    |
| TS_SLIP_CALIBR_RIGHT         |     0x57 | in degrees (servo)                    |
| AI_PITCH                     |     0x60 | attitude indicator (degrees)          |
| AI_PITCH_CALIBR_20ZERO       |     0x61 | in degrees (stepper)                  |
| AI_PITCH_CALIBR_20UP         |     0x62 | in degrees (stepper)                  |
| AI_PITCH_CALIBR_20DOWN       |     0x63 | in degrees (stepper)                  |
| AI_ROL                       |     0x64 | attitude roll (degrees)               |
| AI_ROL_CALIBR_20ZERO         |     0x65 | in degrees (stepper)                  |
| AI_ROL_CALIBR_20LEFT         |     0x66 | in degrees (stepper)                  |
| AI_ROL_CALIBR_20RIGHT        |     0x67 | in degrees (stepper)                  |
| ERROR                        |     0xFF | Invalid, should not occur             |
