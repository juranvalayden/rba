using RBA.Tests.Entities;
using RBA.Tests.Enums;
using RBA.Tests.Interfaces;

namespace RBA.Tests.Services;

public class MapService : IMapService
{
    private readonly Dictionary<CardinalType, CardinalType> _turnRightLookup = new()
    {
        { CardinalType.N, CardinalType.E },
        { CardinalType.E, CardinalType.S },
        { CardinalType.S, CardinalType.W },
        { CardinalType.W, CardinalType.N }
    };

    private readonly Dictionary<CardinalType, CardinalType> _turnLeftLookup = new()
    {
        { CardinalType.N, CardinalType.W },
        { CardinalType.W, CardinalType.S },
        { CardinalType.S, CardinalType.E },
        { CardinalType.E, CardinalType.N }
    };

    private readonly Dictionary<CardinalType, Coordinate> _updateCoordinateWithLookup = new()
    {
        { CardinalType.N, new Coordinate(0, 1) },
        { CardinalType.W, new Coordinate(-1, 0) },
        { CardinalType.S, new Coordinate(0, -1) },
        { CardinalType.E, new Coordinate(1, 0) }
    };

    private readonly Dictionary<string, InstructionType> _robotInstructionLookup = new()
    {
        { "R", InstructionType.R },
        { "L", InstructionType.L },
        { "F", InstructionType.F }
    };

    public CardinalType TurnRight(CardinalType currentlyFacing)
    {
        return _turnRightLookup[currentlyFacing];
    }

    public CardinalType TurnLeft(CardinalType currentlyFacing)
    {
        return _turnLeftLookup[currentlyFacing];
    }

    public InstructionType GetInstructionType(string rawMoveLine) => _robotInstructionLookup.GetValueOrDefault(rawMoveLine, InstructionType.Unknown);

    public Coordinate GetUpdateCoordinateWith(CardinalType cardinalType)
    {
        var coordinateToReturn = _updateCoordinateWithLookup[cardinalType];
        return new Coordinate(coordinateToReturn.X, coordinateToReturn.Y);
    }
}