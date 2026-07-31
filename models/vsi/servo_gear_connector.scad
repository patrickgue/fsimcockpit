$fn=60;

difference() {
union() {
cube([28,4,1], center= true);
translate([0,0,0.5])
cylinder(d=6.5,h=2,center=true);
translate([14,0,0])
    cylinder(d=4,h=1,center=true);
translate([-14,0,0])
    cylinder(d=4,h=1,center=true);
}
cylinder(d=2, h=4, center=true);
translate([0,0,1])
cylinder(d=4.8, h=1, center=true);
}