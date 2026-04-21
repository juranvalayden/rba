using RBA.Domain.Entities;
using RBA.Domain.Enums;
using RBA.Infrastructure.Services;
using RBA.Tests.TestData;

namespace RBA.Tests.ServiceTests;

public class ValidationServiceTests
{
    private readonly ValidationService _sut = new();

    [Theory]
    [MemberData(nameof(ValidationTestData.InvalidGridData), MemberType = typeof(ValidationTestData))]
    public void ValidateGrid_ShouldThrow_ForInvalidInputs(string line, string expectedMessage)
    {
        // Arrange & Act
        var ex = Assert.Throws<InvalidOperationException>(() => _sut.ValidateGrid(line));

        // Assert
        Assert.Equal(expectedMessage, ex.Message);
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
        var ex = Assert.Throws<InvalidOperationException>(() => _sut.ValidateCardinalType(line));

        // Assert
        Assert.Equal(expectedMessage, ex.Message);
    }

    [Theory]
    [MemberData(nameof(ValidationTestData.ValidCardinalData), MemberType = typeof(ValidationTestData))]
    public void ValidateCardinalType_ShouldReturnCardinal_ForValidInputs(string line, CardinalType expectedFacing)
    {
        // Arrange & Act
        var facing = _sut.ValidateCardinalType(line);

        // Assert
        Assert.Equal(expectedFacing, facing);
    }

    [Theory]
    [MemberData(nameof(ValidationTestData.InvalidStartingBlockData), MemberType = typeof(ValidationTestData))]
    public void ValidateStartingBlock_ShouldThrow_ForInvalidInputs(string line, string expectedMessage)
    {
        // Arrange
        var grid = new Grid(new Coordinate(20, 12));

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => _sut.ValidateStartingBlock(grid, line));

        // Assert
        Assert.Equal(expectedMessage, ex.Message);
    }

    [Theory]
    [MemberData(nameof(ValidationTestData.ValidStartingBlockData), MemberType = typeof(ValidationTestData))]
    public void ValidateStartingBlock_ShouldReturnCoordinate_ForValidInputs(string line, int expectedX, int expectedY)
    {
        // Arrange
        var grid = new Grid(new Coordinate(20, 12));

        // Act
        var coord = _sut.ValidateStartingBlock(grid, line);

        // Assert
        Assert.Equal(expectedX, coord.X);
        Assert.Equal(expectedY, coord.Y);
    }

    [Theory]
    [MemberData(nameof(ValidationTestData.InvalidInstructionData), MemberType = typeof(ValidationTestData))]
    public void ValidateRobotInstructions_ShouldThrow_ForInvalidInputs(string line, string expectedMessage)
    {
        // Arrange & Act
        var ex = Assert.Throws<InvalidOperationException>(() => _sut.ValidateRobotInstructions(line));

        // Assert
        Assert.Equal(expectedMessage, ex.Message);
    }

    [Theory]
    [MemberData(nameof(ValidationTestData.ValidInstructionData), MemberType = typeof(ValidationTestData))]
    public void ValidateRobotInstructions_ShouldReturnInstructions_ForValidInputs(string line, int expectedCount)
    {
        // Arrange & Act
        var instructions = _sut.ValidateRobotInstructions(line);

        // Assert
        Assert.Equal(expectedCount, instructions.Length);
    }
}