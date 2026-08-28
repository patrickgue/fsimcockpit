$fn=150;

size = 84;
height = 3;
inset = 10;
screw_offset=32;

difference() {
union() {
translate([-(size/2), -(size/2), 0])
chamfered_box([size, size, height], inset);
    difference() {
        translate([0, 0, 3])
            cylinder(d=78, h=7);
            
        translate([0, 0, 3])
            cylinder(d=70, h=8);
    }
}
translate([0, 0, 0])
    cylinder(d=4.1, h=10);
for (i = [-screw_offset:2*screw_offset:screw_offset]) {
    for (j = [-screw_offset:2*screw_offset:screw_offset]) {
        translate([i, j, 0])
            cylinder(d=3,h=4);
    }
}
}



module chamfered_box(dim, c) {
    x = dim[0];
    y = dim[1];
    z = dim[2];

    polyhedron(
        points = [
            // Bottom ring
            [c,   0,   0],
            [x-c, 0,   0],
            [x,   c,   0],
            [x,   y-c, 0],
            [x-c, y,   0],
            [c,   y,   0],
            [0,   y-c, 0],
            [0,   c,   0],

            // Top ring
            [c,   0,   z],
            [x-c, 0,   z],
            [x,   c,   z],
            [x,   y-c, z],
            [x-c, y,   z],
            [c,   y,   z],
            [0,   y-c, z],
            [0,   c,   z]
        ],

        faces = [
            [0,1,2,3,4,5,6,7],       // bottom
            [8,15,14,13,12,11,10,9], // top

            [0,8,9,1],               // front
            [1,9,10,2],              // right
            [2,10,11,3],              // back
            [3,11,12,4],              // back-right
            [4,12,13,5],              // back
            [5,13,14,6],              // left
            [6,14,15,7],              // front-left
            [7,15,8,0]                // front
        ]
    );
}