using RBA.Tests.Application.Services;
using RBA.Tests.Domain.Entities;
using RBA.Tests.Domain.Enums;
using RBA.Tests.UnitTests.TestData;

namespace RBA.Tests.UnitTests.ServiceTests;

public class MapServiceTests
{
    private readonly MapService _sut = new();

    [Theory]
    [MemberData(nameof(MapTestData.ValidRightTurn), MemberType = typeof(MapTestData))]
    public void TurnRight_ShouldReturnExpectedFacing(CardinalType input, CardinalType expected)
    {
        // Arrange & Act
        var result = _sut.TurnRight(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(MapTestData.ValidLeftTurn), MemberType = typeof(MapTestData))]
    public void TurnLeft_ShouldReturnExpectedFacing(CardinalType input, CardinalType expected)
    {
        // Arrange & Act
        var result = _sut.TurnLeft(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(MapTestData.InstructionData), MemberType = typeof(MapTestData))]
    public void GetInstructionType_ShouldReturnExpectedInstruction(string raw, InstructionType expected)
    {
        // Arrange & Act
        var result = _sut.GetInstructionType(raw);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(MapTestData.CardinalData), MemberType = typeof(MapTestData))]
    public void GetUpdateCoordinateWith_ShouldReturnExpectedCardinal(CardinalType facing, Coordinate expectedCoordinate)
    {
        // Arrange & Act
        var result = _sut.GetUpdateCoordinateWith(facing);

        // Assert
        Assert.Equal(expectedCoordinate.X, result.X);
        Assert.Equal(expectedCoordinate.Y, result.Y);
    }
}