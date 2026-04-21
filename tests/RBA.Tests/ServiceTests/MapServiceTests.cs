using RBA.Domain.Enums;
using RBA.Infrastructure.Services;

namespace RBA.Tests.ServiceTests;

public class MapServiceTests
{
    private readonly MapService _sut = new();

    [Theory]
    [InlineData(CardinalType.N, CardinalType.E)]
    [InlineData(CardinalType.E, CardinalType.S)]
    public void TurnRight_ShouldReturnExpectedFacing(CardinalType input, CardinalType expected)
    {
        // Arrange & Act
        var result = _sut.TurnRight(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(CardinalType.N, CardinalType.W)]
    [InlineData(CardinalType.W, CardinalType.S)]
    public void TurnLeft_ShouldReturnExpectedFacing(CardinalType input, CardinalType expected)
    {
        // Arrange & Act
        var result = _sut.TurnLeft(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("R", InstructionType.R)]
    [InlineData("L", InstructionType.L)]
    [InlineData("F", InstructionType.F)]
    [InlineData("X", InstructionType.Unknown)]
    [InlineData("", InstructionType.Unknown)]
    public void GetInstructionType_ShouldReturnExpectedInstruction(string raw, InstructionType expected)
    {
        // Arrange & Act
        var result = _sut.GetInstructionType(raw);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(CardinalType.N, 0, 1)]
    [InlineData(CardinalType.S, 0, -1)]
    [InlineData(CardinalType.E, 1, 0)]
    [InlineData(CardinalType.W, -1, 0)]
    public void GetUpdateCoordinateWith_ShouldReturnExpectedDelta(CardinalType facing, int expectedX, int expectedY)
    {
        // Arrange & Act
        var result = _sut.GetUpdateCoordinateWith(facing);

        // Assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }
}