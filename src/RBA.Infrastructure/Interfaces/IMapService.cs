using RBA.Domain.Entities;
using RBA.Domain.Enums;

namespace RBA.Infrastructure.Interfaces;

public interface IMapService
{
    CardinalType TurnRight(CardinalType currentlyFacing);
    CardinalType TurnLeft(CardinalType currentlyFacing);
    InstructionType GetInstructionType(string rawMoveLine);
    Coordinate GetUpdateCoordinateWith(CardinalType cardinalType);
}