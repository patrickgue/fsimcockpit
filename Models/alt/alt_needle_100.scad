$fn=100;

height=1.5;

difference() {

    union() {

        cube([42,3,height], center=true);

        translate([10,0,0])
            cylinder(d=8,h=height,center=true);

        translate([21,0,0])
            cylinder(d=3.5,h=height,center=true);
    }


    translate([10,0,0])
        cylinder(d=1,h=height+1,center=true);


    translate([-22,1.5,0])
        rotate([0,0,20])
            cube([10,3,height+1],center=true);

    translate([-22,-1.5,0])
        rotate([0,0,-20])
            cube([10,3,height+1],center=true);
}