---
title: FSimCockpit
---

Software and Hardware for building a home cockpit with 3d printed "steam gauge" instruments


Components:

* Windows App: Connects to MSFS to read out instrument data. Send this data to the microcontroller via the serial connection. This is built using C# and provides a WPF GUI for instrument calibration.
* Microcontroller: Drive servos and stepper motors for the instrument. Arduino Mega based.
  * Parse instrument data from serial data coming from the windows application
* 3D models for printing, assembly


# Distribution

If not mentioned otherwise, this project is licensed under the MIT license. A copy of the license text is provided in the LICENSE file.

Following external components are used: (License file provided in the subfolder)

* Attitude Indicator (hein4bloed, CC-BY-NC)
* Vertical Speed indicator (Bacab, CC-BY-NC-SA)
* Turn coordinator (Bacab, CC-BY-NC-SA)
