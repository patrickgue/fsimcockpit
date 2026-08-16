$fn = 100;

height=1.2;

difference() {
    union() {

        // Short 1000-ft pointer
        // Broad near the tip, narrowing toward the hub
        linear_extrude(height = height, center = true)
            polygon([
                [ 3, -1.5],
                [13, -2.5],
                [17,  0],
                [13,  2.5],
                [ 3,  1.5]
            ]);

        // Hub
        difference() {
            cylinder(d = 8, h = height, center = true);
            cylinder(d = 2, h = height, center = true);
        }

        // Small counterweight on the opposite side
        translate([-5, 0, 0])
            cylinder(d = 5, h = height, center = true);
    }

    // Hub hole
    //cylinder(d = 1, h = 5, center = true);
}