using RBA.Domain.Entities;
using RBA.Domain.Enums;
using RBA.Infrastructure.Services;
using RBA.Tests.TestData;
using Xunit;

namespace RBA.Tests.ServiceTests;

public class ValidationServiceTests
{
    private readonly ValidationService _sut = new();

    [Theory]
    [MemberData(nameof(ValidationTestData.InvalidGridData), MemberType = typeof(ValidationTestData))]
    public void ValidateGrid_ShouldThrow_ForInvalidInputs(string line, string expectedMessage)
    {
        // Arrange & Act
        var expectedException = Assert.Throws<InvalidOperationException>(() => _sut.ValidateGrid(line));

        // Assert
        Assert.Equal(expectedMessage, expectedException.Message);
    }

    [Theory]
    [MemberData(nameof(ValidationTestData.ValidGridData), MemberType = typeof(ValidationTestData))]
    public void ValidateGrid_ShouldReturnGrid_ForValidInputs(string line, int expectedX, int expectedY)
    {
        // Arrange & Act
        var grid = _sut.ValidateGrid(line);

        // Assert
        Assert.Equal(expectedX, grid.Coordinate.X);
        Assert.Equal(expectedY, grid.Coordinate.Y);
    }

    [Theory]
    [MemberData(nameof(ValidationTestData.InvalidCardinalData), MemberType = typeof(ValidationTestData))]
    public void ValidateCardinalType_ShouldThrow_ForInvalidInputs(string line, string expectedMessage)
    {
        // Arrange & Act
        var expectedException = Assert.Throws<InvalidOperationException>(() => _sut.ValidateCardinalType(line));

        // Assert
        Assert.Equal(expectedMessage, expectedException.Message);
    }

    [Theory]
    [MemberData(nameof(ValidationTestData.ValidCardinalData), MemberType = typeof(ValidationTestData))]
    public void ValidateCardinalType_ShouldReturnCardinal_ForValidInputs(string line, CardinalType expectedFacing)
    {
        // Arrange & Act
        var result = _sut.ValidateCardinalType(line);

        // Assert
        Assert.Equal(expectedFacing, result);
    }

    [Theory]
    [MemberData(nameof(ValidationTestData.InvalidStartingBlockData), MemberType = typeof(ValidationTestData))]
    public void ValidateStartingBlock_ShouldThrow_ForInvalidInputs(string line, string expectedMessage)
    {
        // Arrange & Act
        var grid = new Grid(new Coordinate(20, 12));
        var expectedException = Assert.Throws<InvalidOperationException>(() => _sut.ValidateStartingBlock(grid, line));

        // Assert
        Assert.Equal(expectedMessage, expectedException.Message);
    }

    [Theory]
    [MemberData(nameof(ValidationTestData.ValidStartingBlockData), MemberType = typeof(ValidationTestData))]
    public void ValidateStartingBlock_ShouldReturnCoordinate_ForValidInputs(string line, int expectedX, int expectedY)
    {
        // Arrange & Act
        var grid = new Grid(new Coordinate(20, 12));
        var result = _sut.ValidateStartingBlock(grid, line);

        // Assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [MemberData(nameof(ValidationTestData.InvalidInstructionData), MemberType = typeof(ValidationTestData))]
    public void ValidateRobotInstructions_ShouldThrow_ForInvalidInputs(string line, string expectedMessage)
    {
        // Arrange & Act
        var expectedException = Assert.Throws<InvalidOperationException>(() => _sut.ValidateRobotInstructions(line));

        // Assert
        Assert.Equal(expectedMessage, expectedException.Message);
    }

    [Theory]
    [MemberData(nameof(ValidationTestData.ValidInstructionData), MemberType = typeof(ValidationTestData))]
    public void ValidateRobotInstructions_ShouldReturnInstructions_ForValidInputs(string line, int expectedCount)
    {
        // Arrange & Act
        var result = _sut.ValidateRobotInstructions(line);

        // Assert
        Assert.Equal(expectedCount, result.Length);
    }

    [Theory]
    [MemberData(nameof(ValidationTestData.InvalidCoordinateData), MemberType = typeof(ValidationTestData))]
    public void ValidateCoordinates_ShouldThrow_ForInvalidInputs(string line, Type expectedExceptionType, string expectedMessagePart)
    {
        // Arrange & Act
        var expectedException = Assert.Throws(expectedExceptionType, () => _sut.ValidateCoordinates(line));

        // Assert
        Assert.Contains(expectedMessagePart, expectedException.Message);
    }

    [Theory]
    [MemberData(nameof(ValidationTestData.ValidCoordinateData), MemberType = typeof(ValidationTestData))]
    public void ValidateCoordinates_ShouldReturnCoordinate_ForValidInputs(string line, int expectedX, int expectedY)
    {
        // Arrange & Act
        var result = _sut.ValidateCoordinates(line);

        // Assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }
}