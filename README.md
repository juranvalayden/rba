# RBA
An implementation of the "Martian Robots" following the spec documentation provided

# Planning (Test)
input pattern
// >> step 01: 1st line     = grid data
// >> step 02: blank line
// >> step 03: 2 line pairs = robot data
// >> step 04: >>   line[0] = starting point     = 1 1 E which x, y, direction facing
// >> step 05: >>   line[1] = robot instructions = "R", "L" and "F" (TurnLeft, TurnRight and Move)
// >> step 06: blank line
// >> step 07: repeats steps 03 to steps 06 until EOF

// parsedData
// should have grid data for mars area
// should have robot data for robot start and instructions