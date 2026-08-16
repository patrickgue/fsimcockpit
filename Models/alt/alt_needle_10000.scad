$fn = 100;

length    = 32;
shaft_w   = 1.5;
triangle_w = 7;
triangle_l = 7;
thickness = 1.2;

difference() {
    union() {

        // Long, thin 10,000-ft hand
        translate([length / 2, 0, 0])
            cube([length, shaft_w, thickness], center=true);

        // Inward-pointing triangular tip
        //
        // Point of triangle faces toward the center (left)
        translate([length, 0, 0])
            linear_extrude(height=thickness, center=true)
                polygon([
                    [-triangle_l, 0],
                    [0, -triangle_w/2],
                    [0,  triangle_w/2]
                ]);

        // Hub
        cylinder(d=8, h=thickness, center=true);
    }

    // Shaft hole
    cylinder(d=4, h=5, center=true);
}