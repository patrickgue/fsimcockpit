$fn=150;

difference() {
    color([0.3,0.3,0.3])
    cylinder(d=78, h=7);
    translate([0,0,-1])
    cylinder(d=70, h=9);
}
translate([0,0,1]) {
    color([0.3,0.3,0.3])
    translate([0,0,0.1])
    cube([78,2,2],center=true);
    /*translate([-2,0,0])
    cube([16,4,2],center=true);
    cube([4,20,2],center=true);
    translate([-8,0,0])
        cube([3,12,2],center=true);
    */
    translate([0,0,-1])
    aircraft();
    
}

translate([10,0,0])
    triangle(5,20,2);

for (i = [0:45:45]) {
    rotate([0,0,i])
color([1,.4,0]) {
    translate([-35,0,0])
    triangle(3,5,2);
    
    translate([35,0,0])
    rotate([0,0,180])
    triangle(3,5,2);
    
    translate([0,35,0])
    rotate([0,0,270])
    triangle(3,5,2);
    
    translate([0,-35,0])
    rotate([0,0,90])
    triangle(3,5,2);
}
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
            [length, 0, 0],
            // Top triangle
            [0, -width/2, height],
            [0, width/2, height],
            [length, 0, height]
        ],
        faces = [
            [0, 1, 2],           // bottom
            [3, 5, 4],           // top (reversed winding)
            [0, 3, 4, 1],        // front (was [0, 1, 4, 3])
            [1, 4, 5, 2],        // right side (was [1, 2, 5, 4])
            [0, 2, 5, 3]         // left side (was [0, 3, 5, 2])
        ]
    );
}


module aircraft() {

    linear_extrude(height=2)

        polygon(points=[

            // -------------------------
            // Nose
            // -------------------------

            [ 8.0,  0.0],
            [ 7.0,  0.75],
            [ 4.0,  0.90],

            // -------------------------
            // Right wing
            // -------------------------

            [ 2.0,  1.0],
            [ 0.5,  6.8],
            [-1.8,  6.8],
            [-1.0,  1.0],

            // -------------------------
            // Rear fuselage
            // -------------------------

            [-4.8,  0.75],

            // -------------------------
            // Wide tail / stabilizer
            // -------------------------

            [-5.5,  2.2],
            [-7.2,  2.2],
            [-7.7,  1.7],
            [-7.2,  0.0],

            // -------------------------
            // Other side of tail
            // -------------------------

            [-7.7, -1.7],
            [-7.2, -2.2],
            [-5.5, -2.2],

            // -------------------------
            // Rear fuselage
            // -------------------------

            [-4.8, -0.75],

            // -------------------------
            // Left wing
            // -------------------------

            [-1.0, -1.0],
            [-1.8, -6.8],
            [ 0.5, -6.8],
            [ 2.0, -1.0],

            // -------------------------
            // Front fuselage
            // -------------------------

            [ 4.0, -0.90],
            [ 7.0, -0.75]
        ]);
}