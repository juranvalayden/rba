using RBA.Infrastructure.Services;

namespace RBA.Tests;

public class ParsersTests
{
    [Theory]
    [MemberData(nameof(AsPerCodingChallenge))]
    public void SomeMethod_Should_GiveResult(IEnumerable<string> input, IEnumerable<string> expectedResults)
    {
        // Arrange
        // input pattern
        // >> step 01: 1st line     = grid data
        // >> step 02: blank line
        // >> step 03: 2 line pairs = robot data
        // >> step 04: >>   line[0] = starting point     = 1 1 E which x, y, direction facing
        // >> step 05: >>   line[1] = robot instructions = "R", "L" and "F" (TurnLeft, TurnRight and Move)
        // >> step 06: blank line
        // >> step 07: repeats steps 03 to steps 06 until EOF

        // parsedData
        // should have grid data for mars area
        // should have robot data for 

        var parserService = new ParserService();
        var parsedData = parserService.Parse(input);

        var robotService = new RobotService(parsedData);

        // Act
        var sut = robotService.Execute();

        // Assert
        Assert.NotNull(input);
        Assert.NotNull(expectedResults);

        Assert.Equal(sut, expectedResults);
    }

    public static TheoryData<IEnumerable<string>, IEnumerable<string>> AsPerCodingChallenge() => new()
    {
        { _sampleData, _sampleDataExpectedResults }
    };

    private static readonly IEnumerable<string> _sampleData = [
        "5 3",
        "",
        "1 1 E",
        "RFRFRFRF",
        "",
        "3 2 N",
        "FRRFLLFFRRFLL",
        "",
        "0 3 W",
        "LLFFFLFLFL",
        ""
    ];

    private static readonly IEnumerable<string> _sampleDataExpectedResults = [
        "1 1 E",
        "3 3 N LOST",
        "2 3 S"
    ];
}
