$fn=30;

screw_offset=32;
stepper_screw_offset=35/2;
difference() {
    union() {
        // four main pillars
        for (i = [-screw_offset:2*screw_offset:screw_offset]) {

                translate([i, screw_offset, 0]) {
                    cylinder(d=6,h=7.5);
                }
        }
        // stepper mounting bracket
        translate([0,screw_offset + .5,4+(3.5/2)])
            cube([2*screw_offset + 6, 7, 3.5],center=true);
        
        
    }

    for (i = [-screw_offset:2*screw_offset:screw_offset]) {
        translate([i, screw_offset, 0])
            cylinder(d=3,h=8);
    }
    
    
    // additional space for gear
    translate([0,screw_offset,4])
        cube([28,8,2],center=true);
    
    for (i = [-stepper_screw_offset:2*stepper_screw_offset:stepper_screw_offset]) {
        translate([i, screw_offset + 1, 0])
            cylinder(d=3,h=8);
    }
}