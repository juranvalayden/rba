using RBA.Tests.Entities;
using RBA.Tests.Enums;

namespace RBA.Tests.TestData;

public static class MapTestData
{
    public static List<object[]> ValidRightTurn =>
    [
        [ CardinalType.N, CardinalType.E ],
        [ CardinalType.E, CardinalType.S ],
        [ CardinalType.S, CardinalType.W ],
        [ CardinalType.W, CardinalType.N ]
    ];

    public static List<object[]> ValidLeftTurn =>
    [
        [ CardinalType.N, CardinalType.W ],
        [ CardinalType.E, CardinalType.N ],
        [ CardinalType.S, CardinalType.E ],
        [ CardinalType.W, CardinalType.S ]
    ];

    public static List<object[]> InstructionData =>
    [
        [ "R", InstructionType.R ],
        [ "L", InstructionType.L ],
        [ "F", InstructionType.F ],
        [ "X", InstructionType.Unknown ],
        [ "", InstructionType.Unknown ]        
    ];

    public static List<object[]> CardinalData =>
    [
        [ CardinalType.N, new Coordinate(0, 1) ],
        [ CardinalType.W, new Coordinate(-1, 0) ],
        [ CardinalType.S, new Coordinate(0, -1) ],
        [ CardinalType.E, new Coordinate(1, 0) ]
    ];
}