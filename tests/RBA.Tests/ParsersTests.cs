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
        var mapService = new MapService();

        // var parsedData = parserService.Parse(input.ToArray());

        var robotService = new RobotService(parserService, mapService);

        // Act
        var sut = robotService.Execute(input.ToArray());

        // Assert
        Assert.NotNull(input);
        Assert.NotNull(expectedResults);
        // Assert.NotNull(parsedData.Grid);
        // Assert.Equal(expectedGridCoordinates, parsedData.Grid.Coordinate);

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
