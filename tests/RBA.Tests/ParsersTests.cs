using RBA.Infrastructure.Interfaces;
using RBA.Infrastructure.Services;

namespace RBA.Tests;

public class ParsersTests
{
    // I would normally moq these
    private readonly RobotService _sut = new(new ParserService(), new MapService());

    [Theory]
    [MemberData(nameof(AsPerCodingChallenge))]
    public void Execute_Should_ProduceTheSampleOutputAsCodingExercise(IEnumerable<string> input, IEnumerable<string> expectedResults)
    {
        // Arrange
        var sampleInputData = input.ToArray();
        var sampleExpectedResults = expectedResults.ToArray();

        // Act
        var results = _sut.Execute(sampleInputData);

        // Assert
        var index = 0;
        foreach (var result in results)
        {
            Assert.Equal(result, sampleExpectedResults[index]);
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
