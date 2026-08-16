$fn=30;

screw_offset=32;
stepper_screw_offset=35/2;
difference() {
    union() {
        // four main pillars
        for (i = [-screw_offset:2*screw_offset:screw_offset]) {

            for (j = [-screw_offset:2*screw_offset:screw_offset]) {
                translate([i, j, 0]) {
                    cylinder(d=6,h=7.5);
                }
            }
        }
        // stepper mounting bracket
        translate([0,screw_offset + .5,4+(3.5/2)])
            cube([2*screw_offset + 6, 7, 3.5],center=true);
        
        for (i = [-screw_offset:2*screw_offset:screw_offset]) {
            translate([i + .5,0,6])
                cube([7, 2*screw_offset + 6, 3],center=true);
        }
        
        translate([0, 0 ,4.5])
            cylinder(d=10,h=3);
        
        rotate([0,0,45])
            translate([0,-23, 6])
            cube([7, sqrt(2) * screw_offset, 3],center=true);
        
        rotate([0,0,-45])
            translate([0,-23, 6])
            cube([7, sqrt(2) * screw_offset, 3],center=true);
    }

    for (i = [-screw_offset:2*screw_offset:screw_offset]) {
        for (j = [-screw_offset:2*screw_offset:screw_offset]) {
            translate([i, j, 0])
                cylinder(d=3,h=8);
        }
    }
    
    // center hole for connecting other gears
    // 1000 ft has a diameter of 2mm -> 2.2mm
    cylinder(d=2.2, h=10);
    
    // additional space for gear
    translate([0,screw_offset,4])
        cube([28,8,2],center=true);
    
    for (i = [-stepper_screw_offset:2*stepper_screw_offset:stepper_screw_offset]) {
        translate([i, screw_offset + 1, 0])
            cylinder(d=3,h=8);
    }
}