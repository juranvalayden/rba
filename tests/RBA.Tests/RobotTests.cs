using Moq;
using RBA.Infrastructure.Interfaces;
using RBA.Infrastructure.Services;

namespace RBA.Tests;

public class RobotTests
{
    private readonly Mock<IParserService> _parserService = new();
    private readonly Mock<IMapService> _mapService = new();
    private readonly RobotService _sut;

    public RobotTests()
    {
        _sut = new RobotService(_parserService.Object, _mapService.Object);
    }

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
        { TestData.GetSampleData, TestData.GetSampleExpectedResults }
    };
}
