$fn=150;

difference() {
    color([0.3,0.3,0.3])
    cylinder(d=78, h=7);
    translate([0,0,-1])
    cylinder(d=70, h=9);
}
translate([0,0,1]) {
    color([0.3,0.3,0.3])
    cube([78,2,2],center=true);
    translate([-2,0,0])
    cube([16,4,2],center=true);
    cube([4,20,2],center=true);
    translate([-8,0,0])
        cube([3,12,2],center=true);
    
    
}

translate([10,0,0])
    triangle(5,20,2);

color([1,.4,0]) {
    translate([-35,0,0])
    triangle(5,5,2);
    
    translate([35,0,0])
    rotate([0,0,180])
    triangle(5,5,2);
    
    translate([0,35,0])
    rotate([0,0,270])
    triangle(5,5,2);
    
    translate([0,-35,0])
    rotate([0,0,90])
    triangle(5,5,2);
}

for (i = [-37:74:37]) {
    translate([i,0,7])
        cylinder(d=3,h=2);
    translate([0,i,7])
        cylinder(d=3,h=2);
}


module triangle(width, length, height) {

polyhedron(
  points = [
    // Bottom triangle
    [0, -width/2, 0],
    [0, width/2, 0],
    [length, 0 , 0],
    // Top triangle
    [0, -width/2, height],
    [0, width/2, height],
    [length,0 , height]
  ],
  faces = [
    [0, 1, 2],           // bottom
    [3, 5, 4],           // top (reversed winding)
    [0, 1, 4, 3],        // side 1
    [1, 2, 5, 4],        // side 2
    [0, 3, 5, 2]         // side 3
  ]
);
    
}