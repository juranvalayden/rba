using RBA.Tests.Domain.Enums;

namespace RBA.Tests.UnitTests.TestData;

public static class ValidationTestData
{
    public static List<object[]> InvalidGridData =>
    [
        ["A B", "Invalid coordinates."],
        ["5 5", "Invalid grid values are equal"],
        ["51 2", "Coordinate values should be <= 50."]
    ];

    public static List<object[]> ValidGridData =>
    [
        ["20 12", 20, 12],
        ["15 10", 15, 10]
    ];

    public static List<object[]> InvalidCardinalData =>
    [
        ["", "Starting facing direction not found."],
        ["10 10 Z", "Robot facing is invalid."]
    ];

    public static List<object[]> ValidCardinalData =>
    [
        ["10 10 N", CardinalType.N],
        ["5 5 E", CardinalType.E]
    ];

    public static List<object[]> InvalidStartingBlockData =>
    [
        ["X Y N", "Invalid coordinates."],
        ["25 13 N", "Robot is Lost."],
        ["51 2 E", "Coordinate values should be <= 50."]
    ];

    public static List<object[]> ValidStartingBlockData =>
    [
        ["5 5 N", 5, 5],
        ["10 10 E", 10, 10]
    ];

    public static List<object[]> InvalidInstructionData =>
    [
        ["", "No robot instructions can be found."],
        [new string('R', 101), "Robot instruction length exceeded 100."],
        ["RXF", "Invalid robot instruction found."]
    ];

    public static List<object[]> ValidInstructionData =>
    [
        ["RLF", 3],
        ["FFR", 3]
    ];

    public static List<object[]> InvalidCoordinateData =>
    [
        ["A B", typeof(InvalidOperationException), "Invalid coordinates."],
        ["100000 5", typeof(InvalidOperationException), "Coordinate values should be <="],
        ["5 100000", typeof(InvalidOperationException), "Coordinate values should be <="]
    ];

    public static List<object[]> ValidCoordinateData =>
    [
        ["5 3", 5, 3],
        ["10 20", 10, 20]
    ];
}