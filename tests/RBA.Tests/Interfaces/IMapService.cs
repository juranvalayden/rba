using RBA.Tests.Entities;
using RBA.Tests.Enums;

namespace RBA.Tests.Interfaces;

public interface IMapService
{
    CardinalType TurnRight(CardinalType currentlyFacing);
    CardinalType TurnLeft(CardinalType currentlyFacing);
    InstructionType GetInstructionType(string rawMoveLine);
    Coordinate GetUpdateCoordinateWith(CardinalType cardinalType);
}