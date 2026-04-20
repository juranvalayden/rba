using RBA.Infrastructure.Services;

namespace RBA.Tests;

public class ParsersTests
{
    [Theory]
    [MemberData(nameof(AsPerCodingChallenge))]
    public void SomeMethod_Should_GiveResult(IEnumerable<string> input, IEnumerable<string> expectedResults)
    {
        // Arrange
        var parserService = new ParserService();
        var mapService = new MapService();

        var sut = new RobotService(parserService, mapService);

        // Act
        var results = sut.Execute(input.ToArray());

        // Assert
        var er = expectedResults.ToArray();
        int index = 0;
        foreach (var result in results)
        {
            Assert.Equal(result, er[index]);

            ++index;
        }
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
