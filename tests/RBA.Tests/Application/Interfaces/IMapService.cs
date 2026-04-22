using RBA.Tests.Domain.Entities;
using RBA.Tests.Domain.Enums;

namespace RBA.Tests.Application.Interfaces;

public interface IMapService
{
    CardinalType TurnRight(CardinalType currentlyFacing);
    CardinalType TurnLeft(CardinalType currentlyFacing);
    InstructionType GetInstructionType(string rawMoveLine);
    Coordinate GetUpdateCoordinateWith(CardinalType cardinalType);
}