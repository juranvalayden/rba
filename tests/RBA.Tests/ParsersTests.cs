using RBA.Domain.Entities;
using RBA.Infrastructure.Services;

namespace RBA.Tests;

public class ParsersTests
{
    [Theory]
    [MemberData(nameof(AsPerCodingChallenge))]
    public void SomeMethod_Should_GiveResult(IEnumerable<string> input, IEnumerable<string> expectedResults)
    {
        // Arrange
        var expectedGridCoordinates = new Coordinate(5, 3);
        var parserService = new ParserService();
        var parsedData = parserService.Parse(input.ToArray());

        var robotService = new RobotService(parsedData);

        // Act
        // var sut = robotService.Execute();

        // Assert
        Assert.NotNull(input);
        Assert.NotNull(expectedResults);
        Assert.NotNull(parsedData.grid);
        Assert.Equal(expectedGridCoordinates, parsedData.grid.Coordinate);

        // Assert.Equal(sut, expectedResults);
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
