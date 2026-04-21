using RBA.Domain.Entities;
using RBA.Domain.Enums;

namespace RBA.Tests.TestData;

public static class ParseTestData
{
    public static List<object[]> InvalidParseData =>
    [
        [Array.Empty<string>(), typeof(ArgumentNullException)],
        [new[] { "" }, typeof(InvalidOperationException)],
        [new[] { "5 3" }, typeof(InvalidOperationException)]
    ];

    public static List<object[]> ValidParseData =>
    [
        [
            new[]{"5 3", "1 1 E", "RFRFRFRF"},
            new Grid(new Coordinate(5, 3)),
            new Coordinate(1, 1),
            CardinalType.E,
            new[] { InstructionType.R, InstructionType.F }
        ]
    ];
}