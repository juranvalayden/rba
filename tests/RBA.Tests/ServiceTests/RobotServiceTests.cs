using Moq;
using RBA.Infrastructure.Interfaces;
using RBA.Infrastructure.Services;
using RBA.Tests.TestData;

namespace RBA.Tests.ServiceTests;

public class RobotServiceTests
{
    private readonly Mock<IParserService> _parserService = new();
    private readonly Mock<IMapService> _mapService = new();
    private readonly RobotService _sut;

    public RobotServiceTests()
    {
        _sut = new RobotService(_parserService.Object, _mapService.Object);
    }

    [Theory]
    [MemberData(nameof(RobotTestData.SampleData), MemberType = typeof(RobotTestData))]
    public void Execute_Should_ProduceTheSampleOutputAsCodingExercise(string[] input, string[] expectedResults)
    {
        // Arrange & Act
        var results = _sut.Execute(input);

        // Assert
        for (var i = 0; i < results.Length; i++)
        {
            Assert.Equal(results[i], expectedResults[i]);
        }
    }

    [Theory]
    [MemberData(nameof(RobotTestData.GeneratedData), MemberType = typeof(RobotTestData))]
    public void Execute_Should_UseGeneratedDataTest(string[] input, string[] expectedResults)
    {
        // Arrange & Act
        var results = _sut.Execute(input);

        // Assert
        for (var i = 0; i < results.Length; i++)
        {
            Assert.Equal(results[i], expectedResults[i]);
        }
    }
}