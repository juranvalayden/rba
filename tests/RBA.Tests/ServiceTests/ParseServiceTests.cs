using Moq;
using RBA.Tests.Entities;
using RBA.Tests.Enums;
using RBA.Tests.Interfaces;
using RBA.Tests.Services;
using RBA.Tests.TestData;

namespace RBA.Tests.ServiceTests;

public class ParseServiceTests
{
    private readonly Mock<IValidationService> _validationService = new();
    private readonly ParserService _sut;

    public ParseServiceTests()
    {
        _sut = new ParserService(_validationService.Object);
    }

    [Theory]
    [MemberData(nameof(ParseTestData.InvalidParseData), MemberType = typeof(ParseTestData))]
    public void Parse_ShouldThrow_ForInvalidInputs(string[] input, Type expectedException)
    {
        // Arrange & Act
        var ex = Record.Exception(() => _sut.Parse(input));

        // Assert
        Assert.NotNull(ex);
        Assert.IsType(expectedException, ex);
    }

    [Theory]
    [MemberData(nameof(ParseTestData.ValidParseData), MemberType = typeof(ParseTestData))]
    public void Parse_ShouldReturnRobotDataSet_ForValidInput(string[] input, Grid expectedGrid, Coordinate expectedCoordinate, CardinalType expectedFacing, InstructionType[] expectedInstructions)
    {
        // Arrange
        _validationService.Setup(v => v.ValidateGrid("5 3")).Returns(expectedGrid);
        _validationService.Setup(v => v.ValidateStartingBlock(expectedGrid, "1 1 E")).Returns(expectedCoordinate);
        _validationService.Setup(v => v.ValidateCardinalType("1 1 E")).Returns(expectedFacing);
        _validationService.Setup(v => v.ValidateRobotInstructions("RFRFRFRF")).Returns(expectedInstructions);

        // Act
        var result = _sut.Parse(input);

        // Assert
        Assert.Single(result);
        Assert.Equal(expectedGrid, result[0].Grid);
        Assert.Equal(expectedCoordinate, result[0].StartingBlock);
        Assert.Equal(expectedFacing, result[0].Robot.Facing);
        Assert.Equal(expectedInstructions, result[0].Instructions);
    }
}