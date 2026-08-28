include <../common/gears.scad>

spur_gear(modul=2, tooth_number=12, width=5, bore=2, pressure_angle=0, helix_angle=0, optimized=true);

translate([30,0,0])
difference() {
    spur_gear(modul=2, tooth_number=12, width=5, bore=2,        pressure_angle=0, helix_angle=0, optimized=true);
    cube([5,3,10],center=true);
}