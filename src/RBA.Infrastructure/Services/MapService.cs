using RBA.Domain.Entities;
using RBA.Domain.Enums;
using RBA.Infrastructure.Interfaces;

namespace RBA.Infrastructure.Services;

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

    public InstructionType GetInstruction(string rawMoveLine)
    {
        var isValidInstruction = Enum.TryParse<InstructionType>(rawMoveLine, true, out _);

        if (isValidInstruction)
        {
            return _robotInstructionLookup[rawMoveLine];
        }

        return InstructionType.Unknown;
    }

    public Coordinate GetUpdateCoordinateWith(CardinalType cardinalType)
    {
        return _updateCoordinateWithLookup[cardinalType];
    }
}